using System;
using System.Drawing;
using System.Windows.Forms;
using Ushahidi.Common.Extensions;

namespace Ushahidi.Common.Controls
{
    /// <summary>
    /// Label date box
    /// </summary>
    public partial class LabelDateBox : UserControl
    {
        /// <summary>
        /// Label date box
        /// </summary>
        public LabelDateBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Date changed
        /// </summary>
        public event EventHandler DateChanged
        {
            add { dateTimePicker.ValueChanged += value; }
            remove { dateTimePicker.ValueChanged -= value; }
        }

        /// <summary>
        /// Set focus
        /// </summary>
        /// <returns>true, if focussed</returns>
        public new bool Focus()
        {
            return Enabled ? dateTimePicker.Focus() : false;
        }

        /// <summary>
        /// Enabled
        /// </summary>
        public new bool Enabled
        {
            get { return dateTimePicker.Enabled; }
            set
            {
                dateTimePicker.Enabled = value;
                dateTimePicker.BackColor = value ? Color.White : Color.WhiteSmoke;
            }
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
            set { base.BackColor = label.BackColor = value; }
        }

        /// <summary>
        /// Date
        /// </summary>
        public DateTime Date
        {
            get { return dateTimePicker.Value; }
            set
            {
                if (value != DateTime.MinValue && value != DateTime.MaxValue)
                {
                    dateTimePicker.Value = value;
                    dateTimePicker.Format = DateTimePickerFormat.Custom;
                    dateTimePicker.CustomFormat = "MM/dd/yyyy hh:mm tt";
                }
                else
                {
                    dateTimePicker.Format = DateTimePickerFormat.Custom;
                    dateTimePicker.CustomFormat = " ";
                }
            }
        }
    }
}
