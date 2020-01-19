using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;

using Newtonsoft.Json;

using MCBECore.Schema;

namespace MCBEEditor
{
    public partial class MCBEEditor : Form
    {
        public MCBEEditor()
        {
            InitializeComponent();

            validator = new ModelValidator();

            var asm = System.Reflection.Assembly.GetExecutingAssembly();
            T GetCustomAttribute<T>() where T : Attribute => (T)Attribute.GetCustomAttribute(asm, typeof(T));

            var asmTitle = GetCustomAttribute<System.Reflection.AssemblyTitleAttribute>().Title;
            FormTitle = asmTitle;

//#if DEBUG
//            modelName = "Test";
//            modelBasePath = @"C:\Users\\Desktop\Test";

//            descriptionGroupBoxTabDescsItem.Enabled = false;
//            ruleGroupBoxTabRulesItem.Enabled = false;
//            tabControlCategory.Enabled = true;

//            isModelChanged = true;
//#endif

        }

        private ModelValidator validator;
        private MCBECore.Identifier identifier;

        private readonly string FormTitle;
        
        private bool _isModelChanged = false;
        private bool isModelChanged
        {
            get
            {
                return _isModelChanged;
            }
            set
            {
                _isModelChanged = value;
                
                モデルの保存SToolStripMenuItem.Enabled = value;
                this.Text = FormTitle + $" - {modelName}";
                this.Text += (value ? " (*)" : "");
            }
        }


        private string modelName = null;
        private string modelBasePath = null;

        private bool validate(MCBEModel model = null, ModelValidator.ValidateType type = ModelValidator.AllTypes, bool showError = true)
        {
            if (model == null)
            {
                model = createModel();
            }

            var result = validator.Validate(model, type);
            if (!result && showError)
            {
                var errorWindow = new ValidationErrorWindow();
                errorWindow.SetErrors(validator.Errors);
                errorWindow.Show();
            }

            return result;
        }

        private MCBEModel createModel()
        {
            var model = new MCBEModel();

            model.id = Guid.NewGuid().ToString();
            model.name = modelName;

            model.descriptions = new List<MCBEDescription>();
            foreach (MCBEDescription item in descriptionsListBoxTabDescsItem.Items)
            {
                // コピーを作成
                model.descriptions.Add(new MCBEDescription(item));
            }

            model.rules = new List<MCBERule>();
            var priority = 1;
            foreach (MCBERule item in rulesListBoxTabRulesItem.Items)
            {
                model.rules.Add(new MCBERule(item));
                model.rules.Last().priority = priority;

                priority++;
            }

            return model;
        }

