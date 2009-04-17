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
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeaderSyncProgress = new System.Windows.Forms.ColumnHeader();
            this.progressBox = new Ushahidi.Common.Controls.ProgressBox();
            this.dateBoxSyncLastSync = new Ushahidi.Common.Controls.LabelDateBox();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuItemAction
            // 
            this.menuItemAction.Text = "Synchronize";
            // 
            // panelContent
            // 
            this.panelContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelContent.Controls.Add(this.listView);
            this.panelContent.Controls.Add(this.progressBox);
            this.panelContent.Controls.Add(this.dateBoxSyncLastSync);
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(240, 268);
            // 
            // listView
            // 
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.Columns.Add(this.columnHeaderSyncProgress);
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView.Location = new System.Drawing.Point(4, 56);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(233, 209);
            this.listView.TabIndex = 3;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderSyncProgress
            // 
            this.columnHeaderSyncProgress.Text = "Progress";
            this.columnHeaderSyncProgress.Width = 60;
            // 
            // progressBox
            // 
            this.progressBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.progressBox.Location = new System.Drawing.Point(0, 28);
            this.progressBox.Maximum = 6;
            this.progressBox.Minimum = 0;
            this.progressBox.Name = "progressBox";
            this.progressBox.Size = new System.Drawing.Size(240, 28);
            this.progressBox.TabIndex = 2;
            this.progressBox.Value = 0;
            // 
            // dateBox
            // 
            this.dateBoxSyncLastSync.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dateBoxSyncLastSync.BackColor = System.Drawing.Color.Gainsboro;
            this.dateBoxSyncLastSync.Bold = true;
            this.dateBoxSyncLastSync.Date = new System.DateTime(2009, 3, 26, 20, 58, 51, 644);
            this.dateBoxSyncLastSync.Enabled = false;
            this.dateBoxSyncLastSync.IsRequired = false;
            this.dateBoxSyncLastSync.Label = "Last Sync";
            this.dateBoxSyncLastSync.Location = new System.Drawing.Point(0, 0);
            this.dateBoxSyncLastSync.Name = "dateBox";
            this.dateBoxSyncLastSync.Size = new System.Drawing.Size(240, 28);
            this.dateBoxSyncLastSync.TabIndex = 1;
            // 
            // SyncView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.panelContent);
            this.Name = "SyncView";
            this.Text = "Synchronize";
            this.panelContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContent;
        private Ushahidi.Common.Controls.LabelDateBox dateBoxSyncLastSync;
        private Ushahidi.Common.Controls.ProgressBox progressBox;
        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnHeaderSyncProgress;
    }
}