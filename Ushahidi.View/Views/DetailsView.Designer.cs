namespace Ushahidi.View.Views
{
    partial class DetailsView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailsView));
            this.menuItemAddPhoto = new System.Windows.Forms.MenuItem();
            this.panelContent = new System.Windows.Forms.Panel();
            this.listBoxDetails = new Ushahidi.Common.Controls.ScrollListBox();
            this.menuItemAddNews = new System.Windows.Forms.MenuItem();
            this.menuItemAddVideo = new System.Windows.Forms.MenuItem();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuItemAction
            // 
            this.menuItemAction.MenuItems.Add(this.menuItemAddPhoto);
            this.menuItemAction.MenuItems.Add(this.menuItemAddNews);
            this.menuItemAction.MenuItems.Add(this.menuItemAddVideo);
            this.menuItemAction.Text = "Action";
            // 
            // menuItemIncidentDetailsAddPhoto
            // 
            this.menuItemAddPhoto.Text = "Add Photo";
            // 
            // panelContent
            // 
            this.panelContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContent.AutoScroll = true;
            this.panelContent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelContent.Controls.Add(this.listBoxDetails);
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(240, 268);
            // 
            // scrollListBox
            // 
            this.listBoxDetails.AutoScroll = true;
            this.listBoxDetails.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listBoxDetails.BackColorEven = System.Drawing.Color.Gainsboro;
            this.listBoxDetails.BackColorOdd = System.Drawing.Color.WhiteSmoke;
            this.listBoxDetails.BackSelectedColor = System.Drawing.Color.Black;
            this.listBoxDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxDetails.Location = new System.Drawing.Point(0, 0);
            this.listBoxDetails.Name = "listBoxDetails";
            this.listBoxDetails.SelectedIndex = -1;
            this.listBoxDetails.Size = new System.Drawing.Size(240, 268);
            this.listBoxDetails.TabIndex = 0;
            // 
            // menuItemIncidentDetailsAddNews
            // 
            this.menuItemAddNews.Text = "Add News Link";
            // 
            // menuItemIncidentDetailsAddVideo
            // 
            this.menuItemAddVideo.Text = "Add Video Link";
            // 
            // IncidentDetailsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = false;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.panelContent);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DetailsView";
            this.Text = "Incident Details";
            this.panelContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem menuItemAddPhoto;
        private System.Windows.Forms.Panel panelContent;
        private Ushahidi.Common.Controls.ScrollListBox listBoxDetails;
        private System.Windows.Forms.MenuItem menuItemAddNews;
        private System.Windows.Forms.MenuItem menuItemAddVideo;
    }
}