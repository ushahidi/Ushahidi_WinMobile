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
            this.panelContent = new System.Windows.Forms.Panel();
            this.buttonIncidentMap = new Ushahidi.Common.Controls.ImageButton();
            this.buttonSynchronize = new Ushahidi.Common.Controls.ImageButton();
            this.buttonAddIncident = new Ushahidi.Common.Controls.ImageButton();
            this.buttonIncidentList = new Ushahidi.Common.Controls.ImageButton();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelContent
            // 
            this.panelContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContent.AutoScroll = true;
            this.panelContent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelContent.Controls.Add(this.buttonIncidentMap);
            this.panelContent.Controls.Add(this.buttonSynchronize);
            this.panelContent.Controls.Add(this.buttonAddIncident);
            this.panelContent.Controls.Add(this.buttonIncidentList);
            this.panelContent.Controls.Add(this.pictureBoxLogo);
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(176, 240);
            // 
            // buttonIncidentMap
            // 
            this.buttonIncidentMap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonIncidentMap.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonIncidentMap.BackColorSelected = System.Drawing.Color.Gray;
            this.buttonIncidentMap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.buttonIncidentMap.DisabledImage = null;
            this.buttonIncidentMap.Image = null;
            this.buttonIncidentMap.Label = "Incident Map";
            this.buttonIncidentMap.Location = new System.Drawing.Point(3, 131);
            this.buttonIncidentMap.Momentary = false;
            this.buttonIncidentMap.Name = "buttonIncidentMap";
            this.buttonIncidentMap.Pressed = false;
            this.buttonIncidentMap.Size = new System.Drawing.Size(169, 25);
            this.buttonIncidentMap.TabIndex = 5;
            this.buttonIncidentMap.Visible = false;
            // 
            // buttonSynchronize
            // 
            this.buttonSynchronize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSynchronize.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonSynchronize.BackColorSelected = System.Drawing.Color.Gray;
            this.buttonSynchronize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.buttonSynchronize.DisabledImage = null;
            this.buttonSynchronize.Image = null;
            this.buttonSynchronize.Label = "Synchronize";
            this.buttonSynchronize.Location = new System.Drawing.Point(4, 192);
            this.buttonSynchronize.Momentary = false;
            this.buttonSynchronize.Name = "buttonSynchronize";
            this.buttonSynchronize.Pressed = false;
            this.buttonSynchronize.Size = new System.Drawing.Size(169, 25);
            this.buttonSynchronize.TabIndex = 3;
            this.buttonSynchronize.Click += new System.EventHandler(this.OnSynchronize);
            // 
            // buttonAddIncident
            // 
            this.buttonAddIncident.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddIncident.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonAddIncident.BackColorSelected = System.Drawing.Color.Gray;
            this.buttonAddIncident.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.buttonAddIncident.DisabledImage = null;
            this.buttonAddIncident.Image = null;
            this.buttonAddIncident.Label = "Add Incident";
            this.buttonAddIncident.Location = new System.Drawing.Point(4, 161);
            this.buttonAddIncident.Momentary = false;
            this.buttonAddIncident.Name = "buttonAddIncident";
            this.buttonAddIncident.Pressed = false;
            this.buttonAddIncident.Size = new System.Drawing.Size(169, 25);
            this.buttonAddIncident.TabIndex = 2;
            this.buttonAddIncident.Click += new System.EventHandler(this.OnAddIncident);
            // 
            // buttonIncidentList
            // 
            this.buttonIncidentList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonIncidentList.BackColor = System.Drawing.Color.Gainsboro;
            this.buttonIncidentList.BackColorSelected = System.Drawing.Color.Gray;
            this.buttonIncidentList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.buttonIncidentList.DisabledImage = null;
            this.buttonIncidentList.Image = null;
            this.buttonIncidentList.Label = "Incident List";
            this.buttonIncidentList.Location = new System.Drawing.Point(4, 100);
            this.buttonIncidentList.Momentary = false;
            this.buttonIncidentList.Name = "buttonIncidentList";
            this.buttonIncidentList.Pressed = false;
            this.buttonIncidentList.Size = new System.Drawing.Size(169, 25);
            this.buttonIncidentList.TabIndex = 0;
            this.buttonIncidentList.Click += new System.EventHandler(this.OnListIncident);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(170, 91);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // HomeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(176, 180);
            this.Controls.Add(this.panelContent);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "HomeView";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Resize += new System.EventHandler(this.OnResize);
            this.panelContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContent;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private Ushahidi.Common.Controls.ImageButton buttonIncidentMap;
        private Ushahidi.Common.Controls.ImageButton buttonSynchronize;
        private Ushahidi.Common.Controls.ImageButton buttonAddIncident;
        private Ushahidi.Common.Controls.ImageButton buttonIncidentList;

    }
}