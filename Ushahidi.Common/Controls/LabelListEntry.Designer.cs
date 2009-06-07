namespace Ushahidi.Common.Controls
{
    partial class LabelListEntry
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LabelListEntry));
            this.textBox = new System.Windows.Forms.TextBox();
            this.label = new System.Windows.Forms.Label();
            this.listView = new System.Windows.Forms.ListView();
            this.imageButton = new Ushahidi.Common.Controls.ImageButton();
            this.SuspendLayout();
            // 
            // textBox
            // 
            this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox.Location = new System.Drawing.Point(85, 3);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(127, 21);
            this.textBox.TabIndex = 5;
            // 
            // label
            // 
            this.label.Location = new System.Drawing.Point(4, 4);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(75, 20);
            this.label.Text = "Label";
            // 
            // listView
            // 
            this.listView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.listView.Location = new System.Drawing.Point(4, 28);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(233, 69);
            this.listView.TabIndex = 7;
            this.listView.View = System.Windows.Forms.View.Details;
            // 
            // imageButton
            // 
            this.imageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imageButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.imageButton.BackColorSelected = System.Drawing.Color.Black;
            this.imageButton.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageButton.DisabledImage = ((System.Drawing.Image)(resources.GetObject("imageButton.DisabledImage")));
            this.imageButton.Image = ((System.Drawing.Image)(resources.GetObject("imageButton.Image")));
            this.imageButton.Location = new System.Drawing.Point(216, 3);
            this.imageButton.Name = "imageButton";
            this.imageButton.Size = new System.Drawing.Size(21, 21);
            this.imageButton.TabIndex = 8;
            // 
            // LabelListEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.imageButton);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.label);
            this.Name = "LabelListEntry";
            this.Size = new System.Drawing.Size(240, 100);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.ListView listView;
        private ImageButton imageButton;
    }
}
