namespace Ushahidi.View.Views
{
    partial class HomeView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeView));
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.buttonViewIncidents = new System.Windows.Forms.Button();
            this.buttonAddIncident = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(234, 125);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // buttonViewIncidents
            // 
            this.buttonViewIncidents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonViewIncidents.BackColor = System.Drawing.Color.Silver;
            this.buttonViewIncidents.Location = new System.Drawing.Point(4, 135);
            this.buttonViewIncidents.Name = "buttonViewIncidents";
            this.buttonViewIncidents.Size = new System.Drawing.Size(233, 60);
            this.buttonViewIncidents.TabIndex = 2;
            this.buttonViewIncidents.Text = "View Incidents";
            this.buttonViewIncidents.Click += new System.EventHandler(this.OnViewIncidents);
            // 
            // buttonAddIncident
            // 
            this.buttonAddIncident.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddIncident.BackColor = System.Drawing.Color.Silver;
            this.buttonAddIncident.Location = new System.Drawing.Point(3, 201);
            this.buttonAddIncident.Name = "buttonAddIncident";
            this.buttonAddIncident.Size = new System.Drawing.Size(233, 60);
            this.buttonAddIncident.TabIndex = 3;
            this.buttonAddIncident.Text = "Add Incident";
            this.buttonAddIncident.Click += new System.EventHandler(this.OnAddIncident);
            // 
            // HomeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.buttonAddIncident);
            this.Controls.Add(this.buttonViewIncidents);
            this.Controls.Add(this.pictureBoxLogo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = true;
            this.Name = "HomeView";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Button buttonViewIncidents;
        private System.Windows.Forms.Button buttonAddIncident;
    }
}