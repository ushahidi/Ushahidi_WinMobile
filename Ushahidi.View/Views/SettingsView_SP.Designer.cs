namespace Ushahidi.View.Views
{
    partial class SettingsView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsView));
            this.textBoxDefaultLocation = new Ushahidi.Common.Controls.LabelTextBox();
            this.SuspendLayout();
            // 
            // menuItemSettings
            // 
            this.menuItemSettings.Enabled = false;
            // 
            // textBoxDefaultLocation
            // 
            this.textBoxDefaultLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDefaultLocation.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxDefaultLocation.Label = "Default Location";
            this.textBoxDefaultLocation.Location = new System.Drawing.Point(0, 0);
            this.textBoxDefaultLocation.Name = "textBoxDefaultLocation";
            this.textBoxDefaultLocation.Size = new System.Drawing.Size(176, 28);
            this.textBoxDefaultLocation.TabIndex = 1;
            // 
            // SettingsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(176, 180);
            this.Controls.Add(this.textBoxDefaultLocation);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SettingsView";
            this.Text = "Settings";
            this.ResumeLayout(false);

        }

        #endregion

        private Ushahidi.Common.Controls.LabelTextBox textBoxDefaultLocation;
    }
}