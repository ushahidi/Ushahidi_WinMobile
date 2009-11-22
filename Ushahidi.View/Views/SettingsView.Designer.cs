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
            this.comboBoxLocales = new Ushahidi.Common.Controls.LabelComboBox();
            this.textBoxVersion = new Ushahidi.Common.Controls.LabelTextBox();
            this.comboBoxMapType = new Ushahidi.Common.Controls.LabelComboBox();
            this.checkBoxKeyboard = new Ushahidi.Common.Controls.LabelCheckBox();
            this.comboBoxLanguages = new Ushahidi.Common.Controls.LabelComboBox();
            this.textBoxEmail = new Ushahidi.Common.Controls.LabelTextBox();
            this.textBoxLastName = new Ushahidi.Common.Controls.LabelTextBox();
            this.textBoxFirstName = new Ushahidi.Common.Controls.LabelTextBox();
            this.menuItemDone = new System.Windows.Forms.MenuItem();
            this.menuItemClear = new System.Windows.Forms.MenuItem();
            this.menuItemSeparator = new System.Windows.Forms.MenuItem();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuItemAction
            // 
            this.menuItemAction.MenuItems.Add(this.menuItemClear);
            this.menuItemAction.MenuItems.Add(this.menuItemSeparator);
            this.menuItemAction.MenuItems.Add(this.menuItemDone);
            this.menuItemAction.Text = "Action";
            // 
            // panelContent
            // 
            this.panelContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContent.AutoScroll = true;
            this.panelContent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelContent.Controls.Add(this.comboBoxLocales);
            this.panelContent.Controls.Add(this.textBoxVersion);
            this.panelContent.Controls.Add(this.comboBoxMapType);
            this.panelContent.Controls.Add(this.checkBoxKeyboard);
            this.panelContent.Controls.Add(this.comboBoxLanguages);
            this.panelContent.Controls.Add(this.textBoxEmail);
            this.panelContent.Controls.Add(this.textBoxLastName);
            this.panelContent.Controls.Add(this.textBoxFirstName);
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(176, 180);
            // 
            // comboBoxLocales
            // 
            this.comboBoxLocales.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxLocales.Bold = true;
            this.comboBoxLocales.DataSource = null;
            this.comboBoxLocales.DisplayMember = "";
            this.comboBoxLocales.IsRequired = false;
            this.comboBoxLocales.Label = "Default Location";
            this.comboBoxLocales.Location = new System.Drawing.Point(0, 135);
            this.comboBoxLocales.Name = "comboBoxLocales";
            this.comboBoxLocales.SelectedIndex = -1;
            this.comboBoxLocales.SelectedItem = null;
            this.comboBoxLocales.SelectedText = "";
            this.comboBoxLocales.Size = new System.Drawing.Size(169, 45);
            this.comboBoxLocales.TabIndex = 3;
            this.comboBoxLocales.ValueMember = "";
            // 
            // textBoxVersion
            // 
            this.textBoxVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxVersion.BackColor = System.Drawing.Color.Gainsboro;
            this.textBoxVersion.Enabled = false;
            this.textBoxVersion.IsRequired = false;
            this.textBoxVersion.Label = "Version";
            this.textBoxVersion.Location = new System.Drawing.Point(0, 0);
            this.textBoxVersion.Multiline = false;
            this.textBoxVersion.Name = "textBoxVersion";
            this.textBoxVersion.Size = new System.Drawing.Size(169, 45);
            this.textBoxVersion.TabIndex = 0;
            this.textBoxVersion.TabStop = false;
            this.textBoxVersion.Value = "";
            // 
            // comboBoxMapType
            // 
            this.comboBoxMapType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxMapType.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboBoxMapType.Bold = true;
            this.comboBoxMapType.DataSource = null;
            this.comboBoxMapType.DisplayMember = "NativeName";
            this.comboBoxMapType.IsRequired = true;
            this.comboBoxMapType.Label = "Map Type";
            this.comboBoxMapType.Location = new System.Drawing.Point(0, 90);
            this.comboBoxMapType.Name = "comboBoxMapType";
            this.comboBoxMapType.SelectedIndex = -1;
            this.comboBoxMapType.SelectedItem = null;
            this.comboBoxMapType.SelectedText = "";
            this.comboBoxMapType.Size = new System.Drawing.Size(169, 45);
            this.comboBoxMapType.TabIndex = 2;
            this.comboBoxMapType.ValueMember = "Name";
            // 
            // checkBoxKeyboard
            // 
            this.checkBoxKeyboard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxKeyboard.BackColor = System.Drawing.Color.WhiteSmoke;
            this.checkBoxKeyboard.CheckBox = "Auto Show";
            this.checkBoxKeyboard.Checked = false;
            this.checkBoxKeyboard.Label = "Keyboard";
            this.checkBoxKeyboard.Location = new System.Drawing.Point(0, 315);
            this.checkBoxKeyboard.Name = "checkBoxKeyboard";
            this.checkBoxKeyboard.Size = new System.Drawing.Size(169, 45);
            this.checkBoxKeyboard.TabIndex = 7;
            // 
            // comboBoxLanguages
            // 
            this.comboBoxLanguages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxLanguages.BackColor = System.Drawing.Color.Gainsboro;
            this.comboBoxLanguages.Bold = true;
            this.comboBoxLanguages.DataSource = null;
            this.comboBoxLanguages.DisplayMember = "NativeName";
            this.comboBoxLanguages.IsRequired = true;
            this.comboBoxLanguages.Label = "Language";
            this.comboBoxLanguages.Location = new System.Drawing.Point(0, 45);
            this.comboBoxLanguages.Name = "comboBoxLanguages";
            this.comboBoxLanguages.SelectedIndex = -1;
            this.comboBoxLanguages.SelectedItem = null;
            this.comboBoxLanguages.SelectedText = "";
            this.comboBoxLanguages.Size = new System.Drawing.Size(169, 45);
            this.comboBoxLanguages.TabIndex = 1;
            this.comboBoxLanguages.ValueMember = "Name";
            this.comboBoxLanguages.SelectedIndexChanged += new System.EventHandler(this.OnLanguageChanged);
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxEmail.BackColor = System.Drawing.Color.Gainsboro;
            this.textBoxEmail.IsRequired = false;
            this.textBoxEmail.Label = "Email";
            this.textBoxEmail.Location = new System.Drawing.Point(0, 270);
            this.textBoxEmail.Multiline = false;
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(169, 45);
            this.textBoxEmail.TabIndex = 6;
            this.textBoxEmail.Value = "";
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLastName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxLastName.IsRequired = false;
            this.textBoxLastName.Label = "Last Name";
            this.textBoxLastName.Location = new System.Drawing.Point(0, 225);
            this.textBoxLastName.Multiline = false;
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.Size = new System.Drawing.Size(169, 45);
            this.textBoxLastName.TabIndex = 5;
            this.textBoxLastName.Value = "";
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFirstName.BackColor = System.Drawing.Color.Gainsboro;
            this.textBoxFirstName.IsRequired = false;
            this.textBoxFirstName.Label = "First Name";
            this.textBoxFirstName.Location = new System.Drawing.Point(0, 180);
            this.textBoxFirstName.Multiline = false;
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.Size = new System.Drawing.Size(169, 45);
            this.textBoxFirstName.TabIndex = 4;
            this.textBoxFirstName.Value = "";
            // 
            // menuItemDone
            // 
            this.menuItemDone.Text = "Done";
            this.menuItemDone.Click += new System.EventHandler(this.OnDone);
            // 
            // menuItemClear
            // 
            this.menuItemClear.Text = "Clear Cache Files";
            this.menuItemClear.Click += new System.EventHandler(this.OnClearCache);
            // 
            // menuItemSeparator
            // 
            this.menuItemSeparator.Text = "-";
            // 
            // SettingsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(176, 180);
            this.Controls.Add(this.panelContent);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsView";
            this.Text = "Settings";
            this.panelContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContent;
        private Ushahidi.Common.Controls.LabelCheckBox checkBoxKeyboard;
        private Ushahidi.Common.Controls.LabelComboBox comboBoxLanguages;
        private Ushahidi.Common.Controls.LabelTextBox textBoxEmail;
        private Ushahidi.Common.Controls.LabelTextBox textBoxLastName;
        private Ushahidi.Common.Controls.LabelTextBox textBoxFirstName;
        private Ushahidi.Common.Controls.LabelComboBox comboBoxMapType;
        private System.Windows.Forms.MenuItem menuItemDone;
        private System.Windows.Forms.MenuItem menuItemClear;
        private System.Windows.Forms.MenuItem menuItemSeparator;
        private Ushahidi.Common.Controls.LabelTextBox textBoxVersion;
        private Ushahidi.Common.Controls.LabelComboBox comboBoxLocales;

    }
}