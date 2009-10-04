namespace Ushahidi.View.Views
{
    partial class MapView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapView));
            this.panelContent = new System.Windows.Forms.Panel();
            this.textBoxLocationName = new Ushahidi.Common.Controls.LabelTextBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.menuItemDetectLocation = new System.Windows.Forms.MenuItem();
            this.menuItemZoom = new System.Windows.Forms.MenuItem();
            this.menuItemSeparator1 = new System.Windows.Forms.MenuItem();
            this.menuItemAddLocation = new System.Windows.Forms.MenuItem();
            this.menuItemSeparator2 = new System.Windows.Forms.MenuItem();
            this.menuItemCancel = new System.Windows.Forms.MenuItem();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuItemAction
            // 
            this.menuItemAction.MenuItems.Add(this.menuItemAddLocation);
            this.menuItemAction.MenuItems.Add(this.menuItemDetectLocation);
            this.menuItemAction.MenuItems.Add(this.menuItemSeparator1);
            this.menuItemAction.MenuItems.Add(this.menuItemZoom);
            this.menuItemAction.MenuItems.Add(this.menuItemSeparator2);
            this.menuItemAction.MenuItems.Add(this.menuItemCancel);
            this.menuItemAction.Text = "Action";
            // 
            // menuItemMenu
            // 
            this.menuItemMenu.Enabled = false;
            // 
            // panelContent
            // 
            this.panelContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelContent.Controls.Add(this.textBoxLocationName);
            this.panelContent.Controls.Add(this.pictureBox);
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(176, 180);
            // 
            // textBoxLocationName
            // 
            this.textBoxLocationName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxLocationName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxLocationName.IsRequired = true;
            this.textBoxLocationName.Label = "Location Name";
            this.textBoxLocationName.Location = new System.Drawing.Point(0, 0);
            this.textBoxLocationName.Multiline = false;
            this.textBoxLocationName.Name = "textBoxLocationName";
            this.textBoxLocationName.Size = new System.Drawing.Size(176, 45);
            this.textBoxLocationName.TabIndex = 1;
            this.textBoxLocationName.Value = "";
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.Location = new System.Drawing.Point(0, 45);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(176, 135);
            // 
            // menuItemDetectLocation
            // 
            this.menuItemDetectLocation.Text = "Detect Location";
            this.menuItemDetectLocation.Click += new System.EventHandler(this.OnDetectLocation);
            // 
            // menuItemZoom
            // 
            this.menuItemZoom.Text = "Zoom Level";
            // 
            // menuItemSeparator1
            // 
            this.menuItemSeparator1.Text = "-";
            // 
            // menuItemAddLocation
            // 
            this.menuItemAddLocation.Text = "Add Location";
            this.menuItemAddLocation.Click += new System.EventHandler(this.OnAddLocation);
            // 
            // menuItemSeparator2
            // 
            this.menuItemSeparator2.Text = "-";
            // 
            // menuItemCancel
            // 
            this.menuItemCancel.Text = "Cancel";
            this.menuItemCancel.Click += new System.EventHandler(this.OnCancel);
            // 
            // MapView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(176, 180);
            this.Controls.Add(this.panelContent);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MapView";
            this.Text = "Incident Map";
            this.panelContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.MenuItem menuItemDetectLocation;
        private System.Windows.Forms.MenuItem menuItemZoom;
        private System.Windows.Forms.MenuItem menuItemSeparator1;
        private System.Windows.Forms.MenuItem menuItemAddLocation;
        private System.Windows.Forms.MenuItem menuItemSeparator2;
        private System.Windows.Forms.MenuItem menuItemCancel;
        private Ushahidi.Common.Controls.LabelTextBox textBoxLocationName;

    }
}