        private bool saveModel()
        {
            if (!isModelChanged) return false;

            var model = createModel();
            if (!validate(model))
            {
                return false;
            }

            var json = JsonConvert.SerializeObject(model, Formatting.Indented);
            using (var sw = new StreamWriter(modelBasePath + "\\model.json", false, Encoding.UTF8))
            {
                sw.Write(json);
            }

            this.Text = FormTitle + $" - {modelName}";
            isModelChanged = false;

            MessageBox.Show("モデルの保存が完了しました。", FormTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

            return true;
        }

        private MCBEModel openModel(string path)
        {
            if (!Directory.Exists(path)) return null;

            var filepath = path + "\\model.json";

            if (!File.Exists(filepath))
            {
                MessageBox.Show("保存先フォルダ内にモデル定義ファイル(model.json)が存在しません。", FormTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            bool deserializeErrored = false;
            string json = "";
            using (var sr = new StreamReader(filepath, Encoding.UTF8))
            {
                json = sr.ReadToEnd();
            }
            var model = JsonConvert.DeserializeObject<MCBEModel>(json, new JsonSerializerSettings
            {
                Error = (sender, errorArgs) =>
                {
                    deserializeErrored = true;
                    errorArgs.ErrorContext.Handled = true;
                }
            });
            if (deserializeErrored)
            {
                MessageBox.Show("モデル定義ファイル(model.json)の復元中にエラーが発生しました。正しいjsonファイルでない可能性があります。", FormTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            if (!validate(model, showError: false))
            {
                MessageBox.Show("モデルの検証に失敗しました。正しく作成されたモデルでない可能性があります。", FormTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            return model;
        }

        private void 終了QToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MCBEEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isModelChanged)
            {
                var res = MessageBox.Show("保存されていない変更があります。モデルを保存しますか？", FormTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (res == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }

                if (res == DialogResult.Yes)
                {
                    if (!saveModel())
                    {
                        e.Cancel = true;
                        return;
                    }
                }
            }
        }

        private void MCBEEditor_Load(object sender, EventArgs e)
        {
            var args = Environment.GetCommandLineArgs();
            if (args.Length == 2 && Directory.Exists(args[1]))
            {
                var path = args[1];
                var model = openModel(path);
                if (model != null)
                {
                    modelBasePath = path;
                    modelName = model.name;

                    this.Text = FormTitle + $" - {modelName}";

                    descriptionsListBoxTabDescsItem.Items.Clear();
                    descriptionsListBoxTabDescsItem.Items.AddRange(model.descriptions.ToArray());

                    rulesListBoxTabRulesItem.Items.Clear();
                    rulesListBoxTabRulesItem.Items.AddRange(model.rules.ToArray());

                    MessageBox.Show("モデルのロードが完了しました。", FormTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tabControlCategory.Enabled = true;

                    PanelNotice.Visible = false;
                }
                else
                {
                    MessageBox.Show("モデルのロード中にエラーが発生しました。", FormTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void モデルの保存SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveModel();
        }

        /// <summary>
        /// タブ変更時の現在いるタブの選択が解除されるときに呼ばれる
        /// A -> B へのタブ変更なら、Aの選択解除時に呼ばれ、TabPageIndex = (Aのindex) となる
        /// </summary>
        private void tabControlCategory_Deselecting(object sender, TabControlCancelEventArgs e)
        {
            switch (e.TabPageIndex)
            {
                case 0:
                    // Descriptions
                    if (!validate(type: ModelValidator.ValidateType.Descriptions))
                    {
                        e.Cancel = true;
                    }

                    break;
                case 1:
                    // Rules
                    if (rulesListBoxTabRulesItem.Items.Count > 0)
                    {
                        if (!validate(type: ModelValidator.ValidateType.Rules))
                        {
                            e.Cancel = true;
                        }
                    }

                    break;
                case 2:
                    // テスト
                    if (descriptionsCheckedListBoxTabTestItem.Items.Count > 0)
                    {
                        var res = MessageBox.Show("実行中のテストの状態は破棄されます。よろしいですか？", FormTitle, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                        if (res != DialogResult.OK)
                        {
                            e.Cancel = true;
                        }
                    }

                    break;
            }
        }

        private void tabControlCategory_Selecting(object sender, TabControlCancelEventArgs e)
        {
            switch (e.TabPageIndex)
            {
                case 0:
                    // Descriptions
                    break;

                case 1:
                    // Rules
                    descriptionsListBoxTabRulesItem.Items.Clear();
                    descriptionsListBoxTabRulesItem.Items.AddRange(descriptionsListBoxTabDescsItem.Items);
                    break;

                case 2:
                    // テスト
                    if (!validate())
                    {
                        e.Cancel = true;
                    }

                    descriptionsComboBoxTabTestItem.Items.Clear();
                    descriptionsComboBoxTabTestItem.Items.AddRange(descriptionsListBoxTabDescsItem.Items.Cast<MCBEDescription>().ToArray());

                    descriptionsCheckedListBoxTabTestItem.Items.Clear();

                    // identifierの下準備
                    identifier = new MCBECore.Identifier(createModel());

                    repaintTestStatuses();

                    break;

            }
        }

        private void モデルの新規作成NToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newModelDlg = new NewModelDialog();
            if (newModelDlg.ShowDialog() == DialogResult.OK)
            {
                modelName = newModelDlg.ModelName;
                modelBasePath = newModelDlg.SavePath + "\\" + modelName;

                Directory.CreateDirectory(modelBasePath + "\\images");

                descriptionGroupBoxTabDescsItem.Enabled = false;
                ruleGroupBoxTabRulesItem.Enabled = false;
                tabControlCategory.Enabled = true;

                isModelChanged = true;

                MessageBox.Show("モデルが新規作成されました。", FormTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);

                PanelNotice.Visible = false;
            }
            else
            {
                MessageBox.Show("新規作成がキャンセルされました。", FormTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void モデルを開くOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (isModelChanged)
            {
                var dlg = MessageBox.Show("現在編集中のモデルが保存されていません。保存してモデルを開きますか。", FormTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (dlg == DialogResult.Yes && !saveModel())
                {
                    MessageBox.Show("モデルの保存中にエラーが発生しました。", FormTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (dlg == DialogResult.Cancel)
                {
                    MessageBox.Show("モデルのロードがキャンセルされました。", FormTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            var fsd = new FolderSelectDialog();
            fsd.Title = "モデルの保存先フォルダを選択してください";
#if DEBUG
            fsd.Path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
#else
            fsd.Path = Environment.CurrentDirectory;
#endif

            if (fsd.ShowDialog() == DialogResult.OK)
            {
                var model = openModel(fsd.Path);
                if (model != null)
                {
                    modelBasePath = fsd.Path;
                    modelName = model.name;

                    this.Text = FormTitle + $" - {modelName}";

                    descriptionsListBoxTabDescsItem.Items.Clear();
                    descriptionsListBoxTabDescsItem.Items.AddRange(model.descriptions.ToArray());

                    rulesListBoxTabRulesItem.Items.Clear();
                    rulesListBoxTabRulesItem.Items.AddRange(model.rules.ToArray());

                    MessageBox.Show("モデルのロードが完了しました。", FormTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tabControlCategory.Enabled = true;

                    PanelNotice.Visible = false;
                }
                else
                {
                    MessageBox.Show("モデルのロード中にエラーが発生しました。", FormTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("モデルのロードがキャンセルされました。", FormTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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

        private void rulesListBox_Format(object sender, ListControlConvertEventArgs e)
        {
            var rule = e.ListItem as MCBERule;

            e.Value = rule.id.Substring(0, 8);
            if (rule.comment != null)
            {
                e.Value = rule.comment;
            }
        }

        private void descriptionsRulePropertyListBox_Format(object sender, ListControlConvertEventArgs e)
        {
            if (e.ListItem == null) return;

            var id = e.ListItem as string;

            if (descriptionsListBoxTabDescsItem.Items.Cast<MCBEDescription>().Any(d => d.id == id))
            {
                var desc = descriptionsListBoxTabDescsItem.Items.Cast<MCBEDescription>()
                    .First(d => d.id == id);

                var signature = desc.id.Substring(0, 8);
                if (desc.comment != null)
                {
                    signature = desc.comment;
                }
                e.Value = $"{signature}: {desc.text}";
            }
        }

        private void ヘルプを表示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("必要があれば作ります。", FormTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void バージョン情報VToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new AboutVersionDialog()).ShowDialog();
        }

        private void closeButtonPanelNoticeItem_Click(object sender, EventArgs e)
        {
            PanelNotice.Visible = false;
        }
    }
}
