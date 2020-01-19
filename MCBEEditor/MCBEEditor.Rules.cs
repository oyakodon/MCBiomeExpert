using System;
using System.Collections.Generic;
using System.Windows.Forms;

using MCBECore.Schema;

namespace MCBEEditor
{
    public partial class MCBEEditor
    {
        // Rule追加・編集タブ

        private int rulesListBoxTabRulesItem_prevIndex = -1;

        private int rule_serial_number = 1;

        /// <summary>
        /// ルールの新規追加
        /// </summary>
        private void addRuleButtonTabRulesItem_Click(object sender, EventArgs e)
        {
            if (rulesListBoxTabRulesItem.Items.Count > 0 && !validate(type: ModelValidator.ValidateType.Rules)) return;

            var rule = new MCBERule();
            rule.id = Guid.NewGuid().ToString();
            rule.comment = $"R{rule_serial_number}";
            rule.antecedents = new Dictionary<string, bool>();
            rule.consequents = new Dictionary<string, bool>();

            rulesListBoxTabRulesItem.Items.Add(rule);
            rulesListBoxTabRulesItem.SelectedIndex = rulesListBoxTabRulesItem.Items.Count - 1;

            rule_serial_number++;

            isModelChanged = true;
        }

        /// <summary>
        /// 選択されているルールの削除
        /// </summary>
        private void removeRuleButtonTabRulesItem_Click(object sender, EventArgs e)
        {
            if (rulesListBoxTabRulesItem.SelectedIndex < 0) return;
            if (rulesListBoxTabRulesItem.Items.Count > 1)
            {
                if (!validate(type: ModelValidator.ValidateType.Rules)) return;
            }

            rulesListBoxTabRulesItem.Items.RemoveAt(rulesListBoxTabRulesItem.SelectedIndex);
            rulesListBoxTabRulesItem.ClearSelected();

            isModelChanged = true;
        }

        /// <summary>
        /// 選択されているルールが変更された時
        /// -> GroupBox内の表示を変更
        /// </summary>
        private void rulesListBoxTabRulesItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rulesListBoxTabRulesItem.SelectedIndex < 0)
            {
                ruleGroupBoxTabRulesItem.Enabled = false;
                removeRuleButtonTabRulesItem.Enabled = false;

                upRuleButtonTabRulesItem.Enabled = false;
                downRuleButtonTabRulesItem.Enabled = false;

                return;
            }

            // 末尾項目をvalidation checkから除外
            if (rulesListBoxTabRulesItem.SelectedIndex < rulesListBoxTabRulesItem.Items.Count - 1)
            {
                if (!validate(type: ModelValidator.ValidateType.Rules))
                {
                    rulesListBoxTabRulesItem.SelectedIndex = rulesListBoxTabRulesItem_prevIndex;
                }
            }

            ruleGroupBoxTabRulesItem.Enabled = true;
            removeRuleButtonTabRulesItem.Enabled = true;

            upRuleButtonTabRulesItem.Enabled = (rulesListBoxTabRulesItem.SelectedIndex == 0) ? false : true;
            downRuleButtonTabRulesItem.Enabled = (rulesListBoxTabRulesItem.SelectedIndex == rulesListBoxTabRulesItem.Items.Count - 1) ? false : true;

            rulesListBoxTabRulesItem_prevIndex = rulesListBoxTabRulesItem.SelectedIndex;

            // ルール内情報をUIに適用
            var rule = rulesListBoxTabRulesItem.SelectedItem as MCBERule;
            idLabelTabRulesItem.Text = rule.id;
            commentTextBoxTabRulesItem.Text = rule.comment;

            // 仮定部
            antecedentsCheckedListBoxTabRulesItem.BeginUpdate();
            antecedentsCheckedListBoxTabRulesItem.Items.Clear();
            foreach(var d in rule.antecedents)
            {
                antecedentsCheckedListBoxTabRulesItem.Items.Add(d.Key, d.Value ? CheckState.Checked : CheckState.Unchecked);
            }
            antecedentsCheckedListBoxTabRulesItem.EndUpdate();

