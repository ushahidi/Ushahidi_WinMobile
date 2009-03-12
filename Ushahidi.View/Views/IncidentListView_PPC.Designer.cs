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
            this.comboBoxFilter = new System.Windows.Forms.ComboBox();
            this.listBoxIncidents = new Ushahidi.Common.Controls.ScrollListBox();
            this.SuspendLayout();
            // 
            // menuItemAction
            // 
            this.menuItemWebsite.Text = "Select";
            // 
            // menuItemIncidentList
            // 
            this.menuItemIncidentList.Enabled = false;
            // 
            // comboBoxFilter
            // 
            this.comboBoxFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxFilter.Location = new System.Drawing.Point(3, 4);
            this.comboBoxFilter.Name = "comboBoxFilter";
            this.comboBoxFilter.Size = new System.Drawing.Size(234, 22);
            this.comboBoxFilter.TabIndex = 0;
            this.comboBoxFilter.SelectedIndexChanged += new System.EventHandler(this.OnFilterChanged);
            // 
            // listBoxIncidents
            // 
            this.listBoxIncidents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxIncidents.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listBoxIncidents.BackColorEven = System.Drawing.Color.Gainsboro;
            this.listBoxIncidents.BackColorOdd = System.Drawing.Color.WhiteSmoke;
            this.listBoxIncidents.Location = new System.Drawing.Point(0, 30);
            this.listBoxIncidents.Name = "listBoxIncidents";
            this.listBoxIncidents.Size = new System.Drawing.Size(240, 264);
            this.listBoxIncidents.TabIndex = 1;
            this.listBoxIncidents.ItemSelected += new Ushahidi.Common.Controls.ScrollListBox.ItemHandler(this.OnIncidentsItemSelected);
            this.listBoxIncidents.IndexChanged += new Ushahidi.Common.Controls.ScrollListBox.ItemHandler(this.OnIncidentsIndexChanged);
            // 
            // IncidentListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.listBoxIncidents);
            this.Controls.Add(this.comboBoxFilter);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IncidentListView";
            this.Text = "Incident List";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxFilter;
        private Ushahidi.Common.Controls.ScrollListBox listBoxIncidents;
    }
}