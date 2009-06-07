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
            this.menuItemIncidentDetailsAddPhoto = new System.Windows.Forms.MenuItem();
            this.panelContent = new System.Windows.Forms.Panel();
            this.scrollListBox = new Ushahidi.Common.Controls.ScrollListBox();
            this.menuItemIncidentDetailsAddNews = new System.Windows.Forms.MenuItem();
            this.menuItemIncidentDetailsAddVideo = new System.Windows.Forms.MenuItem();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuItemAction
            // 
            this.menuItemAction.MenuItems.Add(this.menuItemIncidentDetailsAddPhoto);
            this.menuItemAction.MenuItems.Add(this.menuItemIncidentDetailsAddNews);
            this.menuItemAction.MenuItems.Add(this.menuItemIncidentDetailsAddVideo);
            this.menuItemAction.Text = "Action";
            // 
            // menuItemIncidentDetailsAddPhoto
            // 
            this.menuItemIncidentDetailsAddPhoto.Text = "Add Photo";
            // 
            // panelContent
            // 
            this.panelContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContent.AutoScroll = true;
            this.panelContent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelContent.Controls.Add(this.scrollListBox);
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(240, 268);
            // 
            // scrollListBox
            // 
            this.scrollListBox.AutoScroll = true;
            this.scrollListBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.scrollListBox.BackColorEven = System.Drawing.Color.Gainsboro;
            this.scrollListBox.BackColorOdd = System.Drawing.Color.WhiteSmoke;
            this.scrollListBox.BackSelectedColor = System.Drawing.Color.Black;
            this.scrollListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scrollListBox.Location = new System.Drawing.Point(0, 0);
            this.scrollListBox.Name = "scrollListBox";
            this.scrollListBox.SelectedIndex = -1;
            this.scrollListBox.Size = new System.Drawing.Size(240, 268);
            this.scrollListBox.TabIndex = 0;
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

        private System.Windows.Forms.MenuItem menuItemIncidentDetailsAddPhoto;
        private System.Windows.Forms.Panel panelContent;
        private Ushahidi.Common.Controls.ScrollListBox scrollListBox;
        private System.Windows.Forms.MenuItem menuItemIncidentDetailsAddNews;
        private System.Windows.Forms.MenuItem menuItemIncidentDetailsAddVideo;
    }
}