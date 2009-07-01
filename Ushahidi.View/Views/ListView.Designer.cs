namespace Ushahidi.View.Views
{
    partial class ListView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ListView));
            this.panelContent = new System.Windows.Forms.Panel();
            this.comboBoxCategories = new Ushahidi.Common.Controls.LabelComboBox();
            this.scrollListBox = new Ushahidi.Common.Controls.ScrollListBox();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuItemAction
            // 
            this.menuItemAction.Enabled = false;
            this.menuItemAction.Text = "Select";
            this.menuItemAction.Click += new System.EventHandler(this.OnViewIncident);
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
            this.panelContent.Controls.Add(this.comboBoxCategories);
            this.panelContent.Controls.Add(this.scrollListBox);
            this.panelContent.Location = new System.Drawing.Point(0, 0);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(176, 180);
            // 
            // comboBoxCategories
            // 
            this.comboBoxCategories.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxCategories.BackColor = System.Drawing.Color.Gainsboro;
            this.comboBoxCategories.Bold = true;
            this.comboBoxCategories.DataSource = null;
            this.comboBoxCategories.DisplayMember = "Title";
            this.comboBoxCategories.IsRequired = false;
            this.comboBoxCategories.Label = "Label";
            this.comboBoxCategories.Location = new System.Drawing.Point(0, 0);
            this.comboBoxCategories.Name = "comboBoxCategories";
            this.comboBoxCategories.SelectedIndex = -1;
            this.comboBoxCategories.SelectedItem = null;
            this.comboBoxCategories.SelectedText = "";
            this.comboBoxCategories.Size = new System.Drawing.Size(176, 45);
            this.comboBoxCategories.TabIndex = 1;
            this.comboBoxCategories.ValueMember = "ID";
            this.comboBoxCategories.SelectedIndexChanged += new System.EventHandler(this.OnCategoryChanged);
            // 
            // scrollListBox
            // 
            this.scrollListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.scrollListBox.AutoScroll = true;
            this.scrollListBox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.scrollListBox.BackColorEven = System.Drawing.Color.Gainsboro;
            this.scrollListBox.BackColorOdd = System.Drawing.Color.WhiteSmoke;
            this.scrollListBox.BackSelectedColor = System.Drawing.Color.Black;
            this.scrollListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scrollListBox.ForeColor = System.Drawing.Color.Black;
            this.scrollListBox.ForeSelectedColor = System.Drawing.Color.White;
            this.scrollListBox.Location = new System.Drawing.Point(3, 45);
            this.scrollListBox.Name = "scrollListBox";
            this.scrollListBox.SelectedIndex = -1;
            this.scrollListBox.SelectedItem = null;
            this.scrollListBox.Size = new System.Drawing.Size(170, 132);
            this.scrollListBox.TabIndex = 0;
            this.scrollListBox.IndexChanged += new Ushahidi.Common.Controls.ScrollListBox.ItemHandler(this.OnIncidentChanged);
            this.scrollListBox.ItemSelected += new Ushahidi.Common.Controls.ScrollListBox.ItemHandler(this.OnIncidentSelected);
            // 
            // ListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(176, 180);
            this.Controls.Add(this.panelContent);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ListView";
            this.Text = "Incident List";
            this.panelContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelContent;
        private Ushahidi.Common.Controls.LabelComboBox comboBoxCategories;
        private Ushahidi.Common.Controls.ScrollListBox scrollListBox;

    }
}