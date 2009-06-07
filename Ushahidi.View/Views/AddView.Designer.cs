namespace Ushahidi.View.Views
{
    partial class AddView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddView));
            this.menuItemAddPhoto = new System.Windows.Forms.MenuItem();
            this.menuItemAddNews = new System.Windows.Forms.MenuItem();
            this.menuItemAddVideo = new System.Windows.Forms.MenuItem();
            this.menuItemSeparator = new System.Windows.Forms.MenuItem();
            this.menuItemSave = new System.Windows.Forms.MenuItem();
            this.menuItemCancel = new System.Windows.Forms.MenuItem();
            this.panelContent = new System.Windows.Forms.Panel();
            this.scrollListBox = new Ushahidi.Common.Controls.ScrollListBox();
            this.textBoxDescription = new Ushahidi.Common.Controls.LabelTextBox();
            this.dateBoxDate = new Ushahidi.Common.Controls.LabelDateBox();
            this.comboBoxLocales = new Ushahidi.Common.Controls.LabelComboBox();
            this.comboBoxCategories = new Ushahidi.Common.Controls.LabelComboBox();
            this.textBoxTitle = new Ushahidi.Common.Controls.LabelTextBox();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuItemAction
            // 
            this.menuItemAction.MenuItems.Add(this.menuItemAddPhoto);
            this.menuItemAction.MenuItems.Add(this.menuItemAddNews);
            this.menuItemAction.MenuItems.Add(this.menuItemAddVideo);
            this.menuItemAction.MenuItems.Add(this.menuItemSeparator);
            this.menuItemAction.MenuItems.Add(this.menuItemSave);
            this.menuItemAction.MenuItems.Add(this.menuItemCancel);
            this.menuItemAction.Text = "Action";
            // 
            // menuItemAddIncidentAddPhoto
            // 
            this.menuItemAddPhoto.Text = "Add Photo";
            this.menuItemAddPhoto.Click += new System.EventHandler(this.OnAddPhoto);
            // 
            // menuItemAddIncidentAddNews
            // 
            this.menuItemAddNews.Text = "Add News Link";
            this.menuItemAddNews.Click += new System.EventHandler(this.OnAddNews);
            // 
            // menuItemAddIncidentAddVideo
            // 
            this.menuItemAddVideo.Text = "Add Video Link";
            this.menuItemAddVideo.Click += new System.EventHandler(this.OnAddVideo);
            // 
            // menuItemSeparator
            // 
            this.menuItemSeparator.Text = "-";
            // 
            // menuItemAddIncidentSave
            // 
            this.menuItemSave.Text = "Save";
            this.menuItemSave.Click += new System.EventHandler(this.OnSave);
            // 
            // menuItemAddIncidentCancel
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
            this.panelContent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelContent.Controls.Add(this.scrollListBox);
            this.panelContent.Controls.Add(this.textBoxDescription);
            this.panelContent.Controls.Add(this.dateBoxDate);
            this.panelContent.Controls.Add(this.comboBoxLocales);
            this.panelContent.Controls.Add(this.comboBoxCategories);
            this.panelContent.Controls.Add(this.textBoxTitle);
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(240, 294);
            // 
            // scrollListBoxMediaItems
            // 
            this.scrollListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scrollListBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.scrollListBox.BackColorEven = System.Drawing.Color.White;
            this.scrollListBox.BackColorOdd = System.Drawing.Color.White;
            this.scrollListBox.BackSelectedColor = System.Drawing.Color.Black;
            this.scrollListBox.Location = new System.Drawing.Point(0, 243);
            this.scrollListBox.Name = "scrollListBox";
            this.scrollListBox.SelectedIndex = -1;
            this.scrollListBox.SelectedItem = null;
            this.scrollListBox.Size = new System.Drawing.Size(240, 51);
            this.scrollListBox.TabIndex = 11;
            // 
            // textBoxAddIncidentDescription
            // 
            this.textBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDescription.BackColor = System.Drawing.Color.Gainsboro;
            this.textBoxDescription.Bold = true;
            this.textBoxDescription.IsRequired = false;
            this.textBoxDescription.Text = "Description";
            this.textBoxDescription.Location = new System.Drawing.Point(0, 163);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(240, 80);
            this.textBoxDescription.TabIndex = 10;
            // 
            // dateBoxAddIncidentDate
            // 
            this.dateBoxDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dateBoxDate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dateBoxDate.Bold = true;
            this.dateBoxDate.Value = new System.DateTime(2009, 6, 4, 0, 0, 58, 796);
            this.dateBoxDate.IsRequired = false;
            this.dateBoxDate.Text = "Date";
            this.dateBoxDate.Location = new System.Drawing.Point(0, 45);
            this.dateBoxDate.Name = "dateBoxDate";
            this.dateBoxDate.Size = new System.Drawing.Size(240, 28);
            this.dateBoxDate.TabIndex = 7;
            // 
            // comboBoxAddIncidentLocales
            // 
            this.comboBoxLocales.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxLocales.BackColor = System.Drawing.Color.Gainsboro;
            this.comboBoxLocales.Bold = true;
            this.comboBoxLocales.DataSource = null;
            this.comboBoxLocales.DisplayMember = "";
            this.comboBoxLocales.IsRequired = false;
            this.comboBoxLocales.Text = "Location";
            this.comboBoxLocales.Location = new System.Drawing.Point(0, 73);
            this.comboBoxLocales.Name = "comboBoxLocales";
            this.comboBoxLocales.SelectedIndex = -1;
            this.comboBoxLocales.SelectedItem = null;
            this.comboBoxLocales.SelectedText = "";
            this.comboBoxLocales.Size = new System.Drawing.Size(240, 45);
            this.comboBoxLocales.TabIndex = 8;
            this.comboBoxLocales.ValueMember = "";
            // 
            // comboBoxAddIncidentCategories
            // 
            this.comboBoxCategories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxCategories.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboBoxCategories.Bold = true;
            this.comboBoxCategories.DataSource = null;
            this.comboBoxCategories.DisplayMember = "";
            this.comboBoxCategories.IsRequired = false;
            this.comboBoxCategories.Text = "Category";
            this.comboBoxCategories.Location = new System.Drawing.Point(0, 118);
            this.comboBoxCategories.Name = "comboBoxCategories";
            this.comboBoxCategories.SelectedIndex = -1;
            this.comboBoxCategories.SelectedItem = null;
            this.comboBoxCategories.SelectedText = "";
            this.comboBoxCategories.Size = new System.Drawing.Size(240, 45);
            this.comboBoxCategories.TabIndex = 9;
            this.comboBoxCategories.ValueMember = "";
            // 
            // textBoxAddIncidentTitle
            // 
            this.textBoxTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTitle.BackColor = System.Drawing.Color.Gainsboro;
            this.textBoxTitle.Bold = true;
            this.textBoxTitle.IsRequired = false;
            this.textBoxTitle.Text = "Title";
            this.textBoxTitle.Location = new System.Drawing.Point(0, 0);
            this.textBoxTitle.Multiline = false;
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(240, 45);
            this.textBoxTitle.TabIndex = 6;
            // 
            // AddView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = false;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.panelContent);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddView";
            this.Text = "Add Incident";
            this.panelContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem menuItemAddPhoto;
        private System.Windows.Forms.MenuItem menuItemAddNews;
        private System.Windows.Forms.MenuItem menuItemAddVideo;
        private System.Windows.Forms.MenuItem menuItemSeparator;
        private System.Windows.Forms.MenuItem menuItemSave;
        private System.Windows.Forms.MenuItem menuItemCancel;
        private System.Windows.Forms.Panel panelContent;
        private Ushahidi.Common.Controls.ScrollListBox scrollListBox;
        private Ushahidi.Common.Controls.LabelTextBox textBoxDescription;
        private Ushahidi.Common.Controls.LabelDateBox dateBoxDate;
        private Ushahidi.Common.Controls.LabelComboBox comboBoxLocales;
        private Ushahidi.Common.Controls.LabelComboBox comboBoxCategories;
        private Ushahidi.Common.Controls.LabelTextBox textBoxTitle;

    }
}