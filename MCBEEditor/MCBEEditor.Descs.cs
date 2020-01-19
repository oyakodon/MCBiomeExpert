using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using MCBECore.Schema;

namespace MCBEEditor
{
    public partial class MCBEEditor
    {
        // Description追加・編集タブ

        private int description_serial_number = 1;

        private void addButtonTabDescsItem_Click(object sender, EventArgs e)
        {
            if (descriptionsListBoxTabDescsItem.Items.Count > 0 && !validate(type: ModelValidator.ValidateType.Descriptions)) return;

            var desc = new MCBEDescription();
            desc.id = Guid.NewGuid().ToString();
            desc.isInternal = false;
            desc.comment = $"D{description_serial_number}";

            descriptionsListBoxTabDescsItem.Items.Add(desc);
            descriptionsListBoxTabDescsItem.SelectedIndex = descriptionsListBoxTabDescsItem.Items.Count - 1;

            description_serial_number++;

            isModelChanged = true;
        }

        private void removeButtonTabDescsItem_Click(object sender, EventArgs e)
        {
            if (descriptionsListBoxTabDescsItem.SelectedIndex < 0) return;
            if (!validate(type: ModelValidator.ValidateType.Descriptions)) return;

            descriptionsListBoxTabDescsItem.Items.RemoveAt(descriptionsListBoxTabDescsItem.SelectedIndex);

            descriptionsListBoxTabDescsItem.ClearSelected();
            descriptionGroupBoxTabDescsItem.Enabled = false;

            isModelChanged = true;
        }

        private void reloadImageComboBox()
        {
            imageComboBoxTabDescsItem.Items.Clear();
            var files = Directory.EnumerateFiles(modelBasePath + "\\images\\")
                .Where(f => f.EndsWith(".jpg", StringComparison.CurrentCultureIgnoreCase) || f.EndsWith(".jpeg", StringComparison.CurrentCultureIgnoreCase) || f.EndsWith(".png", StringComparison.CurrentCultureIgnoreCase))
                .Select(f => Path.GetFileName(f));
            imageComboBoxTabDescsItem.Items.AddRange(files.ToArray());
        }

        private int descriptionsListBoxTabDescsItem_prevIndex = -1;
        private void descriptionsListBoxTabDescsItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (descriptionsListBoxTabDescsItem.SelectedIndex < 0)
            {
                descriptionGroupBoxTabDescsItem.Enabled = false;
                removeButtonTabDescsItem.Enabled = false;

                return;
            }

            // 末尾項目をvalidation checkから除外
            if (descriptionsListBoxTabDescsItem.SelectedIndex < descriptionsListBoxTabDescsItem.Items.Count - 1)
            {
                if (!validate(type: ModelValidator.ValidateType.Descriptions))
                {
                    descriptionsListBoxTabDescsItem.SelectedIndex = descriptionsListBoxTabDescsItem_prevIndex;
                }
            }

            descriptionsListBoxTabDescsItem_prevIndex = descriptionsListBoxTabDescsItem.SelectedIndex;
            descriptionGroupBoxTabDescsItem.Enabled = true;
            removeButtonTabDescsItem.Enabled = true;

            var desc = descriptionsListBoxTabDescsItem.SelectedItem as MCBEDescription;
            idLabelTabDescsItem.Text = desc.id;
            isInternalCheckBoxTabDescsItem.Checked = desc.isInternal;
            textTextBoxTabDescsItem.Text = desc.text;
            commentTextBoxTabDescsItem.Text = desc.comment;

            reloadImageComboBox();
            var image = (descriptionsListBoxTabDescsItem.SelectedItem as MCBEDescription).image;
            if (image != null && File.Exists(modelBasePath + "\\images\\" + image))
            {
                imageComboBoxTabDescsItem.SelectedIndex = imageComboBoxTabDescsItem.FindStringExact(image);
                forImagePictureBoxTabDescsItem.Image = new System.Drawing.Bitmap(modelBasePath + "\\images\\" + image);
            }
            else
            {
                forImagePictureBoxTabDescsItem.Image = Properties.Resources.no_image;
            }

        }

        private void imageComboBoxTabDescsItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            var path = modelBasePath + "\\images\\" + (imageComboBoxTabDescsItem.SelectedItem as string);
            if (File.Exists(path))
            {
                forImagePictureBoxTabDescsItem.Image = new System.Drawing.Bitmap(path);
                (descriptionsListBoxTabDescsItem.SelectedItem as MCBEDescription).image = (imageComboBoxTabDescsItem.SelectedItem as string);

                isModelChanged = true;
            }
            else
            {
                forImagePictureBoxTabDescsItem.Image = Properties.Resources.no_image;
            }
        }

        private void commentTextBoxTabDescsItem_Leave(object sender, EventArgs e)
        {
            var desc = (descriptionsListBoxTabDescsItem.SelectedItem as MCBEDescription);
            if (desc == null) return;

            if (desc.comment != commentTextBoxTabDescsItem.Text)
            {
                isModelChanged = true;
            }
            desc.comment = commentTextBoxTabDescsItem.Text;
            descriptionsListBoxTabDescsItem.Items[descriptionsListBoxTabDescsItem.SelectedIndex] = desc;
        }

        private void textTextBoxTabDescsItem_Leave(object sender, EventArgs e)
        {
            var desc = (descriptionsListBoxTabDescsItem.SelectedItem as MCBEDescription);
            if (desc == null) return;

            if (desc.text != textTextBoxTabDescsItem.Text)
            {
                isModelChanged = true;
            }
            desc.text = textTextBoxTabDescsItem.Text;
            descriptionsListBoxTabDescsItem.Items[descriptionsListBoxTabDescsItem.SelectedIndex] = desc;
        }

        private void isInternalCheckBoxTabDescsItem_CheckedChanged(object sender, EventArgs e)
        {
            var desc = (descriptionsListBoxTabDescsItem.SelectedItem as MCBEDescription);
            if (desc == null) return;

            if (desc.isInternal != isInternalCheckBoxTabDescsItem.Checked)
            {
                isModelChanged = true;
            }
            desc.isInternal = isInternalCheckBoxTabDescsItem.Checked;
            descriptionsListBoxTabDescsItem.Items[descriptionsListBoxTabDescsItem.SelectedIndex] = desc;
        }
    }
}
