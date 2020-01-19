namespace MCBEEditor
{
    partial class NewModelDialog
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewModelDialog));
            this.forNameLabel = new System.Windows.Forms.Label();
            this.forSavePathLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.selectFolderButton = new System.Windows.Forms.Button();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.savePathTextBox = new System.Windows.Forms.TextBox();
            this.informationLabel = new System.Windows.Forms.Label();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.panelDialog = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.panelDialog.SuspendLayout();
            this.SuspendLayout();
            // 
            // forNameLabel
            // 
            this.forNameLabel.AutoSize = true;
            this.forNameLabel.Location = new System.Drawing.Point(61, 71);
            this.forNameLabel.Name = "forNameLabel";
            this.forNameLabel.Size = new System.Drawing.Size(29, 12);
            this.forNameLabel.TabIndex = 0;
            this.forNameLabel.Text = "名称";
            // 
            // forSavePathLabel
            // 
            this.forSavePathLabel.AutoSize = true;
            this.forSavePathLabel.Location = new System.Drawing.Point(61, 114);
            this.forSavePathLabel.Name = "forSavePathLabel";
            this.forSavePathLabel.Size = new System.Drawing.Size(41, 12);
            this.forSavePathLabel.TabIndex = 1;
            this.forSavePathLabel.Text = "保存先";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(255, 167);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(115, 23);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "保存(&S)";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(376, 167);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(98, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "キャンセル(&C)";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // selectFolderButton
            // 
            this.selectFolderButton.Location = new System.Drawing.Point(395, 109);
            this.selectFolderButton.Name = "selectFolderButton";
            this.selectFolderButton.Size = new System.Drawing.Size(38, 23);
            this.selectFolderButton.TabIndex = 2;
            this.selectFolderButton.Text = "...";
            this.selectFolderButton.UseVisualStyleBackColor = true;
            this.selectFolderButton.Click += new System.EventHandler(this.selectFolderButton_Click);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(133, 68);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(191, 19);
            this.nameTextBox.TabIndex = 0;
            // 
            // savePathTextBox
            // 
            this.errorProvider.SetIconPadding(this.savePathTextBox, 50);
            this.savePathTextBox.Location = new System.Drawing.Point(133, 111);
            this.savePathTextBox.Name = "savePathTextBox";
            this.savePathTextBox.Size = new System.Drawing.Size(256, 19);
            this.savePathTextBox.TabIndex = 1;
            // 
            // informationLabel
            // 
            this.informationLabel.AutoSize = true;
            this.informationLabel.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.informationLabel.ForeColor = System.Drawing.Color.Indigo;
            this.informationLabel.Location = new System.Drawing.Point(18, 15);
            this.informationLabel.Name = "informationLabel";
            this.informationLabel.Size = new System.Drawing.Size(245, 19);
            this.informationLabel.TabIndex = 7;
            this.informationLabel.Text = "モデルの名称・保存先を指定してください";
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // panelDialog
            // 
            this.panelDialog.BackColor = System.Drawing.SystemColors.Window;
            this.panelDialog.Controls.Add(this.informationLabel);
            this.panelDialog.Controls.Add(this.forNameLabel);
            this.panelDialog.Controls.Add(this.savePathTextBox);
            this.panelDialog.Controls.Add(this.forSavePathLabel);
            this.panelDialog.Controls.Add(this.nameTextBox);
            this.panelDialog.Controls.Add(this.selectFolderButton);
            this.panelDialog.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDialog.Location = new System.Drawing.Point(0, 0);
            this.panelDialog.Name = "panelDialog";
            this.panelDialog.Size = new System.Drawing.Size(486, 161);
            this.panelDialog.TabIndex = 0;
            // 
            // NewModelDialog
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(486, 199);
            this.Controls.Add(this.panelDialog);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewModelDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "新規モデルの作成";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewModelDialog_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.panelDialog.ResumeLayout(false);
            this.panelDialog.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label forNameLabel;
        private System.Windows.Forms.Label forSavePathLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button selectFolderButton;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.TextBox savePathTextBox;
        private System.Windows.Forms.Label informationLabel;
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.Panel panelDialog;
    }
}