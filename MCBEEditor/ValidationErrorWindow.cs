using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MCBEEditor
{
    public partial class ValidationErrorWindow : Form
    {
        public ValidationErrorWindow()
        {
            InitializeComponent();
        }

        private void ValidationErrorWindow_Load(object sender, EventArgs e)
        {
            var icon = new Bitmap(32, 32);
            using (var g = Graphics.FromImage(icon))
            {
                g.DrawIcon(SystemIcons.Exclamation, 0, 0);
            }
            iconPictureBox.Image = icon;
        }

        private void ValidationErrorWindow_Shown(object sender, EventArgs e)
        {
            if (errorsListBox.Items.Count == 0)
            {
                throw new InvalidOperationException();
            }
        }

        public void SetErrors(List<string> errors)
        {
            errorsListBox.Items.Clear();

            foreach(var error in errors)
            {
                errorsListBox.Items.Add(error);
            }
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
