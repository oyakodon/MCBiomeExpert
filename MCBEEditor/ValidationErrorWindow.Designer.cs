namespace MCBEEditor
{
    partial class ValidationErrorWindow
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
            this.panelDialogBody = new System.Windows.Forms.Panel();
            this.forErrorsLabel = new System.Windows.Forms.Label();
            this.detailInfoLabel = new System.Windows.Forms.Label();
            this.iconPictureBox = new System.Windows.Forms.PictureBox();
            this.errorsListBox = new System.Windows.Forms.ListBox();
            this.informationLabel = new System.Windows.Forms.Label();
            this.confirmButton = new System.Windows.Forms.Button();
            this.panelDialogBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panelDialogBody
            // 
            this.panelDialogBody.BackColor = System.Drawing.SystemColors.Window;
            this.panelDialogBody.Controls.Add(this.forErrorsLabel);
            this.panelDialogBody.Controls.Add(this.detailInfoLabel);
            this.panelDialogBody.Controls.Add(this.iconPictureBox);
            this.panelDialogBody.Controls.Add(this.errorsListBox);
            this.panelDialogBody.Controls.Add(this.informationLabel);
            this.panelDialogBody.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDialogBody.Location = new System.Drawing.Point(0, 0);
            this.panelDialogBody.Name = "panelDialogBody";
            this.panelDialogBody.Size = new System.Drawing.Size(592, 293);
            this.panelDialogBody.TabIndex = 1;
            // 
            // forErrorsLabel
            // 
            this.forErrorsLabel.AutoSize = true;
            this.forErrorsLabel.Location = new System.Drawing.Point(100, 117);
            this.forErrorsLabel.Name = "forErrorsLabel";
            this.forErrorsLabel.Size = new System.Drawing.Size(68, 12);
            this.forErrorsLabel.TabIndex = 4;
            this.forErrorsLabel.Text = "エラーの詳細:";
            // 
            // detailInfoLabel
            // 
            this.detailInfoLabel.AutoSize = true;
            this.detailInfoLabel.Location = new System.Drawing.Point(117, 74);
            this.detailInfoLabel.Name = "detailInfoLabel";
            this.detailInfoLabel.Size = new System.Drawing.Size(232, 12);
            this.detailInfoLabel.TabIndex = 3;
            this.detailInfoLabel.Text = "下記のエラーを確認し、設定を変更してください。";
            // 
            // iconPictureBox
            // 
            this.iconPictureBox.Location = new System.Drawing.Point(24, 22);
            this.iconPictureBox.Name = "iconPictureBox";
            this.iconPictureBox.Size = new System.Drawing.Size(48, 48);
            this.iconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconPictureBox.TabIndex = 2;
            this.iconPictureBox.TabStop = false;
            // 
            // errorsListBox
            // 
            this.errorsListBox.FormattingEnabled = true;
            this.errorsListBox.ItemHeight = 12;
            this.errorsListBox.Location = new System.Drawing.Point(102, 134);
            this.errorsListBox.Name = "errorsListBox";
            this.errorsListBox.Size = new System.Drawing.Size(468, 136);
            this.errorsListBox.TabIndex = 1;
            // 
            // informationLabel
            // 
            this.informationLabel.AutoSize = true;
            this.informationLabel.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.informationLabel.ForeColor = System.Drawing.Color.MediumVioletRed;
            this.informationLabel.Location = new System.Drawing.Point(98, 35);
            this.informationLabel.Name = "informationLabel";
            this.informationLabel.Size = new System.Drawing.Size(214, 19);
            this.informationLabel.TabIndex = 0;
            this.informationLabel.Text = "特徴/ルールに設定エラーがあります";
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(449, 299);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(131, 23);
            this.confirmButton.TabIndex = 0;
            this.confirmButton.Text = "OK";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // ValidationErrorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 329);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.panelDialogBody);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ValidationErrorWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "モデル検証エラー";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ValidationErrorWindow_Load);
            this.Shown += new System.EventHandler(this.ValidationErrorWindow_Shown);
            this.panelDialogBody.ResumeLayout(false);
            this.panelDialogBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDialogBody;
        private System.Windows.Forms.Label informationLabel;
        private System.Windows.Forms.ListBox errorsListBox;
        private System.Windows.Forms.PictureBox iconPictureBox;
        private System.Windows.Forms.Label forErrorsLabel;
        private System.Windows.Forms.Label detailInfoLabel;
        private System.Windows.Forms.Button confirmButton;
    }
}