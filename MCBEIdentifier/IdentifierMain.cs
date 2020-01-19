using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

using Newtonsoft.Json;

using MCBECore.Schema;

namespace MCBEIdentifier
{
    public partial class IdentifierMain : Form
    {
        public IdentifierMain()
        {
            InitializeComponent();

            var asm = System.Reflection.Assembly.GetExecutingAssembly();
            T getCustomAttribute<T>() where T : Attribute => (T)Attribute.GetCustomAttribute(asm, typeof(T));
            var asmTitle = getCustomAttribute<System.Reflection.AssemblyTitleAttribute>();
            FormTitle = asmTitle.Title;
        }

        private readonly string FormTitle;

        private int askedCount = 0;

        /// <summary>
        /// 拡張モード (画面左右に回答や候補を表示する)
        /// </summary>
        private bool extendMode = false;
        /// <summary>
        /// 短絡モード (合致する項目があればそこで判別を止める)
        /// </summary>
        private bool shortcutMode = false;

        private MCBEModel model = null;
        private MCBECore.Identifier identifier;

        private string modelPath = null;

        private (bool success, string message) openModel(string _path)
        {
            var path = _path + "\\model.json";
            if (!File.Exists(path))
            {
                return (false, "モデル定義ファイル(model.json)が存在しません。");
            }

            string json;
            using (var sr = new StreamReader(path, Encoding.UTF8))
            {
                json = sr.ReadToEnd();
            }

            bool deserializeErrored = false;
            model = JsonConvert.DeserializeObject<MCBEModel>(json, new JsonSerializerSettings()
            {
                Error = (sender, errorArgs) =>
                {
                    deserializeErrored = true;
                    errorArgs.ErrorContext.Handled = true;
                }
            });
            if (deserializeErrored)
            {
                return (false, "モデル定義ファイルのロード中にエラーが発生しました。正しいJSON形式でない可能性があります。");
            }

            identifier = new MCBECore.Identifier(model, shortcut: shortcutMode);

            return (true, null);
        }

        private bool showConfigureDialog()
        {
            var dlg = new ConfigDialog();
            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return false;
            }

            extendMode = dlg.ExtendMode;
            shortcutMode = dlg.ShortcutMode;

            if (extendMode)
            {
                descriptionsCheckedListBox.Visible = true;
                candidatesListBox.Visible = true;
            }

            return true;
        }

