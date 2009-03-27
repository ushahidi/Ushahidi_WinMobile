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
            this.comboBoxCategories = new Ushahidi.Common.Controls.LabelComboBox();
            this.comboBoxLocales = new Ushahidi.Common.Controls.LabelComboBox();
            this.textBoxDescription = new Ushahidi.Common.Controls.LabelTextBox();
            this.images = new Ushahidi.Common.Controls.LabelImages();
            this.menuItemAddPhoto = new System.Windows.Forms.MenuItem();
            this.menuItemCancel = new System.Windows.Forms.MenuItem();
            this.dateBox = new Ushahidi.Common.Controls.LabelDateBox();
            this.menuItemSave = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // menuItemAddIncident
            // 
            this.menuItemAddIncident.Enabled = false;
            // 
            // menuItemAction
            // 
            this.menuItemAction.MenuItems.Add(this.menuItemAddPhoto);
            this.menuItemAction.MenuItems.Add(this.menuItemSave);
            this.menuItemAction.MenuItems.Add(this.menuItemCancel);
            this.menuItemAction.Text = "Action";
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTitle.BackColor = System.Drawing.Color.Gainsboro;
            this.textBoxTitle.Bold = true;
            this.textBoxTitle.IsRequired = false;
            this.textBoxTitle.Label = "Title";
            this.textBoxTitle.Location = new System.Drawing.Point(0, 0);
            this.textBoxTitle.Multiline = false;
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(169, 28);
            this.textBoxTitle.TabIndex = 20;
            // 
            // comboBoxCategories
            // 
            this.comboBoxCategories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxCategories.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboBoxCategories.Bold = true;
            this.comboBoxCategories.DisplayMember = "Title";
            this.comboBoxCategories.IsRequired = false;
            this.comboBoxCategories.Label = "Type";
            this.comboBoxCategories.Location = new System.Drawing.Point(0, 28);
            this.comboBoxCategories.Name = "comboBoxCategories";
            this.comboBoxCategories.SelectedIndex = -1;
            this.comboBoxCategories.SelectedText = "";
            this.comboBoxCategories.Size = new System.Drawing.Size(169, 28);
            this.comboBoxCategories.TabIndex = 21;
            this.comboBoxCategories.ValueMember = "ID";
            // 
            // comboBoxLocales
            // 
            this.comboBoxLocales.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxLocales.BackColor = System.Drawing.Color.Gainsboro;
            this.comboBoxLocales.Bold = true;
            this.comboBoxLocales.DisplayMember = "Name";
            this.comboBoxLocales.IsRequired = false;
            this.comboBoxLocales.Label = "Location";
            this.comboBoxLocales.Location = new System.Drawing.Point(0, 56);
            this.comboBoxLocales.Name = "comboBoxLocales";
            this.comboBoxLocales.SelectedIndex = -1;
            this.comboBoxLocales.SelectedText = "";
            this.comboBoxLocales.Size = new System.Drawing.Size(169, 28);
            this.comboBoxLocales.TabIndex = 22;
            this.comboBoxLocales.ValueMember = "ID";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDescription.BackColor = System.Drawing.Color.Gainsboro;
            this.textBoxDescription.Bold = true;
            this.textBoxDescription.IsRequired = false;
            this.textBoxDescription.Label = "Description";
            this.textBoxDescription.Location = new System.Drawing.Point(0, 112);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(169, 80);
            this.textBoxDescription.TabIndex = 28;
            // 
            // images
            // 
            this.images.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.images.BackColor = System.Drawing.Color.WhiteSmoke;
            this.images.Bold = true;
            this.images.ImagesPerRow = 3;
            this.images.Label = "Photos";
            this.images.Location = new System.Drawing.Point(0, 192);
            this.images.Name = "images";
            this.images.Size = new System.Drawing.Size(169, 68);
            this.images.TabIndex = 29;
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
            // dateBox
            // 
            this.dateBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dateBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dateBox.Bold = true;
            this.dateBox.Date = new System.DateTime(2009, 3, 26, 21, 26, 35, 466);
            this.dateBox.Enabled = false;
            this.dateBox.IsRequired = false;
            this.dateBox.Label = "Date";
            this.dateBox.Location = new System.Drawing.Point(0, 84);
            this.dateBox.Name = "dateBox";
            this.dateBox.Size = new System.Drawing.Size(169, 28);
            this.dateBox.TabIndex = 30;
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
            this.ClientSize = new System.Drawing.Size(169, 180);
            this.Controls.Add(this.dateBox);
            this.Controls.Add(this.images);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.comboBoxLocales);
            this.Controls.Add(this.comboBoxCategories);
            this.Controls.Add(this.textBoxTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddIncidentView";
            this.Text = "Add Incident";
            this.ResumeLayout(false);

        }

        #endregion

        private Ushahidi.Common.Controls.LabelTextBox textBoxTitle;
        private Ushahidi.Common.Controls.LabelComboBox comboBoxCategories;
        private Ushahidi.Common.Controls.LabelComboBox comboBoxLocales;
        private Ushahidi.Common.Controls.LabelTextBox textBoxDescription;
        private Ushahidi.Common.Controls.LabelImages images;
        private System.Windows.Forms.MenuItem menuItemAddPhoto;
        private System.Windows.Forms.MenuItem menuItemCancel;
        private Ushahidi.Common.Controls.LabelDateBox dateBox;
        private System.Windows.Forms.MenuItem menuItemSave;

    }
}