            // 結論部
            consequentsCheckedListBoxTabRulesItem.BeginUpdate();
            consequentsCheckedListBoxTabRulesItem.Items.Clear();
            foreach (var d in rule.consequents)
            {
                consequentsCheckedListBoxTabRulesItem.Items.Add(d.Key, d.Value ? CheckState.Checked : CheckState.Unchecked);
            }
            consequentsCheckedListBoxTabRulesItem.EndUpdate();
        }

        /// <summary>
        /// 選択されている仮定部のDescriptionが変更された時
        /// -> 削除ボタンの有効/無効を変更
        /// </summary>
        private void antecedentsCheckedListBoxTabRulesItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (antecedentsCheckedListBoxTabRulesItem.SelectedIndex < 0)
            {
                removeDescriptionButtonTabRulesItem.Enabled = false;
                return;
            }

            removeDescriptionButtonTabRulesItem.Enabled = true;
        }

        /// <summary>
        /// 選択されている結論部のDescriptionが変更された時
        /// -> 削除ボタンの有効/無効を変更
        /// </summary>
        private void consequentsCheckedListBoxTabRulesItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (consequentsCheckedListBoxTabRulesItem.SelectedIndex < 0)
            {
                removeDescriptionButtonTabRulesItem.Enabled = false;
                return;
            }

            removeDescriptionButtonTabRulesItem.Enabled = true;
        }

        /// <summary>
        /// コメントのテキストボックスのフォーカスが外れた時
        /// -> データに適用
        /// </summary>
        private void commentTextBoxTabRulesItem_Leave(object sender, EventArgs e)
        {
            var rule = rulesListBoxTabRulesItem.SelectedItem as MCBERule;
            if (rule == null)
            {
                return;
            }

            if (rule.comment != commentTextBoxTabRulesItem.Text)
            {
                isModelChanged = true;
            }
            rule.comment = commentTextBoxTabRulesItem.Text;
            rulesListBoxTabRulesItem.Items[rulesListBoxTabRulesItem.SelectedIndex] = rule;
        }

        /// <summary>
        /// 選択されているDescriptionが変更されたとき
        /// -> 追加ボタンを有効/無効化
        /// </summary>
        private void descriptionsListBoxTabRulesItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (descriptionsListBoxTabRulesItem.SelectedIndex < 0)
            {
                addDescriptionButtonTabRulesItem.Enabled = false;
                return;
            }

            addDescriptionButtonTabRulesItem.Enabled = true;
        }

        /// <summary>
        /// Description追加ボタン(>)押下時
        /// -> 仮定部/結論部 に対象項目を追加
        /// </summary>
        private void addDescriptionButtonTabRulesItem_Click(object sender, EventArgs e)
        {
            var desc = descriptionsListBoxTabRulesItem.SelectedItem as MCBEDescription;
            if (desc == null)
            {
                return;
            }
            var rule = rulesListBoxTabRulesItem.SelectedItem as MCBERule;
            if (rule == null)
            {
                return;
            }
            var id = desc.id;

            switch (tabControlRuleProperty.SelectedIndex)
            {
                case 0:
                    // antecedents
                    if (descriptionsListBoxTabRulesItem.SelectedIndex >= 0)
                    {
                        if (antecedentsCheckedListBoxTabRulesItem.Items.Contains(id))
                        {
                            return;
                        }

                        antecedentsCheckedListBoxTabRulesItem.Items.Add(id, true);

                        rule.antecedents.Add(id, true);
                        rulesListBoxTabRulesItem.Items[rulesListBoxTabRulesItem.SelectedIndex] = rule;

                        isModelChanged = true;
                    }
                    break;
                case 1:
                    // consequents
                    if (descriptionsListBoxTabRulesItem.SelectedIndex >= 0)
                    {
                        if (consequentsCheckedListBoxTabRulesItem.Items.Contains(id))
                        {
                            return;
                        }

                        consequentsCheckedListBoxTabRulesItem.Items.Add(id, true);

                        rule.consequents.Add(id, true);
                        rulesListBoxTabRulesItem.Items[rulesListBoxTabRulesItem.SelectedIndex] = rule;

                        isModelChanged = true;
                    }
                    break;
            }
        }

        /// <summary>
        /// Description削除ボタン(<)押下時
        /// -> 仮定部/結論部 から対象項目を削除
        /// </summary>
        private void removeDescriptionButtonTabRulesItem_Click(object sender, EventArgs e)
        {
            var rule = rulesListBoxTabRulesItem.SelectedItem as MCBERule;
            if (rule == null)
            {
                return;
            }

            switch (tabControlRuleProperty.SelectedIndex)
            {
                case 0:
                    // antecedents
                    if (antecedentsCheckedListBoxTabRulesItem.SelectedIndex >= 0)
                    {
                        var id = antecedentsCheckedListBoxTabRulesItem.SelectedItem as string;
                        antecedentsCheckedListBoxTabRulesItem.Items.RemoveAt(antecedentsCheckedListBoxTabRulesItem.SelectedIndex);

                        rule.antecedents.Remove(id);
                        rulesListBoxTabRulesItem.Items[rulesListBoxTabRulesItem.SelectedIndex] = rule;

                        isModelChanged = true;
                    }
                    break;
                case 1:
                    // consequents
                    if (consequentsCheckedListBoxTabRulesItem.SelectedIndex >= 0)
                    {
                        var id = consequentsCheckedListBoxTabRulesItem.SelectedItem as string;
                        consequentsCheckedListBoxTabRulesItem.Items.RemoveAt(consequentsCheckedListBoxTabRulesItem.SelectedIndex);

                        rule.consequents.Remove(id);
                        rulesListBoxTabRulesItem.Items[rulesListBoxTabRulesItem.SelectedIndex] = rule;

                        isModelChanged = true;
                    }
                    break;
            }
        }

        /// <summary>
        /// 仮定部のチェックボックスリストがチェックが変更されたとき
        /// </summary>
        private void antecedentsCheckedListBoxTabRulesItem_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var rule = rulesListBoxTabRulesItem.SelectedItem as MCBERule;
            if (rule == null)
            {
                return;
            }

            var id = antecedentsCheckedListBoxTabRulesItem.SelectedItem as string;
            if (id == null)
            {
                return;
            }

            var value = e.NewValue == CheckState.Checked;

            rule.antecedents[id] = value;
            rulesListBoxTabRulesItem.Items[rulesListBoxTabRulesItem.SelectedIndex] = rule;

            isModelChanged = true;
        }

        /// <summary>
        /// 結論部のチェックボックスリストがチェックが変更されたとき
        /// </summary>
        private void consequentsCheckedListBoxTabRulesItem_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            var rule = rulesListBoxTabRulesItem.SelectedItem as MCBERule;
            if (rule == null)
            {
                return;
            }

            var id = consequentsCheckedListBoxTabRulesItem.SelectedItem as string;
            if (id == null)
            {
                return;
            }

            var value = e.NewValue == CheckState.Checked;

            rule.consequents[id] = value;
            rulesListBoxTabRulesItem.Items[rulesListBoxTabRulesItem.SelectedIndex] = rule;

            isModelChanged = true;
        }

        private void downRuleButtonTabRulesItem_Click(object sender, EventArgs e)
        {
            var tmp = rulesListBoxTabRulesItem.SelectedItem as MCBERule;
            var prevIndex = rulesListBoxTabRulesItem.SelectedIndex;

            if (prevIndex == rulesListBoxTabRulesItem.Items.Count - 1) return;

            rulesListBoxTabRulesItem.Items.RemoveAt(prevIndex);
            rulesListBoxTabRulesItem.Items.Insert(prevIndex + 1, tmp);

            rulesListBoxTabRulesItem.SelectedIndex = prevIndex + 1;

            isModelChanged = true;
        }

        private void upRuleButtonTabRulesItem_Click(object sender, EventArgs e)
        {
            var tmp = rulesListBoxTabRulesItem.SelectedItem as MCBERule;
            var prevIndex = rulesListBoxTabRulesItem.SelectedIndex;

            if (prevIndex == 0) return;

            rulesListBoxTabRulesItem.Items.RemoveAt(prevIndex);
            rulesListBoxTabRulesItem.Items.Insert(prevIndex - 1, tmp);

            rulesListBoxTabRulesItem.SelectedIndex = prevIndex - 1;

            isModelChanged = true;
        }

    }
}
