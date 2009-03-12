using System;
using System.Drawing;
using System.Windows.Forms;
using Ushahidi.Common.Extensions;

namespace Ushahidi.Common.Controls
{
    public partial class LabelTextBox : UserControl
    {
        public LabelTextBox()
        {
            InitializeComponent();
            BackColorFocuser.Register(textBox);
        }

        /// <summary>
        /// Label
        /// </summary>
        public string Label 
        {
            get { return label.Text; }
            set { label.Text = value;}
        }

        /// <summary>
        /// Text
        /// </summary>
        public new string Text
        {
            get { return textBox.Text; }
            set { textBox.Text = value;}
        }

        /// <summary>
        /// Is textbox read only?
        /// </summary>
        public bool ReadOnly
        {
            get { return textBox.ReadOnly; }
            set { textBox.ReadOnly = value; }
        }

        /// <summary>
        /// Get or set the background color
        /// </summary>
        public new Color BackColor
        {
            get { return base.BackColor; }
            set  { base.BackColor = label.BackColor =  value; }
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
        /// Is textbox multiline?
        /// </summary>
        public bool Multiline
        {
            get { return textBox.Multiline; }
            set { textBox.Multiline = value; }
        }

        /// <summary>
        /// Occurs when text changed
        /// </summary>
        public new event EventHandler TextChanged
        {
            add { textBox.TextChanged += value; }
            remove { textBox.TextChanged -= value; }
        }
    }
}
