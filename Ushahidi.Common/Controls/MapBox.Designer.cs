namespace Ushahidi.Common.Controls
{
    partial class MapBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapBox));
            this.imageList = new System.Windows.Forms.ImageList();
            this.SuspendLayout();
            // 
            // imageList
            // 
            this.imageList.ImageSize = new System.Drawing.Size(20, 34);
            this.imageList.Images.Clear();
            this.imageList.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
            // 
            // MapBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Name = "MapBox";
            this.Size = new System.Drawing.Size(176, 135);
            this.GotFocus += new System.EventHandler(this.OnGotFocus);
            this.Resize += new System.EventHandler(this.OnResize);
            this.LostFocus += new System.EventHandler(this.OnLostFocus);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList;

    }
}
