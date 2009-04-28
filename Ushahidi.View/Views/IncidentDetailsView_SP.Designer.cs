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
            this.menuItemIncidentDetailsAddPhoto = new System.Windows.Forms.MenuItem();
            this.menuItemIncidentDetailsViewMap = new System.Windows.Forms.MenuItem();
            this.scrollListBoxMediaItems = new Ushahidi.Common.Controls.ScrollListBox();
            this.menuItemIncidentDetailsAddNews = new System.Windows.Forms.MenuItem();
            this.menuItemIncidentDetailsAddVideo = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // menuItemAction
            // 
            this.menuItemAction.MenuItems.Add(this.menuItemIncidentDetailsAddPhoto);
            this.menuItemAction.MenuItems.Add(this.menuItemIncidentDetailsViewMap);
            this.menuItemAction.MenuItems.Add(this.menuItemIncidentDetailsAddNews);
            this.menuItemAction.MenuItems.Add(this.menuItemIncidentDetailsAddVideo);
            this.menuItemAction.Text = "Action";
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.BackColor = System.Drawing.Color.Gray;
            this.pictureBoxImage.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(0, 0);
            // 
            // menuItemIncidentDetailsAddPhoto
            // 
            this.menuItemIncidentDetailsAddPhoto.Text = "Add Photo";
            // 
            // menuItemIncidentDetailsViewMap
            // 
            this.menuItemIncidentDetailsViewMap.Text = "View Map";
            // 
            // scrollListBoxMediaItems
            // 
            this.scrollListBoxMediaItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scrollListBoxMediaItems.AutoScroll = true;
            this.scrollListBoxMediaItems.BackColor = System.Drawing.Color.WhiteSmoke;
            this.scrollListBoxMediaItems.BackColorEven = System.Drawing.Color.Gainsboro;
            this.scrollListBoxMediaItems.BackColorOdd = System.Drawing.Color.WhiteSmoke;
            this.scrollListBoxMediaItems.BackSelectedColor = System.Drawing.Color.Black;
            this.scrollListBoxMediaItems.Location = new System.Drawing.Point(0, 0);
            this.scrollListBoxMediaItems.Name = "scrollListBoxMediaItems";
            this.scrollListBoxMediaItems.Size = new System.Drawing.Size(176, 180);
            this.scrollListBoxMediaItems.TabIndex = 0;
            // 
            // menuItemIncidentDetailsAddNews
            // 
            this.menuItemIncidentDetailsAddNews.Text = "Add News Link";
            // 
            // menuItemIncidentDetailsAddVideo
            // 
            this.menuItemIncidentDetailsAddVideo.Text = "Add Video Link";
            // 
            // IncidentDetailsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(176, 180);
            this.Controls.Add(this.scrollListBoxMediaItems);
            this.Controls.Add(this.pictureBoxImage);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IncidentDetailsView";
            this.Text = "Incident Details";
            this.Load += new System.EventHandler(this.IncidentDetailsView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.MenuItem menuItemIncidentDetailsAddPhoto;
        private System.Windows.Forms.MenuItem menuItemIncidentDetailsViewMap;
        private Ushahidi.Common.Controls.ScrollListBox scrollListBoxMediaItems;
        private System.Windows.Forms.MenuItem menuItemIncidentDetailsAddNews;
        private System.Windows.Forms.MenuItem menuItemIncidentDetailsAddVideo;
    }
}