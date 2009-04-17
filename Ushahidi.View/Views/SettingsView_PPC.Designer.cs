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
            this.panelContent = new System.Windows.Forms.Panel();
            this.comboBoxSettingsLanguages = new Ushahidi.Common.Controls.LabelComboBox();
            this.textBoxSettingsEmail = new Ushahidi.Common.Controls.LabelTextBox();
            this.textBoxSettingsLastName = new Ushahidi.Common.Controls.LabelTextBox();
            this.textBoxSettingsFirstName = new Ushahidi.Common.Controls.LabelTextBox();
            this.checkBoxSettingsKeyboard = new Ushahidi.Common.Controls.LabelCheckBox();
            this.textBoxSettingsServer = new Ushahidi.Common.Controls.LabelTextBox();
            this.menuItemSettingsDone = new System.Windows.Forms.MenuItem();
            this.menuItemSettingsCancel = new System.Windows.Forms.MenuItem();
            this.panelContent.SuspendLayout();
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
            // panelContent
            // 
            this.panelContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContent.AutoScroll = true;
            this.panelContent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelContent.Controls.Add(this.comboBoxSettingsLanguages);
            this.panelContent.Controls.Add(this.textBoxSettingsEmail);
            this.panelContent.Controls.Add(this.textBoxSettingsLastName);
            this.panelContent.Controls.Add(this.textBoxSettingsFirstName);
            this.panelContent.Controls.Add(this.checkBoxSettingsKeyboard);
            this.panelContent.Controls.Add(this.textBoxSettingsServer);
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(240, 294);
            // 
            // comboBoxSettingsLanguages
            // 
            this.comboBoxSettingsLanguages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSettingsLanguages.BackColor = System.Drawing.Color.Gainsboro;
            this.comboBoxSettingsLanguages.Bold = true;
            this.comboBoxSettingsLanguages.DisplayMember = "NativeName";
            this.comboBoxSettingsLanguages.IsRequired = true;
            this.comboBoxSettingsLanguages.Label = "Language";
            this.comboBoxSettingsLanguages.Location = new System.Drawing.Point(0, 28);
            this.comboBoxSettingsLanguages.Name = "comboBoxSettingsLanguages";
            this.comboBoxSettingsLanguages.Size = new System.Drawing.Size(240, 28);
            this.comboBoxSettingsLanguages.TabIndex = 2;
            this.comboBoxSettingsLanguages.ValueMember = "Name";
            // 
            // textBoxSettingsEmail
            // 
            this.textBoxSettingsEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSettingsEmail.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxSettingsEmail.Bold = true;
            this.textBoxSettingsEmail.IsRequired = false;
            this.textBoxSettingsEmail.Label = "Email";
            this.textBoxSettingsEmail.Location = new System.Drawing.Point(0, 112);
            this.textBoxSettingsEmail.Name = "textBoxSettingsEmail";
            this.textBoxSettingsEmail.Size = new System.Drawing.Size(240, 28);
            this.textBoxSettingsEmail.TabIndex = 5;
            // 
            // textBoxSettingsLastName
            // 
            this.textBoxSettingsLastName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSettingsLastName.BackColor = System.Drawing.Color.Gainsboro;
            this.textBoxSettingsLastName.Bold = true;
            this.textBoxSettingsLastName.Label = "Last Name";
            this.textBoxSettingsLastName.Location = new System.Drawing.Point(0, 84);
            this.textBoxSettingsLastName.Name = "textBoxSettingsLastName";
            this.textBoxSettingsLastName.Size = new System.Drawing.Size(240, 28);
            this.textBoxSettingsLastName.TabIndex = 4;
            // 
            // textBoxSettingsFirstName
            // 
            this.textBoxSettingsFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSettingsFirstName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxSettingsFirstName.Bold = true;
            this.textBoxSettingsFirstName.IsRequired = false;
            this.textBoxSettingsFirstName.Label = "First Name";
            this.textBoxSettingsFirstName.Location = new System.Drawing.Point(0, 56);
            this.textBoxSettingsFirstName.Name = "textBoxSettingsFirstName";
            this.textBoxSettingsFirstName.Size = new System.Drawing.Size(240, 28);
            this.textBoxSettingsFirstName.TabIndex = 3;
            // 
            // checkBoxSettingsKeyboard
            // 
            this.checkBoxSettingsKeyboard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxSettingsKeyboard.BackColor = System.Drawing.Color.Gainsboro;
            this.checkBoxSettingsKeyboard.Bold = true;
            this.checkBoxSettingsKeyboard.CheckBox = "Auto Show";
            this.checkBoxSettingsKeyboard.Label = "Keyboard";
            this.checkBoxSettingsKeyboard.Location = new System.Drawing.Point(0, 140);
            this.checkBoxSettingsKeyboard.Name = "checkBoxSettingsKeyboard";
            this.checkBoxSettingsKeyboard.Size = new System.Drawing.Size(240, 28);
            this.checkBoxSettingsKeyboard.TabIndex = 6;
            this.checkBoxSettingsKeyboard.Click += new System.EventHandler(this.OnKeyboardAutoShow);
            // 
            // textBoxSettingsServer
            // 
            this.textBoxSettingsServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSettingsServer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxSettingsServer.Bold = true;
            this.textBoxSettingsServer.IsRequired = true;
            this.textBoxSettingsServer.Label = "Server";
            this.textBoxSettingsServer.Location = new System.Drawing.Point(0, 0);
            this.textBoxSettingsServer.Name = "textBoxSettingsServer";
            this.textBoxSettingsServer.Size = new System.Drawing.Size(240, 28);
            this.textBoxSettingsServer.TabIndex = 1;
            // 
            // menuItemSettingsDone
            // 
            this.menuItemSettingsDone.Text = "Done";
            // 
            // menuItemSettingsCancel
            // 
            this.menuItemSettingsCancel.Text = "Cancel";
            // 
            // SettingsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.panelContent);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsView";
            this.Text = "Settings";
            this.panelContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContent;
        private Ushahidi.Common.Controls.LabelTextBox textBoxSettingsServer;
        private Ushahidi.Common.Controls.LabelCheckBox checkBoxSettingsKeyboard;
        private System.Windows.Forms.MenuItem menuItemSettingsDone;
        private System.Windows.Forms.MenuItem menuItemSettingsCancel;
        private Ushahidi.Common.Controls.LabelTextBox textBoxSettingsEmail;
        private Ushahidi.Common.Controls.LabelTextBox textBoxSettingsLastName;
        private Ushahidi.Common.Controls.LabelTextBox textBoxSettingsFirstName;
        private Ushahidi.Common.Controls.LabelComboBox comboBoxSettingsLanguages;
    }
}