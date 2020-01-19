using System;
using System.Windows.Forms;

using MCBECore.Schema;

namespace MCBEEditor
{
    public partial class MCBEEditor
    {
        private void repaintTestStatuses()
        {
            candidatesListBoxTabTestItem.Items.Clear();
            candidatesListBoxTabTestItem.Items.AddRange(identifier.Candidates.ToArray());

            string state = "-";
            switch (identifier.State)
            {
                case MCBECore.Identifier.ResultState.Continue: state = "検討中"; break;
                case MCBECore.Identifier.ResultState.Determined: state = "決定"; break;
                case MCBECore.Identifier.ResultState.Unknown: state = "不明"; break;
                default: break;
            }
            stateLabelTabTestItem.Text = state;

            MCBEDescription determined = identifier.Determined;
            if (determined == null)
            {
                resultLabelTabTestItem.Text = "-";
            }
            else
            {
                if (determined.comment != null)
                {
                    resultLabelTabTestItem.Text = $"{determined.comment}: {determined.text}";
                } else
                {
                    resultLabelTabTestItem.Text = determined.text;
                }
            }

            var descToAsk = identifier.DescriptionToAsk();
            if (descToAsk != null)
            {
                if (descToAsk.comment != null)
                {
                    descriptionToAskLabelTabTestItem.Text = $"{descToAsk.comment}: {descToAsk.text}";
                }
                else
                {
                    descriptionToAskLabelTabTestItem.Text = $"{descToAsk.id.Substring(0, 8)}: {descToAsk.text}";
                }
            }
        }

        private void addButtonTabTestItem_Click(object sender, EventArgs e)
        {
            if (descriptionsComboBoxTabTestItem.SelectedIndex < 0)
            {
                return;
            }

            var desc = descriptionsComboBoxTabTestItem.SelectedItem as MCBEDescription;
            
            if (descriptionsCheckedListBoxTabTestItem.Items.Contains(desc))
            {
                return;
            }

            identifier.Answer(desc, conditionCheckBoxTabTestItem.Checked);

            descriptionsCheckedListBoxTabTestItem.Items.Add(desc.id, conditionCheckBoxTabTestItem.Checked);

            descriptionsComboBoxTabTestItem.Items.Remove(descriptionsComboBoxTabTestItem.SelectedItem);

            repaintTestStatuses();

            if (identifier.DescriptionToAsk() == null)
            {
                addButtonTabTestItem.Enabled = false;
            }
        }

        private void removeButtonTabTestItem_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show("項目を削除すると判別に問題が生じる可能性があります。削除しますか？\r\n\r\n※タブを切り替えることで判別器を初期化できます", FormTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (res == DialogResult.Cancel)
            {
                return;
            }

            if (descriptionsCheckedListBoxTabTestItem.SelectedIndex < 0)
            {
                return;
            }

            var id = descriptionsCheckedListBoxTabTestItem.SelectedItem as string;
            descriptionsCheckedListBoxTabTestItem.Items.Remove(id);

            identifier.Reset();

            if (descriptionsCheckedListBoxTabTestItem.Items.Count > 0)
            {
                foreach (string _id in descriptionsCheckedListBoxTabTestItem.Items)
                {
                    var isChecked = descriptionsCheckedListBoxTabTestItem.CheckedItems.Contains(_id);

                    identifier.Answer(id, isChecked);
                }
            }

            repaintTestStatuses();

            if (identifier.DescriptionToAsk() != null)
            {
                addButtonTabTestItem.Enabled = true;
            }
        }

        private void descriptionsCheckedListBoxTabTestItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (descriptionsCheckedListBoxTabTestItem.SelectedIndex < 0)
            {
                removeButtonTabTestItem.Enabled = false;
                return;
            }

            removeButtonTabTestItem.Enabled = true;
        }

        private void descriptionsCheckedListBoxTabTestItem_SelectedValueChanged(object sender, EventArgs e)
        {
            var isChecked = descriptionsCheckedListBoxTabTestItem.CheckedIndices.Contains(descriptionsCheckedListBoxTabTestItem.SelectedIndex);
            var id = descriptionsCheckedListBoxTabTestItem.SelectedItem as string;

            if (id == null) return;

            identifier.Answer(id, isChecked);

            repaintTestStatuses();
        }

    }
}
