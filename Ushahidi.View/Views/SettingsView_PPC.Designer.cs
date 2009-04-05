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
            this.textBoxEmail = new Ushahidi.Common.Controls.LabelTextBox();
            this.textBoxLastName = new Ushahidi.Common.Controls.LabelTextBox();
            this.textBoxFirstName = new Ushahidi.Common.Controls.LabelTextBox();
            this.checkBoxKeyboard = new Ushahidi.Common.Controls.LabelCheckBox();
            this.textBoxLocale = new Ushahidi.Common.Controls.LabelTextBox();
            this.textBoxServer = new Ushahidi.Common.Controls.LabelTextBox();
            this.menuItemDone = new System.Windows.Forms.MenuItem();
            this.menuItemCancel = new System.Windows.Forms.MenuItem();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuItemWebsite
            // 
            this.menuItemWebsite.MenuItems.Add(this.menuItemDone);
            this.menuItemWebsite.MenuItems.Add(this.menuItemCancel);
            this.menuItemWebsite.Text = "Action";
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
            this.panelContent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelContent.Controls.Add(this.textBoxEmail);
            this.panelContent.Controls.Add(this.textBoxLastName);
            this.panelContent.Controls.Add(this.textBoxFirstName);
            this.panelContent.Controls.Add(this.checkBoxKeyboard);
            this.panelContent.Controls.Add(this.textBoxLocale);
            this.panelContent.Controls.Add(this.textBoxServer);
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(240, 294);
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEmail.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxEmail.Bold = true;
            this.textBoxEmail.IsRequired = false;
            this.textBoxEmail.Label = "Email";
            this.textBoxEmail.Location = new System.Drawing.Point(0, 112);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(240, 28);
            this.textBoxEmail.TabIndex = 5;
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLastName.BackColor = System.Drawing.Color.Gainsboro;
            this.textBoxLastName.Bold = true;
            this.textBoxLastName.Label = "Last Name";
            this.textBoxLastName.Location = new System.Drawing.Point(0, 84);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(240, 28);
            this.textBoxLastName.TabIndex = 4;
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFirstName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxFirstName.Bold = true;
            this.textBoxFirstName.IsRequired = false;
            this.textBoxFirstName.Label = "First Name";
            this.textBoxFirstName.Location = new System.Drawing.Point(0, 56);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(240, 28);
            this.textBoxFirstName.TabIndex = 3;
            // 
            // checkBoxKeyboard
            // 
            this.checkBoxKeyboard.BackColor = System.Drawing.Color.Gainsboro;
            this.checkBoxKeyboard.Bold = true;
            this.checkBoxKeyboard.CheckBox = "Auto Show";
            this.checkBoxKeyboard.Label = "Keyboard";
            this.checkBoxKeyboard.Location = new System.Drawing.Point(0, 140);
            this.checkBoxKeyboard.Name = "checkBoxKeyboard";
            this.checkBoxKeyboard.Size = new System.Drawing.Size(240, 28);
            this.checkBoxKeyboard.TabIndex = 2;
            this.checkBoxKeyboard.Click += new System.EventHandler(this.OnKeyboardAutoShow);
            // 
            // textBoxLocale
            // 
            this.textBoxLocale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLocale.BackColor = System.Drawing.Color.Gainsboro;
            this.textBoxLocale.Bold = true;
            this.textBoxLocale.Enabled = false;
            this.textBoxLocale.Label = "Location";
            this.textBoxLocale.Location = new System.Drawing.Point(0, 28);
            this.textBoxLocale.Name = "textBoxLocale";
            this.textBoxLocale.Size = new System.Drawing.Size(240, 28);
            this.textBoxLocale.TabIndex = 1;
            // 
            // textBoxServer
            // 
            this.textBoxServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxServer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxServer.Bold = true;
            this.textBoxServer.IsRequired = true;
            this.textBoxServer.Label = "Server";
            this.textBoxServer.Location = new System.Drawing.Point(0, 0);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.Size = new System.Drawing.Size(240, 28);
            this.textBoxServer.TabIndex = 0;
            // 
            // menuItemDone
            // 
            this.menuItemDone.Text = "Done";
            this.menuItemDone.Click += new System.EventHandler(this.OnDone);
            // 
            // menuItemCancel
            // 
            this.menuItemCancel.Text = "Cancel";
            this.menuItemCancel.Click += new System.EventHandler(this.OnCancel);
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
        private Ushahidi.Common.Controls.LabelTextBox textBoxServer;
        private Ushahidi.Common.Controls.LabelTextBox textBoxLocale;
        private Ushahidi.Common.Controls.LabelCheckBox checkBoxKeyboard;
        private System.Windows.Forms.MenuItem menuItemDone;
        private System.Windows.Forms.MenuItem menuItemCancel;
        private Ushahidi.Common.Controls.LabelTextBox textBoxEmail;
        private Ushahidi.Common.Controls.LabelTextBox textBoxLastName;
        private Ushahidi.Common.Controls.LabelTextBox textBoxFirstName;
    }
}