namespace Ushahidi.View.Views
{
    partial class IncidentDetailsView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IncidentDetailsView));
            this.menuItemAddPhoto = new System.Windows.Forms.MenuItem();
            this.menuItemViewMap = new System.Windows.Forms.MenuItem();
            this.panelContent = new System.Windows.Forms.Panel();
            this.labelVerified = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelLocale = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuItemWebsite
            // 
            this.menuItemWebsite.MenuItems.Add(this.menuItemAddPhoto);
            this.menuItemWebsite.MenuItems.Add(this.menuItemViewMap);
            this.menuItemWebsite.Text = "Action";
            // 
            // menuItemAddPhoto
            // 
            this.menuItemAddPhoto.Text = "Add Photo";
            this.menuItemAddPhoto.Click += new System.EventHandler(this.OnAddPhoto);
            // 
            // menuItemViewMap
            // 
            this.menuItemViewMap.Text = "View Map";
            this.menuItemViewMap.Click += new System.EventHandler(this.OnViewMap);
            // 
            // panelContent
            // 
            this.panelContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContent.AutoScroll = true;
            this.panelContent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelContent.Controls.Add(this.labelVerified);
            this.panelContent.Controls.Add(this.labelDescription);
            this.panelContent.Controls.Add(this.labelDate);
            this.panelContent.Controls.Add(this.labelLocale);
            this.panelContent.Controls.Add(this.labelTitle);
            this.panelContent.Controls.Add(this.pictureBoxImage);
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(240, 294);
            // 
            // labelVerified
            // 
            this.labelVerified.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelVerified.Location = new System.Drawing.Point(85, 63);
            this.labelVerified.Name = "labelVerified";
            this.labelVerified.Size = new System.Drawing.Size(151, 20);
            this.labelVerified.Text = "NOT VERIFIED";
            // 
            // labelDescription
            // 
            this.labelDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDescription.Location = new System.Drawing.Point(3, 90);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(233, 102);
            this.labelDescription.Text = "[Description]";
            // 
            // labelDate
            // 
            this.labelDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDate.Location = new System.Drawing.Point(85, 43);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(151, 20);
            this.labelDate.Text = "[Date]";
            // 
            // labelLocale
            // 
            this.labelLocale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLocale.Location = new System.Drawing.Point(85, 23);
            this.labelLocale.Name = "labelLocale";
            this.labelLocale.Size = new System.Drawing.Size(151, 20);
            this.labelLocale.Text = "[Locale]";
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTitle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(85, 3);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(151, 20);
            this.labelTitle.Text = "[Title]";
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.BackColor = System.Drawing.Color.Gray;
            this.pictureBoxImage.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(80, 80);
            // 
            // IncidentDetailsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.panelContent);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IncidentDetailsView";
            this.Text = "Incident Details";
            this.panelContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem menuItemAddPhoto;
        private System.Windows.Forms.MenuItem menuItemViewMap;
        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.Label labelVerified;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label labelLocale;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.PictureBox pictureBoxImage;
    }
}