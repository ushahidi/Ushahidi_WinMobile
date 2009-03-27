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
            this.menuItemAddPhoto = new System.Windows.Forms.MenuItem();
            this.menuItemCancel = new System.Windows.Forms.MenuItem();
            this.panelContent = new System.Windows.Forms.Panel();
            this.dateBox = new Ushahidi.Common.Controls.LabelDateBox();
            this.images = new Ushahidi.Common.Controls.LabelImages();
            this.textBoxDescription = new Ushahidi.Common.Controls.LabelTextBox();
            this.comboBoxLocales = new Ushahidi.Common.Controls.LabelComboBox();
            this.comboBoxCategories = new Ushahidi.Common.Controls.LabelComboBox();
            this.textBoxTitle = new Ushahidi.Common.Controls.LabelTextBox();
            this.menuItemSave = new System.Windows.Forms.MenuItem();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuItemWebsite
            // 
            this.menuItemWebsite.MenuItems.Add(this.menuItemAddPhoto);
            this.menuItemWebsite.MenuItems.Add(this.menuItemSave);
            this.menuItemWebsite.MenuItems.Add(this.menuItemCancel);
            this.menuItemWebsite.Text = "Action";
            // 
            // menuItemAddIncident
            // 
            this.menuItemAddIncident.Enabled = false;
            // 
            // menuItemAddPhoto
            // 
            this.menuItemAddPhoto.Enabled = false;
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
            this.panelContent.Controls.Add(this.dateBox);
            this.panelContent.Controls.Add(this.images);
            this.panelContent.Controls.Add(this.textBoxDescription);
            this.panelContent.Controls.Add(this.comboBoxLocales);
            this.panelContent.Controls.Add(this.comboBoxCategories);
            this.panelContent.Controls.Add(this.textBoxTitle);
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(240, 268);
            // 
            // dateBox
            // 
            this.dateBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dateBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dateBox.Bold = true;
            this.dateBox.Enabled = false;
            this.dateBox.Label = "Date";
            this.dateBox.Location = new System.Drawing.Point(0, 84);
            this.dateBox.Name = "dateBox";
            this.dateBox.Size = new System.Drawing.Size(240, 28);
            this.dateBox.TabIndex = 35;
            // 
            // images
            // 
            this.images.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.images.BackColor = System.Drawing.Color.WhiteSmoke;
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
            this.textBoxDescription.BackColor = System.Drawing.Color.Gainsboro;
            this.textBoxDescription.Bold = true;
            this.textBoxDescription.IsRequired = true;
            this.textBoxDescription.Label = "Description";
            this.textBoxDescription.Location = new System.Drawing.Point(0, 112);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(240, 80);
            this.textBoxDescription.TabIndex = 33;
            // 
            // comboBoxLocales
            // 
            this.comboBoxLocales.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxLocales.BackColor = System.Drawing.Color.Gainsboro;
            this.comboBoxLocales.Bold = true;
            this.comboBoxLocales.DisplayMember = "Name";
            this.comboBoxLocales.IsRequired = true;
            this.comboBoxLocales.Label = "Location";
            this.comboBoxLocales.Location = new System.Drawing.Point(0, 56);
            this.comboBoxLocales.Name = "comboBoxLocales";
            this.comboBoxLocales.Size = new System.Drawing.Size(240, 28);
            this.comboBoxLocales.TabIndex = 31;
            this.comboBoxLocales.ValueMember = "ID";
            // 
            // comboBoxCategories
            // 
            this.comboBoxCategories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxCategories.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboBoxCategories.Bold = true;
            this.comboBoxCategories.DisplayMember = "Title";
            this.comboBoxCategories.IsRequired = true;
            this.comboBoxCategories.Label = "Type";
            this.comboBoxCategories.Location = new System.Drawing.Point(0, 28);
            this.comboBoxCategories.Name = "comboBoxCategories";
            this.comboBoxCategories.Size = new System.Drawing.Size(240, 28);
            this.comboBoxCategories.TabIndex = 30;
            this.comboBoxCategories.ValueMember = "ID";
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTitle.BackColor = System.Drawing.Color.Gainsboro;
            this.textBoxTitle.Bold = true;
            this.textBoxTitle.IsRequired = true;
            this.textBoxTitle.Label = "Title";
            this.textBoxTitle.Location = new System.Drawing.Point(0, 0);
            this.textBoxTitle.Multiline = false;
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(240, 28);
            this.textBoxTitle.TabIndex = 29;
            // 
            // menuItemSave
            // 
            this.menuItemSave.Text = "Save";
            this.menuItemSave.Click += new System.EventHandler(this.OnSave);
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

        private System.Windows.Forms.MenuItem menuItemAddPhoto;
        private System.Windows.Forms.MenuItem menuItemCancel;
        private System.Windows.Forms.Panel panelContent;
        private Ushahidi.Common.Controls.LabelImages images;
        private Ushahidi.Common.Controls.LabelTextBox textBoxDescription;
        private Ushahidi.Common.Controls.LabelComboBox comboBoxLocales;
        private Ushahidi.Common.Controls.LabelComboBox comboBoxCategories;
        private Ushahidi.Common.Controls.LabelTextBox textBoxTitle;
        private Ushahidi.Common.Controls.LabelDateBox dateBox;
        private System.Windows.Forms.MenuItem menuItemSave;
    }
}