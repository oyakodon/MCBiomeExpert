using System.Windows.Forms;
using System.Reflection;
using System;

namespace MCBEIdentifier
{
    public partial class AboutVersionDialog : Form
    {
        public AboutVersionDialog()
        {
            InitializeComponent();

            this.Icon = Properties.Resources.app_icon;

            iconPictureBox.Image = Properties.Resources.app_icon.ToBitmap();

            var asm = Assembly.GetExecutingAssembly();
            T GetCustomAttribute<T>() where T : Attribute => (T)Attribute.GetCustomAttribute(asm, typeof(T));

            var asmTitle = GetCustomAttribute<AssemblyTitleAttribute>().Title;
            var asmVersion = asm.GetName().Version;
            var asmCopyright = GetCustomAttribute<AssemblyCopyrightAttribute>().Copyright;
            
            this.Text = asmTitle;
            titleLabel.Text = asmTitle;
            versionLabel.Text = $"{asmVersion.Major}.{asmVersion.Minor}";
            copyrightLabel.Text = asmCopyright;

        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
