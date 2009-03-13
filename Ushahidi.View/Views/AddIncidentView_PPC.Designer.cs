namespace Ushahidi.View.Views
{
    partial class AddIncidentView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddIncidentView));
            this.menuItemSave = new System.Windows.Forms.MenuItem();
            this.menuItemAddPhoto = new System.Windows.Forms.MenuItem();
            this.menuItemCancel = new System.Windows.Forms.MenuItem();
            this.panelContent = new System.Windows.Forms.Panel();
            this.images = new Ushahidi.Common.Controls.LabelImages();
            this.textBoxDescription = new Ushahidi.Common.Controls.LabelTextBox();
            this.textBoxDate = new Ushahidi.Common.Controls.LabelTextBox();
            this.comboBoxLocale = new Ushahidi.Common.Controls.LabelComboBox();
            this.comboBoxType = new Ushahidi.Common.Controls.LabelComboBox();
            this.textBoxTitle = new Ushahidi.Common.Controls.LabelTextBox();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuItemWebsite
            // 
            this.menuItemWebsite.MenuItems.Add(this.menuItemSave);
            this.menuItemWebsite.MenuItems.Add(this.menuItemAddPhoto);
            this.menuItemWebsite.MenuItems.Add(this.menuItemCancel);
            this.menuItemWebsite.Text = "Action";
            // 
            // menuItemAddIncident
            // 
            this.menuItemAddIncident.Enabled = false;
            // 
            // menuItemSave
            // 
            this.menuItemSave.Text = "Save Incident";
            this.menuItemSave.Click += new System.EventHandler(this.OnSaveIncident);
            // 
            // menuItemAddPhoto
            // 
            this.menuItemAddPhoto.Text = "Add Photo";
            this.menuItemAddPhoto.Click += new System.EventHandler(this.OnAddPhoto);
            // 
            // menuItemCancel
            // 
            this.menuItemCancel.Text = "Cancel";
            this.menuItemCancel.Click += new System.EventHandler(this.OnCancel);
            // 
            // panelContent
            // 
            this.panelContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContent.AutoScroll = true;
            this.panelContent.Controls.Add(this.images);
            this.panelContent.Controls.Add(this.textBoxDescription);
            this.panelContent.Controls.Add(this.textBoxDate);
            this.panelContent.Controls.Add(this.comboBoxLocale);
            this.panelContent.Controls.Add(this.comboBoxType);
            this.panelContent.Controls.Add(this.textBoxTitle);
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(240, 268);
            // 
            // images
            // 
            this.images.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.images.BackColor = System.Drawing.Color.Gainsboro;
            this.images.Bold = true;
            this.images.Label = "Photos";
            this.images.Location = new System.Drawing.Point(0, 192);
            this.images.Name = "images";
            this.images.Size = new System.Drawing.Size(240, 76);
            this.images.TabIndex = 34;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDescription.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxDescription.Bold = true;
            this.textBoxDescription.Label = "Description";
            this.textBoxDescription.Location = new System.Drawing.Point(0, 112);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(240, 80);
            this.textBoxDescription.TabIndex = 33;
            // 
            // textBoxDate
            // 
            this.textBoxDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDate.BackColor = System.Drawing.Color.Gainsboro;
            this.textBoxDate.Bold = true;
            this.textBoxDate.Enabled = false;
            this.textBoxDate.Label = "Date";
            this.textBoxDate.Location = new System.Drawing.Point(0, 84);
            this.textBoxDate.Multiline = false;
            this.textBoxDate.Name = "textBoxDate";
            this.textBoxDate.Size = new System.Drawing.Size(240, 28);
            this.textBoxDate.TabIndex = 32;
            // 
            // comboBoxLocale
            // 
            this.comboBoxLocale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxLocale.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboBoxLocale.Bold = true;
            this.comboBoxLocale.Label = "Location";
            this.comboBoxLocale.Location = new System.Drawing.Point(0, 56);
            this.comboBoxLocale.Name = "comboBoxLocale";
            this.comboBoxLocale.Size = new System.Drawing.Size(240, 28);
            this.comboBoxLocale.TabIndex = 31;
            // 
            // comboBoxType
            // 
            this.comboBoxType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxType.BackColor = System.Drawing.Color.Gainsboro;
            this.comboBoxType.Bold = true;
            this.comboBoxType.Label = "Type";
            this.comboBoxType.Location = new System.Drawing.Point(0, 28);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(240, 28);
            this.comboBoxType.TabIndex = 30;
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTitle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxTitle.Bold = true;
            this.textBoxTitle.Label = "Title";
            this.textBoxTitle.Location = new System.Drawing.Point(0, 0);
            this.textBoxTitle.Multiline = false;
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(240, 28);
            this.textBoxTitle.TabIndex = 29;
            // 
            // AddIncidentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.panelContent);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddIncidentView";
            this.Text = "Add Incident";
            this.panelContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem menuItemSave;
        private System.Windows.Forms.MenuItem menuItemAddPhoto;
        private System.Windows.Forms.MenuItem menuItemCancel;
        private System.Windows.Forms.Panel panelContent;
        private Ushahidi.Common.Controls.LabelImages images;
        private Ushahidi.Common.Controls.LabelTextBox textBoxDescription;
        private Ushahidi.Common.Controls.LabelTextBox textBoxDate;
        private Ushahidi.Common.Controls.LabelComboBox comboBoxLocale;
        private Ushahidi.Common.Controls.LabelComboBox comboBoxType;
        private Ushahidi.Common.Controls.LabelTextBox textBoxTitle;
    }
}