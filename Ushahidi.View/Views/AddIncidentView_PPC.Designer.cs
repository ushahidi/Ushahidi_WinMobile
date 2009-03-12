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
            this.textBoxTitle = new Ushahidi.Common.Controls.LabelTextBox();
            this.comboBoxType = new Ushahidi.Common.Controls.LabelComboBox();
            this.comboBoxLocale = new Ushahidi.Common.Controls.LabelComboBox();
            this.textBoxDate = new Ushahidi.Common.Controls.LabelTextBox();
            this.textBoxDescription = new Ushahidi.Common.Controls.LabelTextBox();
            this.menuItemSave = new System.Windows.Forms.MenuItem();
            this.images = new Ushahidi.Common.Controls.LabelImages();
            this.menuItemAddPhoto = new System.Windows.Forms.MenuItem();
            this.menuItemCancel = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // menuItemAction
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
            // textBoxTitle
            // 
            this.textBoxTitle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxTitle.Bold = true;
            this.textBoxTitle.Label = "Title";
            this.textBoxTitle.Location = new System.Drawing.Point(0, 0);
            this.textBoxTitle.Multiline = false;
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.ReadOnly = false;
            this.textBoxTitle.Size = new System.Drawing.Size(240, 28);
            this.textBoxTitle.TabIndex = 19;
            // 
            // comboBoxType
            // 
            this.comboBoxType.BackColor = System.Drawing.Color.Gainsboro;
            this.comboBoxType.Bold = true;
            this.comboBoxType.Label = "Type";
            this.comboBoxType.Location = new System.Drawing.Point(0, 28);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(240, 28);
            this.comboBoxType.TabIndex = 20;
            // 
            // comboBoxLocale
            // 
            this.comboBoxLocale.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboBoxLocale.Bold = true;
            this.comboBoxLocale.Label = "Location";
            this.comboBoxLocale.Location = new System.Drawing.Point(0, 56);
            this.comboBoxLocale.Name = "comboBoxLocale";
            this.comboBoxLocale.Size = new System.Drawing.Size(240, 28);
            this.comboBoxLocale.TabIndex = 21;
            // 
            // textBoxDate
            // 
            this.textBoxDate.BackColor = System.Drawing.Color.Gainsboro;
            this.textBoxDate.Bold = true;
            this.textBoxDate.Label = "Date";
            this.textBoxDate.Location = new System.Drawing.Point(0, 84);
            this.textBoxDate.Multiline = false;
            this.textBoxDate.Name = "textBoxDate";
            this.textBoxDate.ReadOnly = true;
            this.textBoxDate.Size = new System.Drawing.Size(240, 28);
            this.textBoxDate.TabIndex = 22;
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxDescription.Bold = true;
            this.textBoxDescription.Label = "Description";
            this.textBoxDescription.Location = new System.Drawing.Point(0, 112);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.ReadOnly = false;
            this.textBoxDescription.Size = new System.Drawing.Size(240, 80);
            this.textBoxDescription.TabIndex = 27;
            // 
            // menuItemSave
            // 
            this.menuItemSave.Text = "Save Incident";
            this.menuItemSave.Click += new System.EventHandler(this.OnSaveIncident);
            // 
            // images
            // 
            this.images.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.images.BackColor = System.Drawing.Color.Gainsboro;
            this.images.Label = "Photos";
            this.images.Location = new System.Drawing.Point(0, 192);
            this.images.Name = "images";
            this.images.Size = new System.Drawing.Size(240, 76);
            this.images.TabIndex = 28;
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
            // AddIncidentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.images);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.textBoxDate);
            this.Controls.Add(this.comboBoxLocale);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.textBoxTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddIncidentView";
            this.Text = "Add Incident";
            this.ResumeLayout(false);

        }

        #endregion

        private Ushahidi.Common.Controls.LabelTextBox textBoxTitle;
        private Ushahidi.Common.Controls.LabelComboBox comboBoxType;
        private Ushahidi.Common.Controls.LabelComboBox comboBoxLocale;
        private Ushahidi.Common.Controls.LabelTextBox textBoxDate;
        private Ushahidi.Common.Controls.LabelTextBox textBoxDescription;
        private System.Windows.Forms.MenuItem menuItemSave;
        private Ushahidi.Common.Controls.LabelImages images;
        private System.Windows.Forms.MenuItem menuItemAddPhoto;
        private System.Windows.Forms.MenuItem menuItemCancel;
    }
}