        private bool loadModelWizard()
        {
            if (!showConfigureDialog())
            {
                MessageBox.Show("設定がキャンセルされました。", FormTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();

                return false;
            }

            if (!showModelPathSelecter())
            {
                MessageBox.Show("モデルの選択がキャンセルされました。", FormTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();

                return false;
            }

            return true;
        }

        private bool showModelPathSelecter()
        {
            var fsd = new FolderSelectDialog();
            fsd.Title = "モデルの保存先を選択してください";
            fsd.Path = Environment.CurrentDirectory;

            if (fsd.ShowDialog() == DialogResult.OK)
            {
                var ret = openModel(fsd.Path);
                if (ret.success)
                {
                    MessageBox.Show("モデルのロードが完了しました。", FormTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                    modelPath = fsd.Path;
                    モデルの場所を開くDToolStripMenuItem.Enabled = true;
                    this.Text = FormTitle + " - " + model.name;

                    askNext();
                }
                else
                {
                    MessageBox.Show(ret.message, FormTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                return ret.success;
            }

            return false;
        }

        private void askNext()
        {
            questionHasPicLabel.Visible = false;
            questionNoPicLabel.Visible = false;
            questionPictureBox.Visible = false;

            var desc = identifier.DescriptionToAsk();

            candidatesListBox.Items.Clear();
            candidatesListBox.Items.AddRange(identifier.Candidates.ToArray());

            candidatesLabel.Text = "";

            if (identifier.State == MCBECore.Identifier.ResultState.Determined)
            {
                answerProgressBar.Value = 100;
            }
            else if (identifier.State == MCBECore.Identifier.ResultState.Unknown)
            {
                answerProgressBar.Value = 0;
            }
            else
            {
                var rem = identifier.RemainingDescriptionsToAsk;
                var current = answerProgressBar.Value;

                var progress = (double)askedCount / (rem + askedCount);

                answerProgressBar.Value = (int)(current + (100 - current) * progress);
            }

            if (identifier.State == MCBECore.Identifier.ResultState.Determined)
            {
                // 特定
                trueButton.Enabled = false;
                falseButton.Enabled = false;

                if (identifier.Determined.image != null)
                {
                    questionHasPicLabel.Text = identifier.Determined.text;
                    questionHasPicLabel.Visible = true;

                    questionPictureBox.Image = new System.Drawing.Bitmap(modelPath + "\\images\\" + identifier.Determined.image);
                    questionPictureBox.Visible = true;
                }
                else
                {
                    questionNoPicLabel.Text = identifier.Determined.text;
                    questionNoPicLabel.Visible = true;
                }

                MessageBox.Show($"決定: {identifier.Determined.text}", FormTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }

            if (identifier.State == MCBECore.Identifier.ResultState.Unknown)
            {
                // 判別不能 (複数の候補から絞り込めない or 候補が0)
                trueButton.Enabled = false;
                falseButton.Enabled = false;

                questionNoPicLabel.Text = "これ以上判別できません！";

                if (identifier.Candidates.Count > 0)
                {
                    questionNoPicLabel.Text += "\n\nもしかして・・・\n";
                    questionNoPicLabel.Text += string.Join("/", identifier.Candidates.Select(x => x.text));
                }

                questionNoPicLabel.Visible = true;

                return;
            }

            if (desc == null)
            {
                MessageBox.Show("予期せぬエラーが発生しました。", FormTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (desc.image != null)
            {
                questionHasPicLabel.Text = desc.text + "？";
                questionHasPicLabel.Visible = true;

                questionPictureBox.Image = new System.Drawing.Bitmap(modelPath + "\\images\\" + desc.image);
                questionPictureBox.Visible = true;
            }
            else
            {
                questionNoPicLabel.Text = desc.text + "？";
                questionNoPicLabel.Visible = true;
            }

            if (!extendMode && identifier.Candidates.Count <= 3)
            {
                // 3つ以下になったら、画面下部に候補を表示
                candidatesLabel.Text = "もしかして・・・: "
                    + string.Join("/", identifier.Candidates.Select(x => x.text));
            }
        }

        private void モデルの場所を開くDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // エクスプローラで開く
            if (modelPath != null)
            {
                System.Diagnostics.Process.Start(modelPath);
            }
        }

        private void モデルを開くOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            identifier = null;

            モデルの場所を開くDToolStripMenuItem.Enabled = false;
            questionHasPicLabel.Visible = false;
            questionNoPicLabel.Visible = false;
            questionPictureBox.Visible = false;
            extendMode = false;
            shortcutMode = false;
            trueButton.Enabled = true;
            falseButton.Enabled = true;
            descriptionsCheckedListBox.Items.Clear();
            candidatesListBox.Items.Clear();
            this.Text = FormTitle;
            answerProgressBar.Value = 0;
            askedCount = 0;

            loadModelWizard();
        }

        private void モデルを開きなおすRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            identifier = null;

            questionHasPicLabel.Visible = false;
            questionNoPicLabel.Visible = false;
            questionPictureBox.Visible = false;
            
            trueButton.Enabled = true;
            falseButton.Enabled = true;
            descriptionsCheckedListBox.Items.Clear();
            candidatesListBox.Items.Clear();
            answerProgressBar.Value = 0;
            askedCount = 0;

            var ret = openModel(modelPath);
            if (ret.success)
            {
                MessageBox.Show("モデルのロードが完了しました。", FormTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                askNext();
            }
            else
            {
                MessageBox.Show(ret.message, FormTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void 終了QToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ヘルプを表示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("必要があれば作ります。", FormTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void バージョン情報VToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new AboutVersionDialog()).ShowDialog();
        }

        private void IdentifierMain_Load(object sender, EventArgs e)
        {
            var args = Environment.GetCommandLineArgs();
            if (args.Length == 2)
            {
                // 引数が1つ指定された
                var path = args[1] + @"\";
                if (Directory.Exists(path))
                {
                    // フォルダなら、ロードを試みる
                    var ret = openModel(path);
                    if (ret.success)
                    {
                        if (!showConfigureDialog())
                        {
                            MessageBox.Show("設定がキャンセルされました。", FormTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();

                            return;
                        }

                        modelPath = path;
                        モデルの場所を開くDToolStripMenuItem.Enabled = true;
                        this.Text = FormTitle + " - " + model.name;

                        askNext();

                        return;
                    }
                }
            }

            loadModelWizard();
        }

        private void IdentifierMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (identifier == null) return;
            if (identifier.State != MCBECore.Identifier.ResultState.Continue)
            {
                return;
            }

            var res = MessageBox.Show("判定を実行中です。終了しますか？", FormTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (res == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void falseButton_Click(object sender, EventArgs e)
        {
            askedCount++;

            if (extendMode)
            {
                descriptionsCheckedListBox.Items.Add(identifier.DescriptionToAsk(), false);
            }
            identifier.Answer(identifier.DescriptionToAsk(), false);

            askNext();
        }

        private void trueButton_Click(object sender, EventArgs e)
        {
            askedCount++;

            if (extendMode)
            {
                descriptionsCheckedListBox.Items.Add(identifier.DescriptionToAsk(), true);
            }
            identifier.Answer(identifier.DescriptionToAsk(), true);

            askNext();
        }

        private void descriptionsListBox_Format(object sender, ListControlConvertEventArgs e)
        {
            var desc = (MCBEDescription)e.ListItem;

            var signature = desc.id.Substring(0, 8);
            if (desc.comment != null)
            {
                signature = desc.comment;
            }
            e.Value = $"{signature}: {desc.text}";
        }
    }
}
