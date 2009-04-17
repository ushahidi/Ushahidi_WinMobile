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
            this.labelIncidentDetailTitle = new System.Windows.Forms.Label();
            this.labelIncidentDetailLocale = new System.Windows.Forms.Label();
            this.labelIncidentDetailDate = new System.Windows.Forms.Label();
            this.labelIncidentDetailVerified = new System.Windows.Forms.Label();
            this.labelIncidentDetailDescription = new System.Windows.Forms.Label();
            this.menuItemIncidentDetailAddPhoto = new System.Windows.Forms.MenuItem();
            this.menuItemIncidentDetailViewMap = new System.Windows.Forms.MenuItem();
            this.imageListBox = new Ushahidi.Common.Controls.ImageListBox();
            this.SuspendLayout();
            // 
            // menuItemAction
            // 
            this.menuItemAction.MenuItems.Add(this.menuItemIncidentDetailAddPhoto);
            this.menuItemAction.MenuItems.Add(this.menuItemIncidentDetailViewMap);
            this.menuItemAction.Text = "Action";
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.BackColor = System.Drawing.Color.Gray;
            this.pictureBoxImage.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(80, 80);
            // 
            // labelIncidentDetailTitle
            // 
            this.labelIncidentDetailTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelIncidentDetailTitle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelIncidentDetailTitle.Location = new System.Drawing.Point(84, 3);
            this.labelIncidentDetailTitle.Name = "labelIncidentDetailTitle";
            this.labelIncidentDetailTitle.Size = new System.Drawing.Size(88, 20);
            this.labelIncidentDetailTitle.Text = "[Title]";
            // 
            // labelIncidentDetailLocale
            // 
            this.labelIncidentDetailLocale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelIncidentDetailLocale.Location = new System.Drawing.Point(84, 23);
            this.labelIncidentDetailLocale.Name = "labelIncidentDetailLocale";
            this.labelIncidentDetailLocale.Size = new System.Drawing.Size(88, 20);
            this.labelIncidentDetailLocale.Text = "[Locale]";
            // 
            // labelIncidentDetailDate
            // 
            this.labelIncidentDetailDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelIncidentDetailDate.Location = new System.Drawing.Point(84, 43);
            this.labelIncidentDetailDate.Name = "labelIncidentDetailDate";
            this.labelIncidentDetailDate.Size = new System.Drawing.Size(88, 20);
            this.labelIncidentDetailDate.Text = "[Date]";
            // 
            // labelIncidentDetailVerified
            // 
            this.labelIncidentDetailVerified.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelIncidentDetailVerified.Location = new System.Drawing.Point(84, 63);
            this.labelIncidentDetailVerified.Name = "labelIncidentDetailVerified";
            this.labelIncidentDetailVerified.Size = new System.Drawing.Size(88, 20);
            this.labelIncidentDetailVerified.Text = "NOT VERIFIED";
            // 
            // labelIncidentDetailDescription
            // 
            this.labelIncidentDetailDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.labelIncidentDetailDescription.Location = new System.Drawing.Point(3, 86);
            this.labelIncidentDetailDescription.Name = "labelIncidentDetailDescription";
            this.labelIncidentDetailDescription.Size = new System.Drawing.Size(169, 40);
            this.labelIncidentDetailDescription.Text = "[Description]";
            // 
            // menuItemIncidentDetailAddPhoto
            // 
            this.menuItemIncidentDetailAddPhoto.Text = "Add Photo";
            // 
            // menuItemIncidentDetailViewMap
            // 
            this.menuItemIncidentDetailViewMap.Text = "View Map";
            // 
            // imageListBox
            // 
            this.imageListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.imageListBox.Location = new System.Drawing.Point(5, 129);
            this.imageListBox.Name = "imageListBox";
            this.imageListBox.Size = new System.Drawing.Size(168, 51);
            this.imageListBox.TabIndex = 6;
            // 
            // IncidentDetailsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(176, 180);
            this.Controls.Add(this.imageListBox);
            this.Controls.Add(this.labelIncidentDetailDescription);
            this.Controls.Add(this.labelIncidentDetailVerified);
            this.Controls.Add(this.labelIncidentDetailDate);
            this.Controls.Add(this.labelIncidentDetailLocale);
            this.Controls.Add(this.labelIncidentDetailTitle);
            this.Controls.Add(this.pictureBoxImage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IncidentDetailsView";
            this.Text = "Incident Details";
            this.Load += new System.EventHandler(this.IncidentDetailsView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.Label labelIncidentDetailTitle;
        private System.Windows.Forms.Label labelIncidentDetailLocale;
        private System.Windows.Forms.Label labelIncidentDetailDate;
        private System.Windows.Forms.Label labelIncidentDetailVerified;
        private System.Windows.Forms.Label labelIncidentDetailDescription;
        private System.Windows.Forms.MenuItem menuItemIncidentDetailAddPhoto;
        private System.Windows.Forms.MenuItem menuItemIncidentDetailViewMap;
        private Ushahidi.Common.Controls.ImageListBox imageListBox;
    }
}