namespace Ushahidi.Common.Controls
{
    partial class LabelImages
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
            this.label = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.Location = new System.Drawing.Point(4, 3);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(75, 20);
            // 
            // panel
            // 
            this.panel.Location = new System.Drawing.Point(85, 3);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(152, 50);
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.OnPanelPaint);
            // 
            // LabelImages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel);
            this.Controls.Add(this.label);
            this.Name = "LabelImages";
            this.Size = new System.Drawing.Size(240, 57);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Panel panel;
    }
}
