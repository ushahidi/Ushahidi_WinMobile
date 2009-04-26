namespace Ushahidi.View.Views
{
    partial class IncidentListView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IncidentListView));
            this.panelContent = new System.Windows.Forms.Panel();
            this.comboBoxIncidentListCategories = new Ushahidi.Common.Controls.LabelComboBox();
            this.listBoxIncidentListIncidents = new Ushahidi.Common.Controls.ScrollListBox();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuItemAction
            // 
            this.menuItemAction.Enabled = false;
            this.menuItemAction.Text = "Select";
            // 
            // menuItemIncidentList
            // 
            this.menuItemIncidentList.Enabled = false;
            // 
            // panelContent
            // 
            this.panelContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelContent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelContent.Controls.Add(this.comboBoxIncidentListCategories);
            this.panelContent.Controls.Add(this.listBoxIncidentListIncidents);
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(240, 294);
            // 
            // comboBoxIncidentListCategories
            // 
            this.comboBoxIncidentListCategories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxIncidentListCategories.BackColor = System.Drawing.Color.Gainsboro;
            this.comboBoxIncidentListCategories.Bold = true;
            this.comboBoxIncidentListCategories.DisplayMember = "Title";
            this.comboBoxIncidentListCategories.IsRequired = true;
            this.comboBoxIncidentListCategories.Label = "Category";
            this.comboBoxIncidentListCategories.Location = new System.Drawing.Point(0, 0);
            this.comboBoxIncidentListCategories.Name = "comboBoxIncidentListCategories";
            this.comboBoxIncidentListCategories.Size = new System.Drawing.Size(240, 28);
            this.comboBoxIncidentListCategories.TabIndex = 1;
            this.comboBoxIncidentListCategories.ValueMember = "ID";
            // 
            // listBoxIncidentListIncidents
            // 
            this.listBoxIncidentListIncidents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxIncidentListIncidents.AutoScroll = true;
            this.listBoxIncidentListIncidents.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listBoxIncidentListIncidents.BackColorEven = System.Drawing.Color.WhiteSmoke;
            this.listBoxIncidentListIncidents.BackColorOdd = System.Drawing.Color.Gainsboro;
            this.listBoxIncidentListIncidents.BackSelectedColor = System.Drawing.Color.Black;
            this.listBoxIncidentListIncidents.Location = new System.Drawing.Point(0, 28);
            this.listBoxIncidentListIncidents.Name = "listBoxIncidentListIncidents";
            this.listBoxIncidentListIncidents.SelectedIndex = -1;
            this.listBoxIncidentListIncidents.Size = new System.Drawing.Size(240, 266);
            this.listBoxIncidentListIncidents.TabIndex = 0;
            // 
            // IncidentListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.panelContent);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IncidentListView";
            this.Text = "Incident List";
            this.panelContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContent;
        private Ushahidi.Common.Controls.ScrollListBox listBoxIncidentListIncidents;
        private Ushahidi.Common.Controls.LabelComboBox comboBoxIncidentListCategories;

    }
}