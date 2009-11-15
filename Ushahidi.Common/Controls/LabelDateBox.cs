using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Ushahidi.Common.Extensions;
using Ushahidi.Common.Logging;

namespace Ushahidi.Common.Controls
{
    /// <summary>
    /// Label date box
    /// </summary>
    public partial class LabelDateBox : UserControl
    {
        const string TIME_FORMAT = "H:mm";
        const string DATE_FORMAT = "MMMM d, yyyy";

        /// <summary>
        /// Date Formats
        /// </summary>
        public enum Types
        {
            Date,
            Time
        }

        /// <summary>
        /// Label date box
        /// </summary>
        public LabelDateBox()
        {
            InitializeComponent();
            label.Font = label.Font.ToBold();
        }

        /// <summary>
        /// Style format: Date or Time
        /// </summary>
        public Types Type
        {
            get { return _Type; }
            set
            {
                _Type = value;
                if (value == Types.Date)
                {
                    dateTimePicker.Format = DateTimePickerFormat.Custom;
                    dateTimePicker.CustomFormat = DATE_FORMAT;
                    dateTimePicker.ShowUpDown = false;
                }
                else if (value == Types.Time)
                {
                    dateTimePicker.Format = DateTimePickerFormat.Custom;
                    dateTimePicker.CustomFormat = TIME_FORMAT;
                    dateTimePicker.ShowUpDown = true;
                }
            }
        }private Types _Type = Types.Date;

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
        /// BackColor
        /// </summary>
        public override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = label.BackColor = value; }
        }

        /// <summary>
        /// ForeColor
        /// </summary>
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
                    dateTimePicker.CustomFormat = (Type == Types.Date) ? DATE_FORMAT : TIME_FORMAT;
                }
                else
                {
                    dateTimePicker.Format = DateTimePickerFormat.Custom;
                    dateTimePicker.CustomFormat = " ";
                }
            }
        }

        private void OnGotFocus(object sender, EventArgs e)
        {
            Log.Info("LabelDateBox.OnGotFocus");
            if (Type == Types.Date && ShouldEnableTimer)
            {
                focusTimer.Enabled = true;
            }
        }

        private void OnLostFocus(object sender, EventArgs e)
        {
            Log.Info("LabelDateBox.OnLostFocus");
            if (focusTimer.Enabled)
            {
                Log.Info("  Timer enabled");
                ShouldEnableTimer = false;
            }
            else
            {
                Log.Info("  Timer disabled");
                ShouldEnableTimer = true;
            }
        }

        private void OnValueChanged(object sender, EventArgs e)
        {
            Log.Info("LabelDateBox.OnValueChanged: {0}", dateTimePicker.Value);
        }

        private void OnFocusTimer(object sender, EventArgs e)
        {
            Log.Info("LabelDateBox.OnFocusTimer");
            if (dateTimePicker.Focused)
            {
                //if the DateTimePicker still has focus, then manually click the calendar button
                try
                {
                    int x = dateTimePicker.Width - 10;
                    int y = dateTimePicker.Height / 2;
                    int parameter = x + y * 0x00010000;
                    const int WM_LBUTTONDOWN = 0x0201;
                    Log.Info("  Calendar Shown Manually");
                    SendMessage(dateTimePicker.Handle, WM_LBUTTONDOWN, 1, parameter);
                }
                catch (Exception ex)
                {
                    Log.Exception("LabelDateBox", "Exception: {0}", ex.Message);
                }
            }
            else
            {
                Log.Info("  Calendar Shown Automatically");
            }
            focusTimer.Enabled = false;
        }

        /// <summary>
        /// Should focus focus timer be enabled?
        /// </summary>
        private bool ShouldEnableTimer = true;

        [DllImport("coredll.dll")]
        static extern int SendMessage(IntPtr handle, uint message, int wParam, int lParam);
    }

}
