namespace Ushahidi.View.Views
{
    partial class AboutView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutView));
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.textBlockDescription = new Ushahidi.Common.Controls.TextBlock();
            this.SuspendLayout();
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(170, 85);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // textBlockDescription
            // 
            this.textBlockDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBlockDescription.AutoResize = false;
            this.textBlockDescription.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBlockDescription.Bold = true;
            this.textBlockDescription.Location = new System.Drawing.Point(3, 94);
            this.textBlockDescription.Name = "textBlockDescription";
            this.textBlockDescription.Size = new System.Drawing.Size(170, 75);
            this.textBlockDescription.TabIndex = 2;
            this.textBlockDescription.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // AboutView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(176, 180);
            this.Controls.Add(this.textBlockDescription);
            this.Controls.Add(this.pictureBoxLogo);
            this.Name = "AboutView";
            this.Text = "AboutView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private Ushahidi.Common.Controls.TextBlock textBlockDescription;
    }
}