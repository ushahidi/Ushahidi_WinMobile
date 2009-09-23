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
            this.menuItemSubmit = new System.Windows.Forms.MenuItem();
            this.menuItemCancel = new System.Windows.Forms.MenuItem();
            this.scrollListBox = new Ushahidi.Common.Controls.ScrollListBox();
            this.panel = new System.Windows.Forms.Panel();
            this.dateBoxTime = new Ushahidi.Common.Controls.LabelDateBox();
            this.textBoxVideo = new Ushahidi.Common.Controls.LabelTextBox();
            this.textBoxNews = new Ushahidi.Common.Controls.LabelTextBox();
            this.textBoxDescription = new Ushahidi.Common.Controls.LabelTextBox();
            this.checkBoxesCategories = new Ushahidi.Common.Controls.LabelCheckBoxes();
            this.comboBoxLocales = new Ushahidi.Common.Controls.LabelComboBox();
            this.dateBoxDate = new Ushahidi.Common.Controls.LabelDateBox();
            this.textBoxTitle = new Ushahidi.Common.Controls.LabelTextBox();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuItemAction
            // 
            this.menuItemAction.MenuItems.Add(this.menuItemAddPhoto);
            this.menuItemAction.MenuItems.Add(this.menuItemAddNews);
            this.menuItemAction.MenuItems.Add(this.menuItemAddVideo);
            this.menuItemAction.MenuItems.Add(this.menuItemSeparator);
            this.menuItemAction.MenuItems.Add(this.menuItemSubmit);
            this.menuItemAction.MenuItems.Add(this.menuItemCancel);
            this.menuItemAction.Text = "Action";
            // 
            // menuItemAddPhoto
            // 
            this.menuItemAddPhoto.Text = "Add Photo";
            this.menuItemAddPhoto.Click += new System.EventHandler(this.OnAddPhoto);
            // 
            // menuItemAddNews
            // 
            this.menuItemAddNews.Text = "Add News Link";
            this.menuItemAddNews.Click += new System.EventHandler(this.OnAddNews);
            // 
            // menuItemAddVideo
            // 
            this.menuItemAddVideo.Text = "Add Video Link";
            this.menuItemAddVideo.Click += new System.EventHandler(this.OnAddVideo);
            // 
            // menuItemSeparator
            // 
            this.menuItemSeparator.Text = "-";
            // 
            // menuItemSubmit
            // 
            this.menuItemSubmit.Text = "Submit";
            this.menuItemSubmit.Click += new System.EventHandler(this.OnSave);
            // 
            // menuItemCancel
            // 
            this.menuItemCancel.Text = "Cancel";
            this.menuItemCancel.Click += new System.EventHandler(this.OnCancel);
            // 
            // scrollListBox
            // 
            this.scrollListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scrollListBox.AutoScroll = true;
            this.scrollListBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.scrollListBox.BackColorEven = System.Drawing.Color.WhiteSmoke;
            this.scrollListBox.BackColorOdd = System.Drawing.Color.WhiteSmoke;
            this.scrollListBox.BackSelectedColor = System.Drawing.Color.Black;
            this.scrollListBox.ForeColor = System.Drawing.Color.Black;
            this.scrollListBox.ForeSelectedColor = System.Drawing.Color.White;
            this.scrollListBox.Location = new System.Drawing.Point(0, 350);
            this.scrollListBox.Name = "scrollListBox";
            this.scrollListBox.SelectedIndex = -1;
            this.scrollListBox.SelectedItem = null;
            this.scrollListBox.Size = new System.Drawing.Size(155, 20);
            this.scrollListBox.TabIndex = 7;
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.AutoScroll = true;
            this.panel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel.Controls.Add(this.dateBoxTime);
            this.panel.Controls.Add(this.textBoxVideo);
            this.panel.Controls.Add(this.textBoxNews);
            this.panel.Controls.Add(this.textBoxDescription);
            this.panel.Controls.Add(this.scrollListBox);
            this.panel.Controls.Add(this.checkBoxesCategories);
            this.panel.Controls.Add(this.comboBoxLocales);
            this.panel.Controls.Add(this.dateBoxDate);
            this.panel.Controls.Add(this.textBoxTitle);
            this.panel.Location = new System.Drawing.Point(0, 0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(176, 180);
            // 
            // dateBoxTime
            // 
            this.dateBoxTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dateBoxTime.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dateBoxTime.IsRequired = true;
            this.dateBoxTime.Label = "Time";
            this.dateBoxTime.Location = new System.Drawing.Point(0, 90);
            this.dateBoxTime.Name = "dateBoxTime";
            this.dateBoxTime.Size = new System.Drawing.Size(162, 45);
            this.dateBoxTime.TabIndex = 2;
            this.dateBoxTime.Type = Ushahidi.Common.Controls.LabelDateBox.Types.Time;
            this.dateBoxTime.Value = new System.DateTime(2009, 6, 9, 2, 9, 26, 281);
            // 
            // textBoxVideo
            // 
            this.textBoxVideo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxVideo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxVideo.IsRequired = false;
            this.textBoxVideo.Label = "Video";
            this.textBoxVideo.Location = new System.Drawing.Point(0, 350);
            this.textBoxVideo.Multiline = false;
            this.textBoxVideo.Name = "textBoxVideo";
            this.textBoxVideo.Size = new System.Drawing.Size(162, 45);
            this.textBoxVideo.TabIndex = 7;
            this.textBoxVideo.Value = "";
            // 
            // textBoxNews
            // 
            this.textBoxNews.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxNews.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxNews.IsRequired = false;
            this.textBoxNews.Label = "News";
            this.textBoxNews.Location = new System.Drawing.Point(0, 305);
            this.textBoxNews.Multiline = false;
            this.textBoxNews.Name = "textBoxNews";
            this.textBoxNews.Size = new System.Drawing.Size(162, 45);
            this.textBoxNews.TabIndex = 6;
            this.textBoxNews.Value = "";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDescription.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxDescription.IsRequired = true;
            this.textBoxDescription.Label = "Description";
            this.textBoxDescription.Location = new System.Drawing.Point(0, 230);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(162, 75);
            this.textBoxDescription.TabIndex = 5;
            this.textBoxDescription.Value = "";
            // 
            // checkBoxesCategories
            // 
            this.checkBoxesCategories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxesCategories.BackColor = System.Drawing.Color.WhiteSmoke;
            this.checkBoxesCategories.Label = "Category";
            this.checkBoxesCategories.Location = new System.Drawing.Point(0, 180);
            this.checkBoxesCategories.Name = "checkBoxesCategories";
            this.checkBoxesCategories.Size = new System.Drawing.Size(162, 45);
            this.checkBoxesCategories.TabIndex = 4;
            // 
            // comboBoxLocales
            // 
            this.comboBoxLocales.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxLocales.BackColor = System.Drawing.Color.WhiteSmoke;
            this.comboBoxLocales.Bold = true;
            this.comboBoxLocales.DataSource = null;
            this.comboBoxLocales.DisplayMember = "";
            this.comboBoxLocales.IsRequired = true;
            this.comboBoxLocales.Label = "Location";
            this.comboBoxLocales.Location = new System.Drawing.Point(0, 135);
            this.comboBoxLocales.Name = "comboBoxLocales";
            this.comboBoxLocales.SelectedIndex = -1;
            this.comboBoxLocales.SelectedItem = null;
            this.comboBoxLocales.SelectedText = "";
            this.comboBoxLocales.Size = new System.Drawing.Size(162, 45);
            this.comboBoxLocales.TabIndex = 3;
            this.comboBoxLocales.ValueMember = "";
            // 
            // dateBoxDate
            // 
            this.dateBoxDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dateBoxDate.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dateBoxDate.IsRequired = true;
            this.dateBoxDate.Label = "Date";
            this.dateBoxDate.Location = new System.Drawing.Point(0, 45);
            this.dateBoxDate.Name = "dateBoxDate";
            this.dateBoxDate.Size = new System.Drawing.Size(162, 45);
            this.dateBoxDate.TabIndex = 1;
            this.dateBoxDate.Type = Ushahidi.Common.Controls.LabelDateBox.Types.Date;
            this.dateBoxDate.Value = new System.DateTime(2009, 6, 9, 2, 9, 26, 281);
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTitle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxTitle.IsRequired = true;
            this.textBoxTitle.Label = "Title";
            this.textBoxTitle.Location = new System.Drawing.Point(0, 0);
            this.textBoxTitle.Multiline = false;
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(162, 45);
            this.textBoxTitle.TabIndex = 0;
            this.textBoxTitle.Value = "";
            // 
            // AddView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = false;
            this.ClientSize = new System.Drawing.Size(176, 180);
            this.Controls.Add(this.panel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddView";
            this.Text = "Add Incident";
            this.Resize += new System.EventHandler(this.OnResize);
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem menuItemAddPhoto;
        private System.Windows.Forms.MenuItem menuItemAddNews;
        private System.Windows.Forms.MenuItem menuItemAddVideo;
        private System.Windows.Forms.MenuItem menuItemSeparator;
        private System.Windows.Forms.MenuItem menuItemSubmit;
        private System.Windows.Forms.MenuItem menuItemCancel;
        private Ushahidi.Common.Controls.ScrollListBox scrollListBox;
        private System.Windows.Forms.Panel panel;
        private Ushahidi.Common.Controls.LabelTextBox textBoxTitle;
        private Ushahidi.Common.Controls.LabelDateBox dateBoxDate;
        private Ushahidi.Common.Controls.LabelComboBox comboBoxLocales;
        private Ushahidi.Common.Controls.LabelCheckBoxes checkBoxesCategories;
        private Ushahidi.Common.Controls.LabelTextBox textBoxDescription;
        private Ushahidi.Common.Controls.LabelTextBox textBoxNews;
        private Ushahidi.Common.Controls.LabelTextBox textBoxVideo;
        private Ushahidi.Common.Controls.LabelDateBox dateBoxTime;

    }
}