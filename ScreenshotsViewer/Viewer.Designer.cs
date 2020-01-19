namespace ScreenshotsViewer
{
    partial class Viewer
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Viewer));
            this.tbDataFolder = new System.Windows.Forms.TextBox();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listImages = new System.Windows.Forms.ListBox();
            this.picBoxImage = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ファイルFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.データフォルダを開くDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mCスクリーンショットフォルダを開くSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.終了XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listBiomes = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxImage)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbDataFolder
            // 
            this.tbDataFolder.Location = new System.Drawing.Point(94, 40);
            this.tbDataFolder.Name = "tbDataFolder";
            this.tbDataFolder.Size = new System.Drawing.Size(320, 19);
            this.tbDataFolder.TabIndex = 0;
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Location = new System.Drawing.Point(438, 38);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(75, 23);
            this.btnSelectFolder.TabIndex = 1;
            this.btnSelectFolder.Text = "参照";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "データフォルダ";
            // 
            // listImages
            // 
            this.listImages.Enabled = false;
            this.listImages.FormattingEnabled = true;
            this.listImages.HorizontalScrollbar = true;
            this.listImages.ItemHeight = 12;
            this.listImages.Location = new System.Drawing.Point(177, 75);
            this.listImages.Name = "listImages";
            this.listImages.Size = new System.Drawing.Size(171, 328);
            this.listImages.TabIndex = 6;
            this.listImages.SelectedIndexChanged += new System.EventHandler(this.listImages_SelectedIndexChanged);
            // 
            // picBoxImage
            // 
            this.picBoxImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBoxImage.Location = new System.Drawing.Point(354, 75);
            this.picBoxImage.Name = "picBoxImage";
            this.picBoxImage.Size = new System.Drawing.Size(383, 328);
            this.picBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picBoxImage.TabIndex = 7;
            this.picBoxImage.TabStop = false;
            this.picBoxImage.WaitOnLoad = true;
            this.picBoxImage.DoubleClick += new System.EventHandler(this.picBoxImage_DoubleClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 418);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(749, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.Stretch = false;
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルFToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(749, 27);
            this.menuStrip1.Stretch = false;
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ファイルFToolStripMenuItem
            // 
            this.ファイルFToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.データフォルダを開くDToolStripMenuItem,
            this.mCスクリーンショットフォルダを開くSToolStripMenuItem,
            this.終了XToolStripMenuItem});
            this.ファイルFToolStripMenuItem.Name = "ファイルFToolStripMenuItem";
            this.ファイルFToolStripMenuItem.Size = new System.Drawing.Size(77, 23);
            this.ファイルFToolStripMenuItem.Text = "ファイル(&F)";
            // 
            // データフォルダを開くDToolStripMenuItem
            // 
            this.データフォルダを開くDToolStripMenuItem.Name = "データフォルダを開くDToolStripMenuItem";
            this.データフォルダを開くDToolStripMenuItem.Size = new System.Drawing.Size(281, 24);
            this.データフォルダを開くDToolStripMenuItem.Text = "データフォルダを開く(&D)";
            this.データフォルダを開くDToolStripMenuItem.Click += new System.EventHandler(this.データフォルダを開くDToolStripMenuItem_Click);
            // 
            // mCスクリーンショットフォルダを開くSToolStripMenuItem
            // 
            this.mCスクリーンショットフォルダを開くSToolStripMenuItem.Name = "mCスクリーンショットフォルダを開くSToolStripMenuItem";
            this.mCスクリーンショットフォルダを開くSToolStripMenuItem.Size = new System.Drawing.Size(281, 24);
            this.mCスクリーンショットフォルダを開くSToolStripMenuItem.Text = "MCスクリーンショットフォルダを開く(&S)";
            this.mCスクリーンショットフォルダを開くSToolStripMenuItem.Click += new System.EventHandler(this.mCスクリーンショットフォルダを開くSToolStripMenuItem_Click);
            // 
            // 終了XToolStripMenuItem
            // 
            this.終了XToolStripMenuItem.Name = "終了XToolStripMenuItem";
            this.終了XToolStripMenuItem.Size = new System.Drawing.Size(281, 24);
            this.終了XToolStripMenuItem.Text = "終了(&X)";
            this.終了XToolStripMenuItem.Click += new System.EventHandler(this.終了XToolStripMenuItem_Click);
            // 
            // listBiomes
            // 
            this.listBiomes.Enabled = false;
            this.listBiomes.FormattingEnabled = true;
            this.listBiomes.ItemHeight = 12;
            this.listBiomes.Location = new System.Drawing.Point(14, 75);
            this.listBiomes.Name = "listBiomes";
            this.listBiomes.Size = new System.Drawing.Size(157, 328);
            this.listBiomes.TabIndex = 10;
            this.listBiomes.SelectedIndexChanged += new System.EventHandler(this.listBiomes_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(363, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "(ダブルクリックで拡大)";
            this.label2.Visible = false;
            // 
            // Viewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 440);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listBiomes);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.picBoxImage);
            this.Controls.Add(this.listImages);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSelectFolder);
            this.Controls.Add(this.tbDataFolder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Viewer";
            this.Text = "MCBiomeExpert ScreenShots Viewer";
            this.Load += new System.EventHandler(this.Viewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxImage)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbDataFolder;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listImages;
        private System.Windows.Forms.PictureBox picBoxImage;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ファイルFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem データフォルダを開くDToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mCスクリーンショットフォルダを開くSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 終了XToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ListBox listBiomes;
        private System.Windows.Forms.Label label2;
    }
}

