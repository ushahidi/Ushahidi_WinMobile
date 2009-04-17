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
            this.listBoxIncidentListIncidents = new Ushahidi.Common.Controls.ScrollListBox();
            this.comboBoxIncidentListCategories = new Ushahidi.Common.Controls.LabelComboBox();
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
            // listBoxIncidentListIncidents
            // 
            this.listBoxIncidentListIncidents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxIncidentListIncidents.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listBoxIncidentListIncidents.BackColorEven = System.Drawing.Color.WhiteSmoke;
            this.listBoxIncidentListIncidents.BackColorOdd = System.Drawing.Color.Gainsboro;
            this.listBoxIncidentListIncidents.BackSelectedColor = System.Drawing.Color.Black;
            this.listBoxIncidentListIncidents.Location = new System.Drawing.Point(0, 28);
            this.listBoxIncidentListIncidents.Name = "listBoxIncidentListIncidents";
            this.listBoxIncidentListIncidents.Size = new System.Drawing.Size(176, 152);
            this.listBoxIncidentListIncidents.TabIndex = 2;
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
            this.comboBoxIncidentListCategories.Size = new System.Drawing.Size(176, 28);
            this.comboBoxIncidentListCategories.TabIndex = 1;
            this.comboBoxIncidentListCategories.ValueMember = "ID";
            // 
            // IncidentListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(176, 180);
            this.Controls.Add(this.comboBoxIncidentListCategories);
            this.Controls.Add(this.listBoxIncidentListIncidents);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IncidentListView";
            this.Text = "Incident List";
            this.ResumeLayout(false);

        }

        #endregion

        private Ushahidi.Common.Controls.ScrollListBox listBoxIncidentListIncidents;
        private Ushahidi.Common.Controls.LabelComboBox comboBoxIncidentListCategories;
    }
}