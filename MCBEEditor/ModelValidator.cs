using System;
using System.Collections.Generic;
using System.Linq;
using MCBECore.Schema;

namespace MCBEEditor
{
    public class ModelValidator
    {
        public ModelValidator()
        {
            Errors = new List<string>();
        }

        public bool Validate(MCBEModel model, ValidateType type = AllTypes)
        {
            var errors = new List<string>();

            if (type.HasFlag(ValidateType.ModelInfo))
            {
                errors.AddRange(validateModelInfo(model));
            }

            if (type.HasFlag(ValidateType.Descriptions))
            {
                errors.AddRange(validateDescriptions(model));
            }

            if (type.HasFlag(ValidateType.Rules))
            {
                errors.AddRange(validateRules(model));
            }

            if (errors.Count > 0)
            {
                Errors = errors;
                return false;
            }

            return true;
        }

        private List<string> validateModelInfo(MCBEModel model)
        {
            var errors = new List<string>();

            if (string.IsNullOrEmpty(model.name))
            {
                errors.Add("モデルの名称が設定されていません (model.name)");
            }

            if (model.name.IndexOfAny(invalidFileNameChars) >= 0)
            {
                errors.Add($"モデルの名称にファイル名に使えない文字が含まれています (model.name, {model.name})");
            }

            if (string.IsNullOrEmpty(model.id))
            {
                errors.Add("モデルのidが設定されていません (model.id)");
            }

            return errors;
        }

        private List<string> validateDescriptions(MCBEModel model)
        {
            var errors = new List<string>();

            if (model.descriptions == null || model.descriptions.Count == 0)
            {
                errors.Add("特徴リストが空です (model.descriptions)");
                return errors;
            }

            foreach (var desc in model.descriptions)
            {
                if (string.IsNullOrEmpty(desc.id))
                {
                    errors.Add("特徴idが空です (model.descriptions)");
                    continue;
                }
                //Guid id;
                //if (!Guid.TryParse(desc.id, out id))
                //{
                //    errors.Add($"特徴idの構文が間違っています");
                //}
                if (string.IsNullOrEmpty(desc.text))
                {
                    errors.Add($"特徴のテキストが空です (model.descriptions.{desc.id})");
                }
            }

            return errors;
        }

        private List<string> validateRules(MCBEModel model)
        {
            var errors = new List<string>();

            if (model.rules == null || model.rules.Count == 0)
            {
                errors.Add("ルールリストが空です (model.rules)");
                return errors;
            }

            foreach(var rule in model.rules)
            {
                if (string.IsNullOrEmpty(rule.id))
                {
                    errors.Add("ルールidが空です (model.rules)");
                    continue;
                }

                if (rule.priority <= 0)
                {
                    errors.Add($"ルールの優先度が0以下です (model.rules.{rule.id}, {rule.priority})");
                }

                if (rule.antecedents.Count == 0)
                {
                    errors.Add($"ルールの仮定部が空です (model.rules.{rule.id})");
                    continue;
                }
                if (rule.consequents.Count == 0)
                {
                    errors.Add($"ルールの結論部が空です (model.rules.{rule.id})");
                    continue;
                }
                var intersects = rule.consequents.Intersect(rule.antecedents).Count();
                if (intersects > 0)
                {
                    errors.Add($"ルールの仮定部と結論部に同じ項目が含まれています (model.rules.{rule.id}, count: {intersects})");
                    continue;
                }

                foreach (var desc in rule.antecedents)
                {
                    if (!model.descriptions.Any(d => d.id == desc.Key))
                    {
                        errors.Add($"存在しない特徴を参照しています (仮定部, model.rules.{rule.id}.antecedents.{desc.Key})");
                    }
                }
                foreach (var desc in rule.consequents)
                {
                    if (!model.descriptions.Any(d => d.id == desc.Key))
                    {
                        errors.Add($"存在しない特徴を参照しています (結論部, model.rules.{rule.id}.consequents.{desc.Key})");
                    }
                }
            }

            return errors;
        }

        public List<string> Errors { get; private set; }

        public const ValidateType AllTypes = ValidateType.Descriptions | ValidateType.ModelInfo | ValidateType.Rules;

        [Flags]
        public enum ValidateType
        {
            ModelInfo = 0x01,
            Descriptions = 0x02,
            Rules = 0x04
        }

        private char[] invalidFileNameChars = System.IO.Path.GetInvalidFileNameChars();

    }
}
