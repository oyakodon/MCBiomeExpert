using System;
using System.IO;
using System.Windows.Forms;

namespace MCBEEditor
{
    public partial class NewModelDialog : Form
    {
        public NewModelDialog()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterParent;

            ModelName = null;
            SavePath = null;
        }

        public string ModelName { get; private set; }
        public string SavePath { get; private set; }

        private bool validate()
        {
            errorProvider.SetError(nameTextBox, null);
            errorProvider.SetError(savePathTextBox, null);

            if (string.IsNullOrEmpty(nameTextBox.Text.Trim()))
            {
                errorProvider.SetError(nameTextBox, "名称が入力されていません");
                return false;
            }

            var invalidChars = Path.GetInvalidFileNameChars();
            if (nameTextBox.Text.IndexOfAny(invalidChars) >= 0)
            {
                errorProvider.SetError(nameTextBox, "フォルダ名に使用できない文字が含まれています");
                return false;
            }

            if (string.IsNullOrEmpty(savePathTextBox.Text.Trim()))
            {
                errorProvider.SetError(savePathTextBox, "保存先が選択されていません");
                return false;
            }

            if (!Directory.Exists(savePathTextBox.Text))
            {
                errorProvider.SetError(savePathTextBox, "保存先が正しくありません");
                return false;
            }

            if (Directory.Exists(savePathTextBox.Text + "\\" + nameTextBox.Text))
            {
                errorProvider.SetError(nameTextBox, "同名のモデルが既に存在します。");
                return false;
            }

            return true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (validate())
            {
                ModelName = nameTextBox.Text;
                SavePath = savePathTextBox.Text;

                this.Close();
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void selectFolderButton_Click(object sender, EventArgs e)
        {
            var fsdlg = new FolderSelectDialog();
            fsdlg.Title = "保存先フォルダを選択してください";
            fsdlg.Path = Environment.CurrentDirectory;

            if (fsdlg.ShowDialog() == DialogResult.OK )
            {
                savePathTextBox.Text = fsdlg.Path;
            }
        }

        private void NewModelDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ModelName != null && SavePath != null)
            {
                this.DialogResult = DialogResult.OK;
            } else
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
