using System;
using System.Drawing;
using System.Windows.Forms;
using Ushahidi.Common.Extensions;
using Ushahidi.Common.Logging;

namespace Ushahidi.Common.Controls
{
    /// <summary>
    /// Label + TextBox
    /// </summary>
    public partial class LabelTextBox : UserControl
    {
        /// <summary>
        /// Label + TextBox
        /// </summary>
        public LabelTextBox()
        {
            InitializeComponent();
            label.Font = label.Font.ToBold();
            //Keyboard.Register(textBox);
        }

        /// <summary>
        /// Is input valid?
        /// </summary>
        public bool IsValid
        {
            get { return !IsRequired || (IsRequired && !string.IsNullOrEmpty(textBox.Text)); }
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
                if (Enabled)
                {
                    textBox.BackColor = value ? Color.LightSalmon : Color.White;
                }
            }
        }private bool _IsRequired = false;

        /// <summary>
        /// Is textbox read only?
        /// </summary>
        public new bool Enabled
        {
            get { return textBox.Enabled; }
            set
            {
                textBox.Enabled = textBox.ReadOnly = value;
                textBox.BackColor = value ? Color.White : Color.WhiteSmoke;
            }
        }

        /// <summary>
        /// Set focus
        /// </summary>
        /// <returns>true, if focussed</returns>
        public new bool Focus()
        {
            Log.Info("LabelTextBox.Focus");
            return textBox.Enabled ? textBox.Focus() : false;
        }

        /// <summary>
        /// Label
        /// </summary>
        public override string Text
        {
            get { return label.Text; }
            set { label.Text = value; }
        }

        public string Label
        {
            get { return label.Text; }
            set { label.Text = value; }
        }

        /// <summary>
        /// Text
        /// </summary>
        public string Value
        {
            get { return textBox.Text; }
            set { textBox.Text = value; }
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

        /// <summary>
        /// On text changed
        /// </summary>
        private void OnTextChanged(object sender, EventArgs e)
        {
            if (!textBox.Focused && textBox.Enabled)
            {
                textBox.BackColor = IsRequired && string.IsNullOrEmpty(textBox.Text) ? Color.LightSalmon : Color.White;
            }
        }

        private void OnGotFocus(object sender, EventArgs e)
        {
            textBox.BackColor = Color.LightYellow;
        }

        private void OnLostFocus(object sender, EventArgs e)
        {
            textBox.BackColor = IsRequired && string.IsNullOrEmpty(textBox.Text) ? Color.LightSalmon : Color.White;
        }
    }
}
