using System;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;

namespace ScreenshotsViewer
{
    public partial class Viewer : Form
    {
        public Viewer()
        {
            InitializeComponent();
        }

        private Dictionary<string, string> m_biomeNameToJP = new Dictionary<string, string>();
        private string m_screenShotPath = null;
        private string m_selectedBiomePath = null;

        /// <summary>
        /// ウィンドウロード時
        /// </summary>
        private void Viewer_Load(object sender, EventArgs e)
        {
            // biome定義jsonファイルのロード
            using (var sr = new StreamReader("./biomes.json", Encoding.UTF8))
            {
                m_biomeNameToJP = JsonConvert.DeserializeObject<Dictionary<string, string>>(sr.ReadToEnd());
            }

            // listBoxの初期化とEnabled変更
            listBiomes.Items.AddRange(m_biomeNameToJP.Keys.ToArray());

//#if DEBUG
//            tbDataFolder.Text = @"C:\Users\\Desktop\バイオームスクショ";
//            listBiomes.Enabled = true;
//#endif

        }

        /// <summary>
        /// ツールバー > ファイル > 終了
        /// アプリケーションを終了する
        /// </summary>
        private void 終了XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void picBoxImage_DoubleClick(object sender, EventArgs e)
        {
            if (listImages.SelectedIndex < 0) return;

            var selected = m_selectedBiomePath + "\\" + listImages.SelectedItem.ToString();
            if (File.Exists(selected))
            {
                var viewer = new PhotoDetailViewer(selected);
                viewer.ShowDialog();
            }
        }

        private void listImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listImages.SelectedIndex < 0)
            {
                label2.Visible = false;
                return;
            }

            var selected = m_selectedBiomePath + "\\" + listImages.SelectedItem.ToString();
            if (File.Exists(selected))
            {
                picBoxImage.ImageLocation = selected;
                label2.Visible = true;
            }
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            fbd.Description = "データフォルダを指定してください。";

            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                tbDataFolder.Text = fbd.SelectedPath;
                listBiomes.Enabled = true;
            }

        }

        private void listBiomes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBiomes.SelectedIndex < 0)
            {
                label2.Visible = false;
                return;
            }

            picBoxImage.Image = null;

            tbDataFolder.Enabled = btnSelectFolder.Enabled = false;
            var selected = new KeyValuePair<string, string>
                (listBiomes.SelectedItem.ToString(),
                m_biomeNameToJP[listBiomes.SelectedItem.ToString()]);
            var status_label = $"バイオーム名: {selected.Value} ({selected.Key}), ";

            // 選択されたフォルダのロード
            m_screenShotPath = tbDataFolder.Text;
            m_selectedBiomePath = m_screenShotPath + "\\" + selected.Key;
            if (Directory.Exists(m_selectedBiomePath))
            {
                var files = Directory.EnumerateFiles(m_selectedBiomePath).Where(x => !x.EndsWith("desktop.ini"));
                listImages.Items.Clear();
                listImages.Items.AddRange(files.Select(f => Path.GetFileName(f)).ToArray());
                listImages.Enabled = true;
                label2.Visible = false;
                status_label += $"画像数: {files.Count()}";
                toolStripStatusLabel1.Text = status_label;

            }
            else
            {
                MessageBox.Show("バイオームフォルダが存在しません。", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbDataFolder.Enabled = btnSelectFolder.Enabled = true;
            }
        }

        private void データフォルダを開くDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(tbDataFolder.Text))
            {
                System.Diagnostics.Process.Start(tbDataFolder.Text);
            }
        }

        private void mCスクリーンショットフォルダを開くSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var appdata = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var mcssPath = appdata + "\\.minecraft\\screenshots";

            if (Directory.Exists(mcssPath))
            {
                System.Diagnostics.Process.Start(mcssPath);
            }
            
        }
    }
}
