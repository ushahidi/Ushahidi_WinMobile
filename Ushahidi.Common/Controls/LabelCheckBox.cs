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
        /// Text
        /// </summary>
        public string CheckBox
        {
            get { return checkBox.Text; }
            set { checkBox.Text = value; }
        }

        /// <summary>
        /// Label bold?
        /// </summary>
        public bool Bold
        {
            get { return label.Font.Style == FontStyle.Bold; }
            set { label.Font = value ? label.Font.ToBold() : label.Font.ToRegular(); }
        }

        /// <summary>
        /// Font
        /// </summary>
        public new Font Font
        {
            get { return base.Font; }
            set { base.Font = label.Font = value; }
        }

        /// <summary>
        /// Get or set the background color
        /// </summary>
        public new Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = label.BackColor = checkBox.BackColor = value; }
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
