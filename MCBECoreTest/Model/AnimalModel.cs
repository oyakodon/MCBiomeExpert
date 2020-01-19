using System;
using System.Collections.Generic;

using Newtonsoft.Json;

using MCBECore.Schema;

namespace MCBECoreTest.Model
{
    public static class AnimalModel
    {
        public static string GetJson()
        {

            return JsonConvert.SerializeObject(model);
        }

        public static MCBEModel GetModel()
        {
            return model;
        }

        private static readonly MCBEModel model = createModel();

        private static MCBEModel createModel()
        {
            var model = new MCBEModel();

            model.name = "Animal Expert";
            model.id = Guid.NewGuid().ToString();

            model.descriptions = new List<MCBEDescription>();
            {
                var descs = new Dictionary<string, (string text, bool isInternal)>()
                {
                    { "D1", ("体毛を持つ", false) },
                    { "D2", ("ほ乳動物である", true) },
                    { "D3", ("授乳する", false) },
                    { "D4", ("飛ぶ", false) },
                    { "D5", ("卵を産む", false) },
                    { "D6", ("鳥類である", false) },
                    { "D7", ("翼を持つ", false) },
                    { "D8", ("ペンギンである", false) },
                    { "D9", ("肉を食べる", false) },
                    { "D10", ("肉食動物である", true) },
                    { "D11", ("鋭い歯を持つ", false) },
                    { "D12", ("鋭い爪を持つ", false) },
                    { "D13", ("蹄を持つ", false) },
                    { "D14", ("有蹄動物である", false) },
                    { "D15", ("体の色は黄褐色である", false) },
                    { "D16", ("黒いしまを持つ", false) },
                    { "D17", ("虎である", false) },
                    { "D18", ("黒い斑点を持つ", false) },
                    { "D19", ("チーターである", false) }
                };

                foreach (var item in descs)
                {
                    var d = new MCBEDescription();
                    d.id = item.Key;
                    d.isInternal = item.Value.isInternal;
                    d.text = item.Value.text;
                    model.descriptions.Add(d);
                }
            }

            model.rules = new List<MCBERule>();
            // R1
            {
                var R1 = new MCBERule();
                R1.id = "R1";
                R1.priority = 1;
                R1.antecedents = new Dictionary<string, bool>() { { "D1", true } };
                R1.consequents = new Dictionary<string, bool>() { { "D2", true } };
                model.rules.Add(R1);
            }
            // R2
            {
                var R2 = new MCBERule();
                R2.id = "R2";
                R2.priority = 2;
                R2.antecedents = new Dictionary<string, bool>() { { "D3", true } };
                R2.consequents = new Dictionary<string, bool>() { { "D2", true } };
                model.rules.Add(R2);
            }
            // R3
            {
                var R3 = new MCBERule();
                R3.id = "R3";
                R3.priority = 3;
                R3.antecedents = new Dictionary<string, bool>() { { "D4", true }, { "D5", true }, { "D2", false } };
                R3.consequents = new Dictionary<string, bool>() { { "D6", true } };
                model.rules.Add(R3);
            }
            // R4
            {
                var R4 = new MCBERule();
                R4.id = "R4";
                R4.priority = 4;
                R4.antecedents = new Dictionary<string, bool>() { { "D7", true }, { "D8", false }, { "D2", false } };
                R4.consequents = new Dictionary<string, bool>() { { "D4", true } };
                model.rules.Add(R4);
            }
            // R5
            {
                var R5 = new MCBERule();
                R5.id = "R5";
                R5.priority = 5;
                R5.antecedents = new Dictionary<string, bool>() { { "D2", true }, { "D9", true } };
                R5.consequents = new Dictionary<string, bool>() { { "D10", true } };
                model.rules.Add(R5);
            }
            // R6
            {
                var R6 = new MCBERule();
                R6.id = "R6";
                R6.priority = 6;
                R6.antecedents = new Dictionary<string, bool>() { { "D2", true }, { "D11", true }, { "D12", true } };
                R6.consequents = new Dictionary<string, bool>() { { "D10", true } };
                model.rules.Add(R6);
            }
            // R7
            {
                var R7 = new MCBERule();
                R7.id = "R7";
                R7.priority = 7;
                R7.antecedents = new Dictionary<string, bool>() { { "D2", true }, { "D13", true } };
                R7.consequents = new Dictionary<string, bool>() { { "D14", true } };
                model.rules.Add(R7);
            }
            // R8
            {
                var R8 = new MCBERule();
                R8.id = "R8";
                R8.priority = 8;
                R8.antecedents = new Dictionary<string, bool>() { { "D10", true }, { "D15", true }, { "D16", true } };
                R8.consequents = new Dictionary<string, bool>() { { "D17", true } };
                model.rules.Add(R8);
            }
            // R9
            {
                var R9 = new MCBERule();
                R9.id = "R9";
                R9.priority = 9;
                R9.antecedents = new Dictionary<string, bool>() { { "D10", true }, { "D15", true }, { "D18", true } };
                R9.consequents = new Dictionary<string, bool>() { { "D19", true } };
                model.rules.Add(R9);
            }

            return model;
        }
    }
}
