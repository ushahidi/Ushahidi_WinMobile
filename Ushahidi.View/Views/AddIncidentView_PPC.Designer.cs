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
            this.menuItemAddIncidentAddPhoto = new System.Windows.Forms.MenuItem();
            this.menuItemAddIncidentCancel = new System.Windows.Forms.MenuItem();
            this.panelContent = new System.Windows.Forms.Panel();
            this.imageListBox = new Ushahidi.Common.Controls.ImageListBox();
            this.dateBoxAddIncidentDate = new Ushahidi.Common.Controls.LabelDateBox();
            this.textBoxAddIncidentDescription = new Ushahidi.Common.Controls.LabelTextBox();
            this.comboBoxAddIncidentLocales = new Ushahidi.Common.Controls.LabelComboBox();
            this.comboBoxAddIncidentCategories = new Ushahidi.Common.Controls.LabelComboBox();
            this.textBoxAddIncidentTitle = new Ushahidi.Common.Controls.LabelTextBox();
            this.menuItemAddIncidentSave = new System.Windows.Forms.MenuItem();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuItemAddIncident
            // 
            this.menuItemAddIncident.Enabled = false;
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
            // menuItemAction
            // 
            this.menuItemAction.Text = "Action";
            this.menuItemAction.MenuItems.Add(this.menuItemAddIncidentAddPhoto);
            this.menuItemAction.MenuItems.Add(this.menuItemAddIncidentCancel);
            // 
            // panelContent
            // 
            this.panelContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContent.AutoScroll = true;
            this.panelContent.Controls.Add(this.imageListBox);
            this.panelContent.Controls.Add(this.dateBoxAddIncidentDate);
            this.panelContent.Controls.Add(this.textBoxAddIncidentDescription);
            this.panelContent.Controls.Add(this.comboBoxAddIncidentLocales);
            this.panelContent.Controls.Add(this.comboBoxAddIncidentCategories);
            this.panelContent.Controls.Add(this.textBoxAddIncidentTitle);
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(240, 268);
            // 
            // imageListBox
            // 
            this.imageListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.imageListBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.imageListBox.Location = new System.Drawing.Point(0, 192);
            this.imageListBox.Name = "imageListBoxs";
            this.imageListBox.Size = new System.Drawing.Size(240, 73);
            this.imageListBox.TabIndex = 36;
            // 
            // dateBoxAddIncidentDate
            // 
            this.dateBoxAddIncidentDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dateBoxAddIncidentDate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dateBoxAddIncidentDate.Bold = true;
            this.dateBoxAddIncidentDate.Enabled = false;
            this.dateBoxAddIncidentDate.Label = "Date";
            this.dateBoxAddIncidentDate.Location = new System.Drawing.Point(0, 84);
            this.dateBoxAddIncidentDate.Name = "dateBoxAddIncidentDate";
            this.dateBoxAddIncidentDate.Size = new System.Drawing.Size(240, 28);
            this.dateBoxAddIncidentDate.TabIndex = 35;
            // 
            // textBoxAddIncidentDescription
            // 
            this.textBoxAddIncidentDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAddIncidentDescription.BackColor = System.Drawing.Color.Gainsboro;
            this.textBoxAddIncidentDescription.Bold = true;
            this.textBoxAddIncidentDescription.IsRequired = true;
            this.textBoxAddIncidentDescription.Label = "Description";
            this.textBoxAddIncidentDescription.Location = new System.Drawing.Point(0, 112);
            this.textBoxAddIncidentDescription.Multiline = true;
            this.textBoxAddIncidentDescription.Name = "textBoxAddIncidentDescription";
            this.textBoxAddIncidentDescription.Size = new System.Drawing.Size(240, 80);
            this.textBoxAddIncidentDescription.TabIndex = 33;
            // 
            // comboBoxAddIncidentLocales
            // 
            this.comboBoxAddIncidentLocales.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxAddIncidentLocales.BackColor = System.Drawing.Color.Gainsboro;
            this.comboBoxAddIncidentLocales.Bold = true;
            this.comboBoxAddIncidentLocales.DisplayMember = "Name";
            this.comboBoxAddIncidentLocales.IsRequired = true;
            this.comboBoxAddIncidentLocales.Label = "Location";
            this.comboBoxAddIncidentLocales.Location = new System.Drawing.Point(0, 56);
            this.comboBoxAddIncidentLocales.Name = "comboBoxAddIncidentLocales";
            this.comboBoxAddIncidentLocales.Size = new System.Drawing.Size(240, 28);
            this.comboBoxAddIncidentLocales.TabIndex = 31;
            this.comboBoxAddIncidentLocales.ValueMember = "ID";
            // 
            // comboBoxAddIncidentCategories
            // 
            this.comboBoxAddIncidentCategories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxAddIncidentCategories.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboBoxAddIncidentCategories.Bold = true;
            this.comboBoxAddIncidentCategories.DisplayMember = "Title";
            this.comboBoxAddIncidentCategories.IsRequired = true;
            this.comboBoxAddIncidentCategories.Label = "Category";
            this.comboBoxAddIncidentCategories.Location = new System.Drawing.Point(0, 28);
            this.comboBoxAddIncidentCategories.Name = "comboBoxAddIncidentCategories";
            this.comboBoxAddIncidentCategories.Size = new System.Drawing.Size(240, 28);
            this.comboBoxAddIncidentCategories.TabIndex = 30;
            this.comboBoxAddIncidentCategories.ValueMember = "ID";
            // 
            // textBoxAddIncidentTitle
            // 
            this.textBoxAddIncidentTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAddIncidentTitle.BackColor = System.Drawing.Color.Gainsboro;
            this.textBoxAddIncidentTitle.Bold = true;
            this.textBoxAddIncidentTitle.IsRequired = true;
            this.textBoxAddIncidentTitle.Label = "Title";
            this.textBoxAddIncidentTitle.Location = new System.Drawing.Point(0, 0);
            this.textBoxAddIncidentTitle.Multiline = false;
            this.textBoxAddIncidentTitle.Name = "textBoxAddIncidentTitle";
            this.textBoxAddIncidentTitle.Size = new System.Drawing.Size(240, 28);
            this.textBoxAddIncidentTitle.TabIndex = 29;
            // 
            // menuItemAddIncidentSave
            // 
            this.menuItemAddIncidentSave.Text = "Save";
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

        private System.Windows.Forms.MenuItem menuItemAddIncidentAddPhoto;
        private System.Windows.Forms.MenuItem menuItemAddIncidentCancel;
        private System.Windows.Forms.Panel panelContent;
        private Ushahidi.Common.Controls.LabelTextBox textBoxAddIncidentDescription;
        private Ushahidi.Common.Controls.LabelComboBox comboBoxAddIncidentLocales;
        private Ushahidi.Common.Controls.LabelComboBox comboBoxAddIncidentCategories;
        private Ushahidi.Common.Controls.LabelTextBox textBoxAddIncidentTitle;
        private Ushahidi.Common.Controls.LabelDateBox dateBoxAddIncidentDate;
        private System.Windows.Forms.MenuItem menuItemAddIncidentSave;
        private Ushahidi.Common.Controls.ImageListBox imageListBox;
    }
}