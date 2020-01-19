namespace MCBEIdentifier
{
    partial class ConfigDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigDialog));
            this.panelDialog = new System.Windows.Forms.Panel();
            this.forShortModeLabel = new System.Windows.Forms.Label();
            this.forExtendModeLabel = new System.Windows.Forms.Label();
            this.shortcutModeCheckBox = new System.Windows.Forms.CheckBox();
            this.infomationLabel = new System.Windows.Forms.Label();
            this.extendModeCheckBox = new System.Windows.Forms.CheckBox();
            this.confirmButton = new System.Windows.Forms.Button();
            this.panelDialog.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDialog
            // 
            this.panelDialog.BackColor = System.Drawing.SystemColors.Window;
            this.panelDialog.Controls.Add(this.forShortModeLabel);
            this.panelDialog.Controls.Add(this.forExtendModeLabel);
            this.panelDialog.Controls.Add(this.shortcutModeCheckBox);
            this.panelDialog.Controls.Add(this.infomationLabel);
            this.panelDialog.Controls.Add(this.extendModeCheckBox);
            this.panelDialog.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDialog.Location = new System.Drawing.Point(0, 0);
            this.panelDialog.Name = "panelDialog";
            this.panelDialog.Size = new System.Drawing.Size(329, 136);
            this.panelDialog.TabIndex = 0;
            // 
            // forShortModeLabel
            // 
            this.forShortModeLabel.AutoSize = true;
            this.forShortModeLabel.Location = new System.Drawing.Point(158, 88);
            this.forShortModeLabel.Name = "forShortModeLabel";
            this.forShortModeLabel.Size = new System.Drawing.Size(116, 24);
            this.forShortModeLabel.TabIndex = 5;
            this.forShortModeLabel.Text = ": 全て当てはまる項目が\r\n  出た時点で判別終了";
            // 
            // forExtendModeLabel
            // 
            this.forExtendModeLabel.AutoSize = true;
            this.forExtendModeLabel.Location = new System.Drawing.Point(158, 60);
            this.forExtendModeLabel.Name = "forExtendModeLabel";
            this.forExtendModeLabel.Size = new System.Drawing.Size(124, 12);
            this.forExtendModeLabel.TabIndex = 4;
            this.forExtendModeLabel.Text = ": 選択履歴と候補を表示";
            // 
            // shortcutModeCheckBox
            // 
            this.shortcutModeCheckBox.AutoSize = true;
            this.shortcutModeCheckBox.Location = new System.Drawing.Point(48, 87);
            this.shortcutModeCheckBox.Name = "shortcutModeCheckBox";
            this.shortcutModeCheckBox.Size = new System.Drawing.Size(100, 16);
            this.shortcutModeCheckBox.TabIndex = 3;
            this.shortcutModeCheckBox.Text = "短絡判別モード";
            this.shortcutModeCheckBox.UseVisualStyleBackColor = true;
            // 
            // infomationLabel
            // 
            this.infomationLabel.AutoSize = true;
            this.infomationLabel.Font = new System.Drawing.Font("Meiryo UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.infomationLabel.ForeColor = System.Drawing.Color.Indigo;
            this.infomationLabel.Location = new System.Drawing.Point(15, 15);
            this.infomationLabel.Name = "infomationLabel";
            this.infomationLabel.Size = new System.Drawing.Size(179, 19);
            this.infomationLabel.TabIndex = 2;
            this.infomationLabel.Text = "実行モードを選択してください";
            // 
            // extendModeCheckBox
            // 
            this.extendModeCheckBox.AutoSize = true;
            this.extendModeCheckBox.Location = new System.Drawing.Point(48, 59);
            this.extendModeCheckBox.Name = "extendModeCheckBox";
            this.extendModeCheckBox.Size = new System.Drawing.Size(76, 16);
            this.extendModeCheckBox.TabIndex = 1;
            this.extendModeCheckBox.Text = "拡張モード";
            this.extendModeCheckBox.UseVisualStyleBackColor = true;
            // 
            // confirmButton
            // 
            this.confirmButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.confirmButton.Location = new System.Drawing.Point(242, 142);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(75, 23);
            this.confirmButton.TabIndex = 0;
            this.confirmButton.Text = "OK";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // ConfigDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 172);
            this.Controls.Add(this.panelDialog);
            this.Controls.Add(this.confirmButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "設定";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigDialog_FormClosing);
            this.panelDialog.ResumeLayout(false);
            this.panelDialog.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDialog;
        private System.Windows.Forms.CheckBox shortcutModeCheckBox;
        private System.Windows.Forms.Label infomationLabel;
        private System.Windows.Forms.CheckBox extendModeCheckBox;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Label forShortModeLabel;
        private System.Windows.Forms.Label forExtendModeLabel;
    }
}