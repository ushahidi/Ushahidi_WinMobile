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
            this.progressBox = new Ushahidi.Common.Controls.ProgressBox();
            this.checkBoxCategories = new Ushahidi.Common.Controls.LabelCheckBox();
            this.checkBoxLocales = new Ushahidi.Common.Controls.LabelCheckBox();
            this.checkBoxCountries = new Ushahidi.Common.Controls.LabelCheckBox();
            this.checkBoxIncidents = new Ushahidi.Common.Controls.LabelCheckBox();
            this.dateBox = new Ushahidi.Common.Controls.LabelDateBox();
            this.listViewProgress = new System.Windows.Forms.ListView();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuItemAction
            // 
            this.menuItemAction.Text = "Sync";
            // 
            // panelContent
            // 
            this.panelContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelContent.Controls.Add(this.progressBox);
            this.panelContent.Controls.Add(this.checkBoxCategories);
            this.panelContent.Controls.Add(this.checkBoxLocales);
            this.panelContent.Controls.Add(this.checkBoxCountries);
            this.panelContent.Controls.Add(this.checkBoxIncidents);
            this.panelContent.Controls.Add(this.dateBox);
            this.panelContent.Controls.Add(this.listViewProgress);
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(176, 180);
            // 
            // progressBox
            // 
            this.progressBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.progressBox.Location = new System.Drawing.Point(0, 140);
            this.progressBox.Maximum = 6;
            this.progressBox.Minimum = 0;
            this.progressBox.Name = "progressBox";
            this.progressBox.Size = new System.Drawing.Size(176, 50);
            this.progressBox.TabIndex = 16;
            this.progressBox.Value = 0;
            // 
            // checkBoxCategories
            // 
            this.checkBoxCategories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxCategories.BackColor = System.Drawing.Color.Gainsboro;
            this.checkBoxCategories.Bold = true;
            this.checkBoxCategories.CheckBox = "Refresh";
            this.checkBoxCategories.Checked = false;
            this.checkBoxCategories.Label = "Categories";
            this.checkBoxCategories.Location = new System.Drawing.Point(0, 112);
            this.checkBoxCategories.Name = "checkBoxCategories";
            this.checkBoxCategories.Size = new System.Drawing.Size(176, 28);
            this.checkBoxCategories.TabIndex = 15;
            // 
            // checkBoxLocales
            // 
            this.checkBoxLocales.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxLocales.BackColor = System.Drawing.Color.WhiteSmoke;
            this.checkBoxLocales.Bold = true;
            this.checkBoxLocales.CheckBox = "Refresh";
            this.checkBoxLocales.Checked = false;
            this.checkBoxLocales.Label = "Locales";
            this.checkBoxLocales.Location = new System.Drawing.Point(0, 84);
            this.checkBoxLocales.Name = "checkBoxLocales";
            this.checkBoxLocales.Size = new System.Drawing.Size(176, 28);
            this.checkBoxLocales.TabIndex = 14;
            // 
            // checkBoxCountries
            // 
            this.checkBoxCountries.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxCountries.BackColor = System.Drawing.Color.Gainsboro;
            this.checkBoxCountries.Bold = true;
            this.checkBoxCountries.CheckBox = "Refresh";
            this.checkBoxCountries.Checked = false;
            this.checkBoxCountries.Label = "Countries";
            this.checkBoxCountries.Location = new System.Drawing.Point(0, 56);
            this.checkBoxCountries.Name = "checkBoxCountries";
            this.checkBoxCountries.Size = new System.Drawing.Size(176, 28);
            this.checkBoxCountries.TabIndex = 13;
            // 
            // checkBoxIncidents
            // 
            this.checkBoxIncidents.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxIncidents.BackColor = System.Drawing.Color.WhiteSmoke;
            this.checkBoxIncidents.Bold = true;
            this.checkBoxIncidents.CheckBox = "Refresh";
            this.checkBoxIncidents.Checked = true;
            this.checkBoxIncidents.Enabled = false;
            this.checkBoxIncidents.Label = "Incidents";
            this.checkBoxIncidents.Location = new System.Drawing.Point(0, 28);
            this.checkBoxIncidents.Name = "checkBoxIncidents";
            this.checkBoxIncidents.Size = new System.Drawing.Size(176, 28);
            this.checkBoxIncidents.TabIndex = 12;
            // 
            // dateBox
            // 
            this.dateBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dateBox.BackColor = System.Drawing.Color.Gainsboro;
            this.dateBox.Bold = true;
            this.dateBox.Date = new System.DateTime(2009, 3, 26, 21, 24, 37, 697);
            this.dateBox.Enabled = false;
            this.dateBox.IsRequired = false;
            this.dateBox.Label = "Last Sync";
            this.dateBox.Location = new System.Drawing.Point(0, 0);
            this.dateBox.Name = "dateBox";
            this.dateBox.Size = new System.Drawing.Size(176, 28);
            this.dateBox.TabIndex = 6;
            // 
            // listViewProgress
            // 
            this.listViewProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewProgress.Location = new System.Drawing.Point(0, 0);
            this.listViewProgress.Name = "listViewProgress";
            this.listViewProgress.Size = new System.Drawing.Size(170, 28);
            this.listViewProgress.TabIndex = 3;
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
        private System.Windows.Forms.ListView listViewProgress;
        private Ushahidi.Common.Controls.LabelDateBox dateBox;
        private Ushahidi.Common.Controls.LabelCheckBox checkBoxCategories;
        private Ushahidi.Common.Controls.LabelCheckBox checkBoxLocales;
        private Ushahidi.Common.Controls.LabelCheckBox checkBoxCountries;
        private Ushahidi.Common.Controls.LabelCheckBox checkBoxIncidents;
        private Ushahidi.Common.Controls.ProgressBox progressBox;

    }
}