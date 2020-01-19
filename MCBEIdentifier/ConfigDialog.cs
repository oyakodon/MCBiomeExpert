using System;
using System.Windows.Forms;

namespace MCBEIdentifier
{
    public partial class ConfigDialog : Form
    {
        public ConfigDialog()
        {
            InitializeComponent();

            ExtendMode = false;
            ShortcutMode = false;

            this.ActiveControl = confirmButton;
        }

        public bool ExtendMode { get; private set; }
        public bool ShortcutMode { get; private set; }
        
        private void confirmButton_Click(object sender, EventArgs e)
        {
            ExtendMode = extendModeCheckBox.Checked;
            ShortcutMode = shortcutModeCheckBox.Checked;

            this.DialogResult = DialogResult.OK;
        }

        private void ConfigDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult != DialogResult.OK)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
