namespace Ushahidi.View.Views
{
    partial class SyncView
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
            this.panelContent = new System.Windows.Forms.Panel();
            this.checkBoxDownloadIncidents = new System.Windows.Forms.CheckBox();
            this.checkBoxDownloadMedia = new System.Windows.Forms.CheckBox();
            this.checkBoxDownloadMaps = new System.Windows.Forms.CheckBox();
            this.textBoxServer = new Ushahidi.Common.Controls.LabelTextBox();
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeaderProgress = new System.Windows.Forms.ColumnHeader();
            this.progressBox = new Ushahidi.Common.Controls.ProgressBox();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuItemAction
            // 
            this.menuItemAction.Text = "Synchronize";
            this.menuItemAction.Click += new System.EventHandler(this.OnSynchronize);
            // 
            // panelContent
            // 
            this.panelContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelContent.Controls.Add(this.checkBoxDownloadIncidents);
            this.panelContent.Controls.Add(this.checkBoxDownloadMedia);
            this.panelContent.Controls.Add(this.checkBoxDownloadMaps);
            this.panelContent.Controls.Add(this.textBoxServer);
            this.panelContent.Controls.Add(this.listView);
            this.panelContent.Controls.Add(this.progressBox);
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(176, 180);
            // 
            // checkBoxDownloadIncidents
            // 
            this.checkBoxDownloadIncidents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxDownloadIncidents.Font = new System.Drawing.Font("Segoe Condensed", 10F, System.Drawing.FontStyle.Bold);
            this.checkBoxDownloadIncidents.Location = new System.Drawing.Point(4, 47);
            this.checkBoxDownloadIncidents.Name = "checkBoxDownloadIncidents";
            this.checkBoxDownloadIncidents.Size = new System.Drawing.Size(169, 22);
            this.checkBoxDownloadIncidents.TabIndex = 2;
            this.checkBoxDownloadIncidents.Text = "Download Incidents";
            // 
            // checkBoxDownloadMedia
            // 
            this.checkBoxDownloadMedia.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxDownloadMedia.Font = new System.Drawing.Font("Segoe Condensed", 10F, System.Drawing.FontStyle.Bold);
            this.checkBoxDownloadMedia.Location = new System.Drawing.Point(4, 69);
            this.checkBoxDownloadMedia.Name = "checkBoxDownloadMedia";
            this.checkBoxDownloadMedia.Size = new System.Drawing.Size(169, 22);
            this.checkBoxDownloadMedia.TabIndex = 3;
            this.checkBoxDownloadMedia.Text = "Download Media";
            // 
            // checkBoxDownloadMaps
            // 
            this.checkBoxDownloadMaps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxDownloadMaps.Font = new System.Drawing.Font("Segoe Condensed", 10F, System.Drawing.FontStyle.Bold);
            this.checkBoxDownloadMaps.Location = new System.Drawing.Point(4, 91);
            this.checkBoxDownloadMaps.Name = "checkBoxDownloadMaps";
            this.checkBoxDownloadMaps.Size = new System.Drawing.Size(169, 22);
            this.checkBoxDownloadMaps.TabIndex = 4;
            this.checkBoxDownloadMaps.Text = "Download Maps";
            // 
            // textBoxServer
            // 
            this.textBoxServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxServer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBoxServer.IsRequired = false;
            this.textBoxServer.Label = "Server";
            this.textBoxServer.Location = new System.Drawing.Point(0, 0);
            this.textBoxServer.Multiline = false;
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.Size = new System.Drawing.Size(176, 45);
            this.textBoxServer.TabIndex = 1;
            this.textBoxServer.Value = "";
            // 
            // listView
            // 
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.Columns.Add(this.columnHeaderProgress);
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView.Location = new System.Drawing.Point(4, 142);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(169, 35);
            this.listView.TabIndex = 0;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderProgress
            // 
            this.columnHeaderProgress.Text = "Progress";
            this.columnHeaderProgress.Width = 60;
            // 
            // progressBox
            // 
            this.progressBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.progressBox.Location = new System.Drawing.Point(0, 114);
            this.progressBox.Maximum = 0;
            this.progressBox.Minimum = 0;
            this.progressBox.Name = "progressBox";
            this.progressBox.Size = new System.Drawing.Size(176, 28);
            this.progressBox.TabIndex = 0;
            this.progressBox.TabStop = false;
            this.progressBox.Value = 0;
            // 
            // SyncView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(176, 180);
            this.Controls.Add(this.panelContent);
            this.Name = "SyncView";
            this.Text = "Synchronize";
            this.panelContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContent;
        private Ushahidi.Common.Controls.LabelTextBox textBoxServer;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnHeaderProgress;
        private Ushahidi.Common.Controls.ProgressBox progressBox;
        private System.Windows.Forms.CheckBox checkBoxDownloadMaps;
        private System.Windows.Forms.CheckBox checkBoxDownloadMedia;
        private System.Windows.Forms.CheckBox checkBoxDownloadIncidents;
    }
}