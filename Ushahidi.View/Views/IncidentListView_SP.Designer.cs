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
            this.listBoxIncidents = new Ushahidi.Common.Controls.ScrollListBox();
            this.comboBoxCategories = new Ushahidi.Common.Controls.LabelComboBox();
            this.SuspendLayout();
            // 
            // menuItemIncidentList
            // 
            this.menuItemIncidentList.Enabled = false;
            // 
            // menuItemAction
            // 
            this.menuItemAction.Enabled = false;
            this.menuItemAction.Text = "Select";
            // 
            // listBoxIncidents
            // 
            this.listBoxIncidents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxIncidents.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listBoxIncidents.BackColorEven = System.Drawing.Color.WhiteSmoke;
            this.listBoxIncidents.BackColorOdd = System.Drawing.Color.Gainsboro;
            this.listBoxIncidents.BackSelectedColor = System.Drawing.Color.Black;
            this.listBoxIncidents.Location = new System.Drawing.Point(0, 28);
            this.listBoxIncidents.Name = "listBoxIncidents";
            this.listBoxIncidents.Size = new System.Drawing.Size(176, 152);
            this.listBoxIncidents.TabIndex = 1;
            // 
            // comboBoxCategories
            // 
            this.comboBoxCategories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxCategories.BackColor = System.Drawing.Color.Gainsboro;
            this.comboBoxCategories.Bold = true;
            this.comboBoxCategories.DisplayMember = "Title";
            this.comboBoxCategories.IsRequired = true;
            this.comboBoxCategories.Label = "Category";
            this.comboBoxCategories.Location = new System.Drawing.Point(0, 0);
            this.comboBoxCategories.Name = "comboBoxCategories";
            this.comboBoxCategories.Size = new System.Drawing.Size(176, 28);
            this.comboBoxCategories.TabIndex = 32;
            this.comboBoxCategories.ValueMember = "ID";
            // 
            // IncidentListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(176, 180);
            this.Controls.Add(this.comboBoxCategories);
            this.Controls.Add(this.listBoxIncidents);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IncidentListView";
            this.Text = "Incident List";
            this.ResumeLayout(false);

        }

        #endregion

        private Ushahidi.Common.Controls.ScrollListBox listBoxIncidents;
        private Ushahidi.Common.Controls.LabelComboBox comboBoxCategories;
    }
}