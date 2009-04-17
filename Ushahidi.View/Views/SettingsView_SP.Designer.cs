namespace Ushahidi.View.Views
{
    partial class SettingsView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsView));
            this.textBoxSettingsServer = new Ushahidi.Common.Controls.LabelTextBox();
            this.menuItemSettingsDone = new System.Windows.Forms.MenuItem();
            this.menuItemSettingsCancel = new System.Windows.Forms.MenuItem();
            this.textBoxSettingsEmail = new Ushahidi.Common.Controls.LabelTextBox();
            this.textBoxSettingsLastName = new Ushahidi.Common.Controls.LabelTextBox();
            this.textBoxSettingsFirstName = new Ushahidi.Common.Controls.LabelTextBox();
            this.comboBoxSettingsLanguages = new Ushahidi.Common.Controls.LabelComboBox();
            this.SuspendLayout();
            // 
            // menuItemAction
            // 
            this.menuItemAction.MenuItems.Add(this.menuItemSettingsDone);
            this.menuItemAction.MenuItems.Add(this.menuItemSettingsCancel);
            this.menuItemAction.Text = "Action";
            // 
            // menuItemSettings
            // 
            this.menuItemSettings.Enabled = false;
            // 
            // textBoxServer
            // 
            this.textBoxSettingsServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSettingsServer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxSettingsServer.IsRequired = true;
            this.textBoxSettingsServer.Label = "Server";
            this.textBoxSettingsServer.Location = new System.Drawing.Point(0, 0);
            this.textBoxSettingsServer.Name = "textBoxServer";
            this.textBoxSettingsServer.Size = new System.Drawing.Size(176, 28);
            this.textBoxSettingsServer.TabIndex = 1;
            // 
            // menuItemDone
            // 
            this.menuItemSettingsDone.Text = "Done";
            // 
            // menuItemCancel
            // 
            this.menuItemSettingsCancel.Text = "Cancel";
            // 
            // textBoxEmail
            // 
            this.textBoxSettingsEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSettingsEmail.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxSettingsEmail.Bold = true;
            this.textBoxSettingsEmail.IsRequired = false;
            this.textBoxSettingsEmail.Label = "Email";
            this.textBoxSettingsEmail.Location = new System.Drawing.Point(0, 112);
            this.textBoxSettingsEmail.Name = "textBoxEmail";
            this.textBoxSettingsEmail.Size = new System.Drawing.Size(176, 28);
            this.textBoxSettingsEmail.TabIndex = 5;
            // 
            // textBoxLastName
            // 
            this.textBoxSettingsLastName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSettingsLastName.BackColor = System.Drawing.Color.Gainsboro;
            this.textBoxSettingsLastName.Bold = true;
            this.textBoxSettingsLastName.Label = "Last Name";
            this.textBoxSettingsLastName.Location = new System.Drawing.Point(0, 84);
            this.textBoxSettingsLastName.Name = "textBoxLastName";
            this.textBoxSettingsLastName.Size = new System.Drawing.Size(176, 28);
            this.textBoxSettingsLastName.TabIndex = 4;
            // 
            // textBoxFirstName
            // 
            this.textBoxSettingsFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSettingsFirstName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxSettingsFirstName.Bold = true;
            this.textBoxSettingsFirstName.IsRequired = false;
            this.textBoxSettingsFirstName.Label = "First Name";
            this.textBoxSettingsFirstName.Location = new System.Drawing.Point(0, 56);
            this.textBoxSettingsFirstName.Name = "textBoxFirstName";
            this.textBoxSettingsFirstName.Size = new System.Drawing.Size(176, 28);
            this.textBoxSettingsFirstName.TabIndex = 3;
            // 
            // comboBoxLanguages
            // 
            this.comboBoxSettingsLanguages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSettingsLanguages.BackColor = System.Drawing.Color.Gainsboro;
            this.comboBoxSettingsLanguages.Bold = true;
            this.comboBoxSettingsLanguages.DisplayMember = "NativeName";
            this.comboBoxSettingsLanguages.IsRequired = true;
            this.comboBoxSettingsLanguages.Label = "Language";
            this.comboBoxSettingsLanguages.Location = new System.Drawing.Point(0, 28);
            this.comboBoxSettingsLanguages.Name = "comboBoxLanguages";
            this.comboBoxSettingsLanguages.Size = new System.Drawing.Size(176, 28);
            this.comboBoxSettingsLanguages.TabIndex = 2;
            this.comboBoxSettingsLanguages.ValueMember = "Name";
            // 
            // SettingsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(176, 180);
            this.Controls.Add(this.comboBoxSettingsLanguages);
            this.Controls.Add(this.textBoxSettingsEmail);
            this.Controls.Add(this.textBoxSettingsLastName);
            this.Controls.Add(this.textBoxSettingsFirstName);
            this.Controls.Add(this.textBoxSettingsServer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsView";
            this.Text = "Settings";
            this.ResumeLayout(false);

        }

        #endregion

        private Ushahidi.Common.Controls.LabelTextBox textBoxSettingsServer;
        private System.Windows.Forms.MenuItem menuItemSettingsDone;
        private System.Windows.Forms.MenuItem menuItemSettingsCancel;
        private Ushahidi.Common.Controls.LabelTextBox textBoxSettingsEmail;
        private Ushahidi.Common.Controls.LabelTextBox textBoxSettingsLastName;
        private Ushahidi.Common.Controls.LabelTextBox textBoxSettingsFirstName;
        private Ushahidi.Common.Controls.LabelComboBox comboBoxSettingsLanguages;

    }
}