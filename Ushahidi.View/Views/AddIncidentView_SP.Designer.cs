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
            this.textBoxAddIncidentTitle = new Ushahidi.Common.Controls.LabelTextBox();
            this.comboBoxAddIncidentCategories = new Ushahidi.Common.Controls.LabelComboBox();
            this.comboBoxAddIncidentLocales = new Ushahidi.Common.Controls.LabelComboBox();
            this.textBoxAddIncidentDescription = new Ushahidi.Common.Controls.LabelTextBox();
            this.menuItemAddIncidentAddPhoto = new System.Windows.Forms.MenuItem();
            this.menuItemAddIncidentCancel = new System.Windows.Forms.MenuItem();
            this.dateBoxAddIncidentDate = new Ushahidi.Common.Controls.LabelDateBox();
            this.menuItemAddIncidentSave = new System.Windows.Forms.MenuItem();
            this.imageListBox = new Ushahidi.Common.Controls.ImageListBox();
            this.SuspendLayout();
            // 
            // menuItemAction
            // 
            this.menuItemAction.MenuItems.Add(this.menuItemAddIncidentAddPhoto);
            this.menuItemAction.MenuItems.Add(this.menuItemAddIncidentSave);
            this.menuItemAction.MenuItems.Add(this.menuItemAddIncidentCancel);
            this.menuItemAction.Text = "Action";
            // 
            // menuItemAddIncident
            // 
            this.menuItemAddIncident.Enabled = false;
            // 
            // textBoxAddIncidentTitle
            // 
            this.textBoxAddIncidentTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAddIncidentTitle.BackColor = System.Drawing.Color.Gainsboro;
            this.textBoxAddIncidentTitle.Bold = true;
            this.textBoxAddIncidentTitle.IsRequired = false;
            this.textBoxAddIncidentTitle.Label = "Title";
            this.textBoxAddIncidentTitle.Location = new System.Drawing.Point(0, 0);
            this.textBoxAddIncidentTitle.Multiline = false;
            this.textBoxAddIncidentTitle.Name = "textBoxAddIncidentTitle";
            this.textBoxAddIncidentTitle.Size = new System.Drawing.Size(176, 28);
            this.textBoxAddIncidentTitle.TabIndex = 20;
            // 
            // comboBoxAddIncidentCategories
            // 
            this.comboBoxAddIncidentCategories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxAddIncidentCategories.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboBoxAddIncidentCategories.Bold = true;
            this.comboBoxAddIncidentCategories.DisplayMember = "Title";
            this.comboBoxAddIncidentCategories.IsRequired = false;
            this.comboBoxAddIncidentCategories.Label = "Type";
            this.comboBoxAddIncidentCategories.Location = new System.Drawing.Point(0, 28);
            this.comboBoxAddIncidentCategories.Name = "comboBoxAddIncidentCategories";
            this.comboBoxAddIncidentCategories.SelectedIndex = -1;
            this.comboBoxAddIncidentCategories.SelectedText = "";
            this.comboBoxAddIncidentCategories.Size = new System.Drawing.Size(176, 28);
            this.comboBoxAddIncidentCategories.TabIndex = 21;
            this.comboBoxAddIncidentCategories.ValueMember = "ID";
            // 
            // comboBoxAddIncidentLocales
            // 
            this.comboBoxAddIncidentLocales.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxAddIncidentLocales.BackColor = System.Drawing.Color.Gainsboro;
            this.comboBoxAddIncidentLocales.Bold = true;
            this.comboBoxAddIncidentLocales.DisplayMember = "Name";
            this.comboBoxAddIncidentLocales.IsRequired = false;
            this.comboBoxAddIncidentLocales.Label = "Location";
            this.comboBoxAddIncidentLocales.Location = new System.Drawing.Point(0, 56);
            this.comboBoxAddIncidentLocales.Name = "comboBoxAddIncidentLocales";
            this.comboBoxAddIncidentLocales.SelectedIndex = -1;
            this.comboBoxAddIncidentLocales.SelectedText = "";
            this.comboBoxAddIncidentLocales.Size = new System.Drawing.Size(176, 28);
            this.comboBoxAddIncidentLocales.TabIndex = 22;
            this.comboBoxAddIncidentLocales.ValueMember = "ID";
            // 
            // textBoxAddIncidentDescription
            // 
            this.textBoxAddIncidentDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAddIncidentDescription.BackColor = System.Drawing.Color.Gainsboro;
            this.textBoxAddIncidentDescription.Bold = true;
            this.textBoxAddIncidentDescription.IsRequired = false;
            this.textBoxAddIncidentDescription.Label = "Description";
            this.textBoxAddIncidentDescription.Location = new System.Drawing.Point(0, 112);
            this.textBoxAddIncidentDescription.Multiline = true;
            this.textBoxAddIncidentDescription.Name = "textBoxAddIncidentDescription";
            this.textBoxAddIncidentDescription.Size = new System.Drawing.Size(176, 80);
            this.textBoxAddIncidentDescription.TabIndex = 28;
            // 
            // menuItemAddIncidentAddPhoto
            // 
            this.menuItemAddIncidentAddPhoto.Enabled = false;
            this.menuItemAddIncidentAddPhoto.Text = "Add Photo";
            // 
            // menuItemAddIncidentCancel
            // 
            this.menuItemAddIncidentCancel.Text = "Cancel";
            // 
            // dateBoxAddIncidentDate
            // 
            this.dateBoxAddIncidentDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dateBoxAddIncidentDate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dateBoxAddIncidentDate.Bold = true;
            this.dateBoxAddIncidentDate.Date = new System.DateTime(2009, 3, 26, 21, 26, 35, 466);
            this.dateBoxAddIncidentDate.Enabled = false;
            this.dateBoxAddIncidentDate.IsRequired = false;
            this.dateBoxAddIncidentDate.Label = "Date";
            this.dateBoxAddIncidentDate.Location = new System.Drawing.Point(0, 84);
            this.dateBoxAddIncidentDate.Name = "dateBoxAddIncidentDate";
            this.dateBoxAddIncidentDate.Size = new System.Drawing.Size(176, 28);
            this.dateBoxAddIncidentDate.TabIndex = 30;
            // 
            // menuItemAddIncidentSave
            // 
            this.menuItemAddIncidentSave.Text = "Save";
            // 
            // imageListBox
            // 
            this.imageListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.imageListBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.imageListBox.Location = new System.Drawing.Point(0, 192);
            this.imageListBox.Name = "imageListBox";
            this.imageListBox.Size = new System.Drawing.Size(176, 58);
            this.imageListBox.TabIndex = 37;
            // 
            // AddIncidentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(176, 250);
            this.Controls.Add(this.imageListBox);
            this.Controls.Add(this.dateBoxAddIncidentDate);
            this.Controls.Add(this.textBoxAddIncidentDescription);
            this.Controls.Add(this.comboBoxAddIncidentLocales);
            this.Controls.Add(this.comboBoxAddIncidentCategories);
            this.Controls.Add(this.textBoxAddIncidentTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddIncidentView";
            this.Text = "Add Incident";
            this.ResumeLayout(false);

        }

        #endregion

        private Ushahidi.Common.Controls.LabelTextBox textBoxAddIncidentTitle;
        private Ushahidi.Common.Controls.LabelComboBox comboBoxAddIncidentCategories;
        private Ushahidi.Common.Controls.LabelComboBox comboBoxAddIncidentLocales;
        private Ushahidi.Common.Controls.LabelTextBox textBoxAddIncidentDescription;
        private System.Windows.Forms.MenuItem menuItemAddIncidentAddPhoto;
        private System.Windows.Forms.MenuItem menuItemAddIncidentCancel;
        private Ushahidi.Common.Controls.LabelDateBox dateBoxAddIncidentDate;
        private System.Windows.Forms.MenuItem menuItemAddIncidentSave;
        private Ushahidi.Common.Controls.ImageListBox imageListBox;

    }
}