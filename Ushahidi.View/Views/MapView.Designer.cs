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
            this.mapBox = new Ushahidi.Common.Controls.MapBox();
            this.textBoxLocationName = new Ushahidi.Common.Controls.LabelTextBox();
            this.menuItemDetectLocation = new System.Windows.Forms.MenuItem();
            this.menuItemZoomIn = new System.Windows.Forms.MenuItem();
            this.menuItemSeparator1 = new System.Windows.Forms.MenuItem();
            this.menuItemSelectLocation = new System.Windows.Forms.MenuItem();
            this.menuItemSeparator2 = new System.Windows.Forms.MenuItem();
            this.menuItemCancel = new System.Windows.Forms.MenuItem();
            this.menuItemZoomOut = new System.Windows.Forms.MenuItem();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuItemAction
            // 
            this.menuItemAction.MenuItems.Add(this.menuItemDetectLocation);
            this.menuItemAction.MenuItems.Add(this.menuItemSelectLocation);
            this.menuItemAction.MenuItems.Add(this.menuItemSeparator1);
            this.menuItemAction.MenuItems.Add(this.menuItemZoomIn);
            this.menuItemAction.MenuItems.Add(this.menuItemZoomOut);
            this.menuItemAction.MenuItems.Add(this.menuItemSeparator2);
            this.menuItemAction.MenuItems.Add(this.menuItemCancel);
            this.menuItemAction.Text = "Action";
            // 
            // panelContent
            // 
            this.panelContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelContent.Controls.Add(this.mapBox);
            this.panelContent.Controls.Add(this.textBoxLocationName);
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(176, 180);
            // 
            // mapBox
            // 
            this.mapBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.mapBox.Image = null;
            this.mapBox.Latitude = 0;
            this.mapBox.Location = new System.Drawing.Point(0, 45);
            this.mapBox.Longitude = 0;
            this.mapBox.Name = "mapBox";
            this.mapBox.Size = new System.Drawing.Size(176, 135);
            this.mapBox.TabIndex = 0;
            this.mapBox.ZoomLevel = 0;
            this.mapBox.ZoomIn += new System.EventHandler(this.OnZoomIn);
            this.mapBox.ZoomOut += new System.EventHandler(this.OnZoomOut);
            this.mapBox.MarkerChanged += new Ushahidi.Common.Controls.MapBox.MarkerChangedHandler(this.OnPlacemarkChanged);
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
            // menuItemDetectLocation
            // 
            this.menuItemDetectLocation.Text = "Detect Location";
            this.menuItemDetectLocation.Click += new System.EventHandler(this.OnDetectLocation);
            // 
            // menuItemZoomIn
            // 
            this.menuItemZoomIn.Text = "Zoom In";
            this.menuItemZoomIn.Click += new System.EventHandler(this.OnZoomIn);
            // 
            // menuItemSeparator1
            // 
            this.menuItemSeparator1.Text = "-";
            // 
            // menuItemSelectLocation
            // 
            this.menuItemSelectLocation.Text = "Select Location";
            this.menuItemSelectLocation.Click += new System.EventHandler(this.OnSelectLocation);
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
            // menuItemZoomOut
            // 
            this.menuItemZoomOut.Text = "Zoom Out";
            this.menuItemZoomOut.Click += new System.EventHandler(this.OnZoomOut);
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
        private System.Windows.Forms.MenuItem menuItemDetectLocation;
        private System.Windows.Forms.MenuItem menuItemZoomIn;
        private System.Windows.Forms.MenuItem menuItemSeparator1;
        private System.Windows.Forms.MenuItem menuItemSelectLocation;
        private System.Windows.Forms.MenuItem menuItemSeparator2;
        private System.Windows.Forms.MenuItem menuItemCancel;
        private Ushahidi.Common.Controls.LabelTextBox textBoxLocationName;
        private Ushahidi.Common.Controls.MapBox mapBox;
        private System.Windows.Forms.MenuItem menuItemZoomOut;

    }
}