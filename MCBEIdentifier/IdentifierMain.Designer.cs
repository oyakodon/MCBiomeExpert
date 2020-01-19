namespace MCBEIdentifier
{
    partial class IdentifierMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IdentifierMain));
            this.answerProgressBar = new System.Windows.Forms.ProgressBar();
            this.windowMenuStrip = new System.Windows.Forms.MenuStrip();
            this.ファイルFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.モデルの場所を開くDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.モデルを開くOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.モデルを開きなおすRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.終了QToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ヘルプHToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ヘルプを表示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.バージョン情報VToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.descriptionsCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.panelQuestion = new System.Windows.Forms.Panel();
            this.candidatesLabel = new System.Windows.Forms.Label();
            this.questionNoPicLabel = new System.Windows.Forms.Label();
            this.questionHasPicLabel = new System.Windows.Forms.Label();
            this.questionPictureBox = new System.Windows.Forms.PictureBox();
            this.trueButton = new System.Windows.Forms.Button();
            this.falseButton = new System.Windows.Forms.Button();
            this.candidatesListBox = new System.Windows.Forms.ListBox();
            this.windowMenuStrip.SuspendLayout();
            this.panelQuestion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.questionPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // answerProgressBar
            // 
            this.answerProgressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.answerProgressBar.Location = new System.Drawing.Point(0, 325);
            this.answerProgressBar.Name = "answerProgressBar";
            this.answerProgressBar.Size = new System.Drawing.Size(562, 23);
            this.answerProgressBar.TabIndex = 0;
            // 
            // windowMenuStrip
            // 
            this.windowMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルFToolStripMenuItem,
            this.ヘルプHToolStripMenuItem});
            this.windowMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.windowMenuStrip.Name = "windowMenuStrip";
            this.windowMenuStrip.Size = new System.Drawing.Size(562, 27);
            this.windowMenuStrip.TabIndex = 1;
            this.windowMenuStrip.Text = "menuStrip1";
            // 
            // ファイルFToolStripMenuItem
            // 
            this.ファイルFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.モデルの場所を開くDToolStripMenuItem,
            this.モデルを開くOToolStripMenuItem,
            this.モデルを開きなおすRToolStripMenuItem,
            this.終了QToolStripMenuItem});
            this.ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem";
            this.ファイルFToolStripMenuItem.Size = new System.Drawing.Size(77, 23);
            this.ファイルFToolStripMenuItem.Text = "ファイル(&F)";
            // 
            // モデルの場所を開くDToolStripMenuItem
            // 
            this.モデルの場所を開くDToolStripMenuItem.Name = "モデルの場所を開くDToolStripMenuItem";
            this.モデルの場所を開くDToolStripMenuItem.Size = new System.Drawing.Size(201, 24);
            this.モデルの場所を開くDToolStripMenuItem.Text = "モデルの場所を開く(&D)";
            this.モデルの場所を開くDToolStripMenuItem.Click += new System.EventHandler(this.モデルの場所を開くDToolStripMenuItem_Click);
            // 
            // モデルを開くOToolStripMenuItem
            // 
            this.モデルを開くOToolStripMenuItem.Name = "モデルを開くOToolStripMenuItem";
            this.モデルを開くOToolStripMenuItem.Size = new System.Drawing.Size(201, 24);
            this.モデルを開くOToolStripMenuItem.Text = "モデルを開く(&O)";
            this.モデルを開くOToolStripMenuItem.Click += new System.EventHandler(this.モデルを開くOToolStripMenuItem_Click);
            // 
            // モデルを開きなおすRToolStripMenuItem
            // 
            this.モデルを開きなおすRToolStripMenuItem.Name = "モデルを開きなおすRToolStripMenuItem";
            this.モデルを開きなおすRToolStripMenuItem.Size = new System.Drawing.Size(201, 24);
            this.モデルを開きなおすRToolStripMenuItem.Text = "モデルを開きなおす(&R)";
            this.モデルを開きなおすRToolStripMenuItem.Click += new System.EventHandler(this.モデルを開きなおすRToolStripMenuItem_Click);
            // 
            // 終了QToolStripMenuItem
            // 
            this.終了QToolStripMenuItem.Name = "終了QToolStripMenuItem";
            this.終了QToolStripMenuItem.Size = new System.Drawing.Size(201, 24);
            this.終了QToolStripMenuItem.Text = "終了(&Q)";
            this.終了QToolStripMenuItem.Click += new System.EventHandler(this.終了QToolStripMenuItem_Click);
            // 
            // ヘルプHToolStripMenuItem
            // 
            this.ヘルプHToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ヘルプを表示ToolStripMenuItem,
            this.バージョン情報VToolStripMenuItem});
            this.ヘルプHToolStripMenuItem.Name = "ヘルプHToolStripMenuItem";
            this.ヘルプHToolStripMenuItem.Size = new System.Drawing.Size(73, 23);
            this.ヘルプHToolStripMenuItem.Text = "ヘルプ(&H)";
            // 
            // ヘルプを表示ToolStripMenuItem
            // 
            this.ヘルプを表示ToolStripMenuItem.Name = "ヘルプを表示ToolStripMenuItem";
            this.ヘルプを表示ToolStripMenuItem.Size = new System.Drawing.Size(173, 24);
            this.ヘルプを表示ToolStripMenuItem.Text = "ヘルプを表示";
            this.ヘルプを表示ToolStripMenuItem.Click += new System.EventHandler(this.ヘルプを表示ToolStripMenuItem_Click);
            // 
            // バージョン情報VToolStripMenuItem
            // 
            this.バージョン情報VToolStripMenuItem.Name = "バージョン情報VToolStripMenuItem";
            this.バージョン情報VToolStripMenuItem.Size = new System.Drawing.Size(173, 24);
            this.バージョン情報VToolStripMenuItem.Text = "バージョン情報(&V)";
            this.バージョン情報VToolStripMenuItem.Click += new System.EventHandler(this.バージョン情報VToolStripMenuItem_Click);
            // 
            // descriptionsCheckedListBox
            // 
            this.descriptionsCheckedListBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.descriptionsCheckedListBox.FormattingEnabled = true;
            this.descriptionsCheckedListBox.Location = new System.Drawing.Point(0, 27);
            this.descriptionsCheckedListBox.Name = "descriptionsCheckedListBox";
            this.descriptionsCheckedListBox.Size = new System.Drawing.Size(120, 298);
            this.descriptionsCheckedListBox.TabIndex = 2;
            this.descriptionsCheckedListBox.Visible = false;
            this.descriptionsCheckedListBox.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.descriptionsListBox_Format);
            // 
            // panelQuestion
            // 
            this.panelQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelQuestion.Controls.Add(this.candidatesLabel);
            this.panelQuestion.Controls.Add(this.questionNoPicLabel);
            this.panelQuestion.Controls.Add(this.questionHasPicLabel);
            this.panelQuestion.Controls.Add(this.questionPictureBox);
            this.panelQuestion.Controls.Add(this.trueButton);
            this.panelQuestion.Controls.Add(this.falseButton);
            this.panelQuestion.Location = new System.Drawing.Point(118, 24);
            this.panelQuestion.Name = "panelQuestion";
            this.panelQuestion.Size = new System.Drawing.Size(327, 301);
            this.panelQuestion.TabIndex = 3;
            // 
            // candidatesLabel
            // 
            this.candidatesLabel.Font = new System.Drawing.Font("MS UI Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.candidatesLabel.Location = new System.Drawing.Point(8, 268);
            this.candidatesLabel.Name = "candidatesLabel";
            this.candidatesLabel.Size = new System.Drawing.Size(310, 27);
            this.candidatesLabel.TabIndex = 5;
            this.candidatesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // questionNoPicLabel
            // 
            this.questionNoPicLabel.Location = new System.Drawing.Point(40, 48);
            this.questionNoPicLabel.Name = "questionNoPicLabel";
            this.questionNoPicLabel.Size = new System.Drawing.Size(245, 156);
            this.questionNoPicLabel.TabIndex = 4;
            this.questionNoPicLabel.Text = "-";
            this.questionNoPicLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.questionNoPicLabel.Visible = false;
            // 
            // questionHasPicLabel
            // 
            this.questionHasPicLabel.Location = new System.Drawing.Point(40, 174);
            this.questionHasPicLabel.Name = "questionHasPicLabel";
            this.questionHasPicLabel.Size = new System.Drawing.Size(245, 53);
            this.questionHasPicLabel.TabIndex = 3;
            this.questionHasPicLabel.Text = "-";
            this.questionHasPicLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.questionHasPicLabel.Visible = false;
            // 
            // questionPictureBox
            // 
            this.questionPictureBox.Location = new System.Drawing.Point(61, 20);
            this.questionPictureBox.Name = "questionPictureBox";
            this.questionPictureBox.Size = new System.Drawing.Size(203, 140);
            this.questionPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.questionPictureBox.TabIndex = 2;
            this.questionPictureBox.TabStop = false;
            // 
            // trueButton
            // 
            this.trueButton.Location = new System.Drawing.Point(189, 242);
            this.trueButton.Name = "trueButton";
            this.trueButton.Size = new System.Drawing.Size(75, 23);
            this.trueButton.TabIndex = 1;
            this.trueButton.Text = "はい(&Y)";
            this.trueButton.UseVisualStyleBackColor = true;
            this.trueButton.Click += new System.EventHandler(this.trueButton_Click);
            // 
            // falseButton
            // 
            this.falseButton.Location = new System.Drawing.Point(61, 242);
            this.falseButton.Name = "falseButton";
            this.falseButton.Size = new System.Drawing.Size(75, 23);
            this.falseButton.TabIndex = 0;
            this.falseButton.Text = "いいえ(&N)";
            this.falseButton.UseVisualStyleBackColor = true;
            this.falseButton.Click += new System.EventHandler(this.falseButton_Click);
            // 
            // candidatesListBox
            // 
            this.candidatesListBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.candidatesListBox.FormattingEnabled = true;
            this.candidatesListBox.ItemHeight = 12;
            this.candidatesListBox.Location = new System.Drawing.Point(442, 27);
            this.candidatesListBox.Name = "candidatesListBox";
            this.candidatesListBox.Size = new System.Drawing.Size(120, 298);
            this.candidatesListBox.TabIndex = 0;
            this.candidatesListBox.Visible = false;
            this.candidatesListBox.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.descriptionsListBox_Format);
            // 
            // IdentifierMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 348);
            this.Controls.Add(this.panelQuestion);
            this.Controls.Add(this.candidatesListBox);
            this.Controls.Add(this.descriptionsCheckedListBox);
            this.Controls.Add(this.answerProgressBar);
            this.Controls.Add(this.windowMenuStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.windowMenuStrip;
            this.MaximizeBox = false;
            this.Name = "IdentifierMain";
            this.Text = "Minecraft Biome Expert";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IdentifierMain_FormClosing);
            this.Load += new System.EventHandler(this.IdentifierMain_Load);
            this.windowMenuStrip.ResumeLayout(false);
            this.windowMenuStrip.PerformLayout();
            this.panelQuestion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.questionPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar answerProgressBar;
        private System.Windows.Forms.MenuStrip windowMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ファイルFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ヘルプHToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ヘルプを表示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem バージョン情報VToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem モデルの場所を開くDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem モデルを開きなおすRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 終了QToolStripMenuItem;
        private System.Windows.Forms.CheckedListBox descriptionsCheckedListBox;
        private System.Windows.Forms.Panel panelQuestion;
        private System.Windows.Forms.ListBox candidatesListBox;
        private System.Windows.Forms.Label questionNoPicLabel;
        private System.Windows.Forms.Label questionHasPicLabel;
        private System.Windows.Forms.PictureBox questionPictureBox;
        private System.Windows.Forms.Button trueButton;
        private System.Windows.Forms.Button falseButton;
        private System.Windows.Forms.Label candidatesLabel;
        private System.Windows.Forms.ToolStripMenuItem モデルを開くOToolStripMenuItem;
    }
}

