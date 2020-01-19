namespace MCBEEditor
{
    partial class AboutVersionDialog
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
            this.iconPictureBox = new System.Windows.Forms.PictureBox();
            this.titleLabel = new System.Windows.Forms.Label();
            this.confirmButton = new System.Windows.Forms.Button();
            this.panelDialog = new System.Windows.Forms.Panel();
            this.forGithubLinkLabel = new System.Windows.Forms.Label();
            this.forVersionLabel = new System.Windows.Forms.Label();
            this.copyrightLabel = new System.Windows.Forms.Label();
            this.versionLabel = new System.Windows.Forms.Label();
            this.githubLinkLabel = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).BeginInit();
            this.panelDialog.SuspendLayout();
            this.SuspendLayout();
            // 
            // iconPictureBox
            // 
            this.iconPictureBox.Location = new System.Drawing.Point(20, 20);
            this.iconPictureBox.Name = "iconPictureBox";
            this.iconPictureBox.Size = new System.Drawing.Size(48, 48);
            this.iconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconPictureBox.TabIndex = 0;
            this.iconPictureBox.TabStop = false;
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(97, 20);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(11, 12);
            this.titleLabel.TabIndex = 1;
            this.titleLabel.Text = "-";
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(352, 134);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(91, 23);
            this.confirmButton.TabIndex = 0;
            this.confirmButton.Text = "OK";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // panelDialog
            // 
            this.panelDialog.BackColor = System.Drawing.SystemColors.Window;
            this.panelDialog.Controls.Add(this.githubLinkLabel);
            this.panelDialog.Controls.Add(this.forGithubLinkLabel);
            this.panelDialog.Controls.Add(this.forVersionLabel);
            this.panelDialog.Controls.Add(this.copyrightLabel);
            this.panelDialog.Controls.Add(this.versionLabel);
            this.panelDialog.Controls.Add(this.iconPictureBox);
            this.panelDialog.Controls.Add(this.titleLabel);
            this.panelDialog.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDialog.Location = new System.Drawing.Point(0, 0);
            this.panelDialog.Name = "panelDialog";
            this.panelDialog.Size = new System.Drawing.Size(455, 128);
            this.panelDialog.TabIndex = 3;
            // 
            // forGithubLinkLabel
            // 
            this.forGithubLinkLabel.AutoSize = true;
            this.forGithubLinkLabel.Location = new System.Drawing.Point(97, 72);
            this.forGithubLinkLabel.Name = "forGithubLinkLabel";
            this.forGithubLinkLabel.Size = new System.Drawing.Size(42, 12);
            this.forGithubLinkLabel.TabIndex = 5;
            this.forGithubLinkLabel.Text = "GitHub:";
            this.forGithubLinkLabel.Visible = false;
            // 
            // forVersionLabel
            // 
            this.forVersionLabel.AutoSize = true;
            this.forVersionLabel.Location = new System.Drawing.Point(106, 42);
            this.forVersionLabel.Name = "forVersionLabel";
            this.forVersionLabel.Size = new System.Drawing.Size(46, 12);
            this.forVersionLabel.TabIndex = 4;
            this.forVersionLabel.Text = "Version:";
            // 
            // copyrightLabel
            // 
            this.copyrightLabel.AutoSize = true;
            this.copyrightLabel.Location = new System.Drawing.Point(97, 102);
            this.copyrightLabel.Name = "copyrightLabel";
            this.copyrightLabel.Size = new System.Drawing.Size(11, 12);
            this.copyrightLabel.TabIndex = 3;
            this.copyrightLabel.Text = "-";
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.Location = new System.Drawing.Point(156, 42);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(11, 12);
            this.versionLabel.TabIndex = 2;
            this.versionLabel.Text = "-";
            // 
            // githubLinkLabel
            // 
            this.githubLinkLabel.AutoSize = true;
            this.githubLinkLabel.Location = new System.Drawing.Point(145, 72);
            this.githubLinkLabel.Name = "githubLinkLabel";
            this.githubLinkLabel.Size = new System.Drawing.Size(11, 12);
            this.githubLinkLabel.TabIndex = 7;
            this.githubLinkLabel.TabStop = true;
            this.githubLinkLabel.Text = "-";
            this.githubLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.githubLinkLabel_LinkClicked);
            // 
            // AboutVersionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 166);
            this.Controls.Add(this.panelDialog);
            this.Controls.Add(this.confirmButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutVersionDialog";
            this.ShowInTaskbar = false;
            this.Text = "About";
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).EndInit();
            this.panelDialog.ResumeLayout(false);
            this.panelDialog.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox iconPictureBox;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Panel panelDialog;
        private System.Windows.Forms.Label copyrightLabel;
        private System.Windows.Forms.Label versionLabel;
        private System.Windows.Forms.Label forVersionLabel;
        private System.Windows.Forms.Label forGithubLinkLabel;
        private System.Windows.Forms.LinkLabel githubLinkLabel;
    }
}