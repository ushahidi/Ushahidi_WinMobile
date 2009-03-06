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
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelLocale = new System.Windows.Forms.Label();
            this.labelDate = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelVerified = new System.Windows.Forms.Label();
            this.menuItemAddPhoto = new System.Windows.Forms.MenuItem();
            this.menuItemViewMap = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // menuItemAction
            // 
            this.menuItemAction.MenuItems.Add(this.menuItemAddPhoto);
            this.menuItemAction.MenuItems.Add(this.menuItemViewMap);
            this.menuItemAction.Text = "Action";
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.BackColor = System.Drawing.Color.Gray;
            this.pictureBoxImage.Location = new System.Drawing.Point(4, 4);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(80, 80);
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTitle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(86, 4);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(151, 20);
            this.labelTitle.Text = "[Title]";
            // 
            // labelLocale
            // 
            this.labelLocale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLocale.Location = new System.Drawing.Point(86, 24);
            this.labelLocale.Name = "labelLocale";
            this.labelLocale.Size = new System.Drawing.Size(151, 20);
            this.labelLocale.Text = "[Locale]";
            // 
            // labelDate
            // 
            this.labelDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDate.Location = new System.Drawing.Point(86, 44);
            this.labelDate.Name = "labelDate";
            this.labelDate.Size = new System.Drawing.Size(151, 20);
            this.labelDate.Text = "[Date]";
            // 
            // labelDescription
            // 
            this.labelDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelDescription.Location = new System.Drawing.Point(4, 91);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(233, 102);
            this.labelDescription.Text = "[Description]";
            // 
            // labelVerified
            // 
            this.labelVerified.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelVerified.Location = new System.Drawing.Point(86, 64);
            this.labelVerified.Name = "labelVerified";
            this.labelVerified.Size = new System.Drawing.Size(151, 20);
            this.labelVerified.Text = "NOT VERIFIED";
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
            // IncidentDetailsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.labelVerified);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelDate);
            this.Controls.Add(this.labelLocale);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.pictureBoxImage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IncidentDetailsView";
            this.Text = "Incident Details";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelLocale;
        private System.Windows.Forms.Label labelDate;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelVerified;
        private System.Windows.Forms.MenuItem menuItemAddPhoto;
        private System.Windows.Forms.MenuItem menuItemViewMap;
    }
}