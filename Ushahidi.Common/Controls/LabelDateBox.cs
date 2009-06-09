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
            label.Font = label.Font.ToBold();
        }

        /// <summary>
        /// Is input valid?
        /// </summary>
        public bool IsValid
        {
            get { return IsRequired && Value != DateTime.MinValue; }
        }

        /// <summary>
        /// Is this field required?
        /// </summary>
        public bool IsRequired
        {
            get { return _IsRequired; }
            set
            {
                _IsRequired = value;
                if (!dateTimePicker.Focused && Enabled)
                {
                    dateTimePicker.BackColor = value ? Color.LightSalmon : Color.White;
                }
            }
        }private bool _IsRequired = false;

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
            set { base.BackColor = label.BackColor = value; }
        }

        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set { base.ForeColor = label.ForeColor = value; }
        }

        /// <summary>
        /// Date
        /// </summary>
        public DateTime Value
        {
            get { return dateTimePicker.Value; }
            set
            {
                if (value != DateTime.MinValue && value != DateTime.MaxValue)
                {
                    dateTimePicker.Value = value;
                    dateTimePicker.Format = DateTimePickerFormat.Custom;
                    dateTimePicker.CustomFormat = "MM/dd/yyyy h:mm tt";
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
