using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenshotsViewer
{
    public partial class PhotoDetailViewer : Form
    {
        public PhotoDetailViewer(string picPath)
        {
            m_picPath = picPath;
            this.Text = m_picPath;

            InitializeComponent();
        }

        private void PhotoDetailViewer_Load(object sender, EventArgs e)
        {
            picBoxMain.ImageLocation = m_picPath;
        }

        private string m_picPath = null;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(picBoxMain.Size.ToString());
        }
    }
}
