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
            this.menuItemAddIncidentAddPhoto = new System.Windows.Forms.MenuItem();
            this.menuItemAddIncidentAddNews = new System.Windows.Forms.MenuItem();
            this.menuItemAddIncidentAddVideo = new System.Windows.Forms.MenuItem();
            this.menuItemSeparator = new System.Windows.Forms.MenuItem();
            this.menuItemAddIncidentSave = new System.Windows.Forms.MenuItem();
            this.menuItemAddIncidentCancel = new System.Windows.Forms.MenuItem();
            this.panelContent = new System.Windows.Forms.Panel();
            this.scrollListBoxMediaItems = new Ushahidi.Common.Controls.ScrollListBox();
            this.textBoxAddIncidentDescription = new Ushahidi.Common.Controls.LabelTextBox();
            this.dateBoxAddIncidentDate = new Ushahidi.Common.Controls.LabelDateBox();
            this.comboBoxAddIncidentLocales = new Ushahidi.Common.Controls.LabelComboBox();
            this.comboBoxAddIncidentCategories = new Ushahidi.Common.Controls.LabelComboBox();
            this.textBoxAddIncidentTitle = new Ushahidi.Common.Controls.LabelTextBox();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuItemAction
            // 
            this.menuItemAction.MenuItems.Add(this.menuItemAddIncidentAddPhoto);
            this.menuItemAction.MenuItems.Add(this.menuItemAddIncidentAddNews);
            this.menuItemAction.MenuItems.Add(this.menuItemAddIncidentAddVideo);
            this.menuItemAction.MenuItems.Add(this.menuItemSeparator);
            this.menuItemAction.MenuItems.Add(this.menuItemAddIncidentSave);
            this.menuItemAction.MenuItems.Add(this.menuItemAddIncidentCancel);
            this.menuItemAction.Text = "Action";
            // 
            // menuItemAddIncidentAddPhoto
            // 
            this.menuItemAddIncidentAddPhoto.Text = "Add Photo";
            this.menuItemAddIncidentAddPhoto.Click += new System.EventHandler(this.OnAddPhoto);
            // 
            // menuItemAddIncidentAddNews
            // 
            this.menuItemAddIncidentAddNews.Text = "Add News Link";
            this.menuItemAddIncidentAddNews.Click += new System.EventHandler(this.OnAddNews);
            // 
            // menuItemAddIncidentAddVideo
            // 
            this.menuItemAddIncidentAddVideo.Text = "Add Video Link";
            this.menuItemAddIncidentAddVideo.Click += new System.EventHandler(this.OnAddVideo);
            // 
            // menuItemSeparator
            // 
            this.menuItemSeparator.Text = "-";
            // 
            // menuItemAddIncidentSave
            // 
            this.menuItemAddIncidentSave.Text = "Save";
            this.menuItemAddIncidentSave.Click += new System.EventHandler(this.OnSave);
            // 
            // menuItemAddIncidentCancel
            // 
            this.menuItemAddIncidentCancel.Text = "Cancel";
            this.menuItemAddIncidentCancel.Click += new System.EventHandler(this.OnCancel);
            // 
            // panelContent
            // 
            this.panelContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContent.AutoScroll = true;
            this.panelContent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelContent.Controls.Add(this.scrollListBoxMediaItems);
            this.panelContent.Controls.Add(this.textBoxAddIncidentDescription);
            this.panelContent.Controls.Add(this.dateBoxAddIncidentDate);
            this.panelContent.Controls.Add(this.comboBoxAddIncidentLocales);
            this.panelContent.Controls.Add(this.comboBoxAddIncidentCategories);
            this.panelContent.Controls.Add(this.textBoxAddIncidentTitle);
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(240, 294);
            // 
            // scrollListBoxMediaItems
            // 
            this.scrollListBoxMediaItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scrollListBoxMediaItems.BackColor = System.Drawing.Color.WhiteSmoke;
            this.scrollListBoxMediaItems.BackColorEven = System.Drawing.Color.White;
            this.scrollListBoxMediaItems.BackColorOdd = System.Drawing.Color.White;
            this.scrollListBoxMediaItems.BackSelectedColor = System.Drawing.Color.Black;
            this.scrollListBoxMediaItems.Location = new System.Drawing.Point(0, 243);
            this.scrollListBoxMediaItems.Name = "scrollListBoxMediaItems";
            this.scrollListBoxMediaItems.SelectedIndex = -1;
            this.scrollListBoxMediaItems.SelectedItem = null;
            this.scrollListBoxMediaItems.Size = new System.Drawing.Size(240, 51);
            this.scrollListBoxMediaItems.TabIndex = 11;
            // 
            // textBoxAddIncidentDescription
            // 
            this.textBoxAddIncidentDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAddIncidentDescription.BackColor = System.Drawing.Color.Gainsboro;
            this.textBoxAddIncidentDescription.Bold = true;
            this.textBoxAddIncidentDescription.IsRequired = false;
            this.textBoxAddIncidentDescription.Label = "Description";
            this.textBoxAddIncidentDescription.Location = new System.Drawing.Point(0, 163);
            this.textBoxAddIncidentDescription.Multiline = true;
            this.textBoxAddIncidentDescription.Name = "textBoxAddIncidentDescription";
            this.textBoxAddIncidentDescription.Size = new System.Drawing.Size(240, 80);
            this.textBoxAddIncidentDescription.TabIndex = 10;
            // 
            // dateBoxAddIncidentDate
            // 
            this.dateBoxAddIncidentDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dateBoxAddIncidentDate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dateBoxAddIncidentDate.Bold = true;
            this.dateBoxAddIncidentDate.Date = new System.DateTime(2009, 6, 4, 0, 0, 58, 796);
            this.dateBoxAddIncidentDate.IsRequired = false;
            this.dateBoxAddIncidentDate.Label = "Date";
            this.dateBoxAddIncidentDate.Location = new System.Drawing.Point(0, 45);
            this.dateBoxAddIncidentDate.Name = "dateBoxAddIncidentDate";
            this.dateBoxAddIncidentDate.Size = new System.Drawing.Size(240, 28);
            this.dateBoxAddIncidentDate.TabIndex = 7;
            // 
            // comboBoxAddIncidentLocales
            // 
            this.comboBoxAddIncidentLocales.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxAddIncidentLocales.BackColor = System.Drawing.Color.Gainsboro;
            this.comboBoxAddIncidentLocales.Bold = true;
            this.comboBoxAddIncidentLocales.DataSource = null;
            this.comboBoxAddIncidentLocales.DisplayMember = "";
            this.comboBoxAddIncidentLocales.IsRequired = false;
            this.comboBoxAddIncidentLocales.Label = "Location";
            this.comboBoxAddIncidentLocales.Location = new System.Drawing.Point(0, 73);
            this.comboBoxAddIncidentLocales.Name = "comboBoxAddIncidentLocales";
            this.comboBoxAddIncidentLocales.SelectedIndex = -1;
            this.comboBoxAddIncidentLocales.SelectedItem = null;
            this.comboBoxAddIncidentLocales.SelectedText = "";
            this.comboBoxAddIncidentLocales.Size = new System.Drawing.Size(240, 45);
            this.comboBoxAddIncidentLocales.TabIndex = 8;
            this.comboBoxAddIncidentLocales.ValueMember = "";
            // 
            // comboBoxAddIncidentCategories
            // 
            this.comboBoxAddIncidentCategories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxAddIncidentCategories.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboBoxAddIncidentCategories.Bold = true;
            this.comboBoxAddIncidentCategories.DataSource = null;
            this.comboBoxAddIncidentCategories.DisplayMember = "";
            this.comboBoxAddIncidentCategories.IsRequired = false;
            this.comboBoxAddIncidentCategories.Label = "Category";
            this.comboBoxAddIncidentCategories.Location = new System.Drawing.Point(0, 118);
            this.comboBoxAddIncidentCategories.Name = "comboBoxAddIncidentCategories";
            this.comboBoxAddIncidentCategories.SelectedIndex = -1;
            this.comboBoxAddIncidentCategories.SelectedItem = null;
            this.comboBoxAddIncidentCategories.SelectedText = "";
            this.comboBoxAddIncidentCategories.Size = new System.Drawing.Size(240, 45);
            this.comboBoxAddIncidentCategories.TabIndex = 9;
            this.comboBoxAddIncidentCategories.ValueMember = "";
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
            this.textBoxAddIncidentTitle.Size = new System.Drawing.Size(240, 45);
            this.textBoxAddIncidentTitle.TabIndex = 6;
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

        private System.Windows.Forms.MenuItem menuItemAddIncidentAddPhoto;
        private System.Windows.Forms.MenuItem menuItemAddIncidentAddNews;
        private System.Windows.Forms.MenuItem menuItemAddIncidentAddVideo;
        private System.Windows.Forms.MenuItem menuItemSeparator;
        private System.Windows.Forms.MenuItem menuItemAddIncidentSave;
        private System.Windows.Forms.MenuItem menuItemAddIncidentCancel;
        private System.Windows.Forms.Panel panelContent;
        private Ushahidi.Common.Controls.ScrollListBox scrollListBoxMediaItems;
        private Ushahidi.Common.Controls.LabelTextBox textBoxAddIncidentDescription;
        private Ushahidi.Common.Controls.LabelDateBox dateBoxAddIncidentDate;
        private Ushahidi.Common.Controls.LabelComboBox comboBoxAddIncidentLocales;
        private Ushahidi.Common.Controls.LabelComboBox comboBoxAddIncidentCategories;
        private Ushahidi.Common.Controls.LabelTextBox textBoxAddIncidentTitle;

    }
}