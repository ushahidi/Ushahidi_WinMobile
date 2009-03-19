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
            this.listBoxIncidents = new Ushahidi.Common.Controls.ScrollListBox();
            this.comboBoxTypes = new System.Windows.Forms.ComboBox();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuItemWebsite
            // 
            this.menuItemWebsite.Text = "Select";
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
            this.panelContent.Controls.Add(this.listBoxIncidents);
            this.panelContent.Controls.Add(this.comboBoxTypes);
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(240, 294);
            // 
            // listBoxIncidents
            // 
            this.listBoxIncidents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxIncidents.AutoScroll = true;
            this.listBoxIncidents.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listBoxIncidents.BackColorEven = System.Drawing.Color.Gainsboro;
            this.listBoxIncidents.BackColorOdd = System.Drawing.Color.WhiteSmoke;
            this.listBoxIncidents.BackSelectedColor = System.Drawing.Color.Black;
            this.listBoxIncidents.Location = new System.Drawing.Point(0, 26);
            this.listBoxIncidents.Name = "listBoxIncidents";
            this.listBoxIncidents.Size = new System.Drawing.Size(240, 268);
            this.listBoxIncidents.TabIndex = 3;
            // 
            // comboBoxTypes
            // 
            this.comboBoxTypes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxTypes.Location = new System.Drawing.Point(3, 2);
            this.comboBoxTypes.Name = "comboBoxTypes";
            this.comboBoxTypes.Size = new System.Drawing.Size(234, 22);
            this.comboBoxTypes.TabIndex = 2;
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
        private Ushahidi.Common.Controls.ScrollListBox listBoxIncidents;
        private System.Windows.Forms.ComboBox comboBoxTypes;

    }
}