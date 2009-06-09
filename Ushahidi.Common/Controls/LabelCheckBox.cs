using System;
using System.Drawing;
using System.Windows.Forms;
using Ushahidi.Common.Extensions;

namespace Ushahidi.Common.Controls
{
    /// <summary>
    /// Label check box
    /// </summary>
    public partial class LabelCheckBox : UserControl
    {
        public LabelCheckBox()
        {
            InitializeComponent();
            label.Font = label.Font.ToBold();
        }

        /// <summary>
        /// Checked
        /// </summary>
        public bool Checked
        {
            get { return checkBox.Checked; }
            set { checkBox.Checked = value; }
        }

        /// <summary>
        /// Enabled
        /// </summary>
        public new bool Enabled
        {
            get { return checkBox.Enabled; }
            set { checkBox.Enabled = value; }
        }

        /// <summary>
        /// Label
        /// </summary>
        public override string Text
        {
            get { return label.Text; }
            set { label.Text = value; }
        }

        /// <summary>
        /// Label
        /// </summary>
        public string Label
        {
            get { return label.Text; }
            set { label.Text = value; }
        }

        /// <summary>
        /// Text
        /// </summary>
        public string CheckBox
        {
            get { return checkBox.Text; }
            set { checkBox.Text = value; }
        }

        /// <summary>
        /// Font
        /// </summary>
        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                label.Font = value.ToBold();
            }
        }

        /// <summary>
        /// Get or set the background color
        /// </summary>
        public override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = label.BackColor = checkBox.BackColor = value; }
        }

        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set { base.ForeColor = label.ForeColor = value; }
        }

        /// <summary>
        /// Check state change
        /// </summary>
        public event EventHandler CheckStateChanged
        {
            add { checkBox.CheckStateChanged += value; }
            remove { checkBox.CheckStateChanged -= value; }
        }
    }
}
