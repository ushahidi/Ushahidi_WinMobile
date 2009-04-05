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
            this.textBoxLocale = new Ushahidi.Common.Controls.LabelTextBox();
            this.textBoxServer = new Ushahidi.Common.Controls.LabelTextBox();
            this.menuItemDone = new System.Windows.Forms.MenuItem();
            this.menuItemCancel = new System.Windows.Forms.MenuItem();
            this.textBoxEmail = new Ushahidi.Common.Controls.LabelTextBox();
            this.textBoxLastName = new Ushahidi.Common.Controls.LabelTextBox();
            this.textBoxFirstName = new Ushahidi.Common.Controls.LabelTextBox();
            this.SuspendLayout();
            // 
            // menuItemSettings
            // 
            this.menuItemSettings.Enabled = false;
            // 
            // menuItemAction
            // 
            this.menuItemAction.MenuItems.Add(this.menuItemDone);
            this.menuItemAction.MenuItems.Add(this.menuItemCancel);
            this.menuItemAction.Text = "Action";
            // 
            // textBoxLocale
            // 
            this.textBoxLocale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLocale.BackColor = System.Drawing.Color.Gainsboro;
            this.textBoxLocale.Enabled = false;
            this.textBoxLocale.Label = "Location";
            this.textBoxLocale.Location = new System.Drawing.Point(0, 28);
            this.textBoxLocale.Name = "textBoxLocale";
            this.textBoxLocale.Size = new System.Drawing.Size(176, 28);
            this.textBoxLocale.TabIndex = 3;
            // 
            // textBoxServer
            // 
            this.textBoxServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxServer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxServer.IsRequired = true;
            this.textBoxServer.Label = "Server";
            this.textBoxServer.Location = new System.Drawing.Point(0, 0);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.Size = new System.Drawing.Size(176, 28);
            this.textBoxServer.TabIndex = 2;
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
            this.textBoxEmail.Size = new System.Drawing.Size(176, 28);
            this.textBoxEmail.TabIndex = 8;
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
            this.textBoxLastName.Size = new System.Drawing.Size(176, 28);
            this.textBoxLastName.TabIndex = 7;
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
            this.textBoxFirstName.Size = new System.Drawing.Size(176, 28);
            this.textBoxFirstName.TabIndex = 6;
            // 
            // SettingsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(176, 180);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.textBoxLastName);
            this.Controls.Add(this.textBoxFirstName);
            this.Controls.Add(this.textBoxLocale);
            this.Controls.Add(this.textBoxServer);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsView";
            this.Text = "Settings";
            this.ResumeLayout(false);

        }

        #endregion

        private Ushahidi.Common.Controls.LabelTextBox textBoxLocale;
        private Ushahidi.Common.Controls.LabelTextBox textBoxServer;
        private System.Windows.Forms.MenuItem menuItemDone;
        private System.Windows.Forms.MenuItem menuItemCancel;
        private Ushahidi.Common.Controls.LabelTextBox textBoxEmail;
        private Ushahidi.Common.Controls.LabelTextBox textBoxLastName;
        private Ushahidi.Common.Controls.LabelTextBox textBoxFirstName;

    }
}