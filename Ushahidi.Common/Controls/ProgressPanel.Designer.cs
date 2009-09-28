namespace Ushahidi.Common.Controls
{
    partial class ProgressPanel
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.timer = new System.Windows.Forms.Timer();
            this.button = new Ushahidi.Common.Controls.ImageButton();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label.Location = new System.Drawing.Point(4, 4);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(193, 20);
            this.label.Text = "Label";
            this.label.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(4, 26);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(190, 30);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.OnTick);
            // 
            // button
            // 
            this.button.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button.BackColor = System.Drawing.Color.Gainsboro;
            this.button.BackColorSelected = System.Drawing.Color.Gray;
            this.button.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.button.Label = "Button";
            this.button.Location = new System.Drawing.Point(4, 60);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(190, 30);
            this.button.TabIndex = 0;
            // 
            // ProgressPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.label);
            this.Controls.Add(this.button);
            this.Name = "ProgressPanel";
            this.Size = new System.Drawing.Size(200, 95);
            this.ResumeLayout(false);

        }

        #endregion

        private ImageButton button;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Timer timer;
    }
}
