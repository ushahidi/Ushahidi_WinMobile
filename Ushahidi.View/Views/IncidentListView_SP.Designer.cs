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
            this.comboBoxTypes = new System.Windows.Forms.ComboBox();
            this.listBoxIncidents = new Ushahidi.Common.Controls.ScrollListBox();
            this.SuspendLayout();
            // 
            // menuItemIncidentList
            // 
            this.menuItemIncidentList.Enabled = false;
            // 
            // menuItemAction
            // 
            this.menuItemAction.Text = "Select";
            // 
            // comboBoxFilter
            // 
            this.comboBoxTypes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxTypes.Location = new System.Drawing.Point(3, 3);
            this.comboBoxTypes.Name = "comboBoxFilter";
            this.comboBoxTypes.Size = new System.Drawing.Size(170, 22);
            this.comboBoxTypes.TabIndex = 0;
            // 
            // listBoxIncidents
            // 
            this.listBoxIncidents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxIncidents.Location = new System.Drawing.Point(0, 26);
            this.listBoxIncidents.Name = "listBoxIncidents";
            this.listBoxIncidents.Size = new System.Drawing.Size(176, 154);
            this.listBoxIncidents.TabIndex = 1;
            this.listBoxIncidents.ItemSelected += new Ushahidi.Common.Controls.ScrollListBox.ItemHandler(this.OnIncidentsItemSelected);
            this.listBoxIncidents.IndexChanged += new Ushahidi.Common.Controls.ScrollListBox.ItemHandler(this.OnIncidentsIndexChanged);
            // 
            // IncidentListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(176, 180);
            this.Controls.Add(this.listBoxIncidents);
            this.Controls.Add(this.comboBoxTypes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IncidentListView";
            this.Text = "Incident List";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxTypes;
        private Ushahidi.Common.Controls.ScrollListBox listBoxIncidents;
    }
}