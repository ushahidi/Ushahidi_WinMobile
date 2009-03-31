using System;
using System.Drawing;
using System.Windows.Forms;
using Ushahidi.Common.Extensions;

namespace Ushahidi.Common.Controls
{
    /// <summary>
    /// Label + ComboBox
    /// </summary>
    public partial class LabelComboBox : UserControl
    {
        /// <summary>
        /// Label + ComboBox
        /// </summary>
        public LabelComboBox()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Is input valid?
        /// </summary>
        public bool IsValid
        {
            get { return !comboBox.Enabled || (IsRequired && comboBox.SelectedIndex != -1); }
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
                if (!comboBox.Focused && comboBox.Enabled)
                {
                    comboBox.BackColor = value ? Color.PeachPuff : Color.WhiteSmoke;
                }
            }
        }private bool _IsRequired = false;

        /// <summary>
        /// Set focus
        /// </summary>
        /// <returns>true, if focussed</returns>
        public new bool Focus()
        {
            return comboBox.Enabled ? comboBox.Focus() : false;
        }

        /// <summary>
        /// Enabled
        /// </summary>
        public new bool Enabled
        {
            get { return comboBox.Enabled; }
            set
            {
                comboBox.Enabled = value;
                comboBox.BackColor = value ? Color.WhiteSmoke : Color.LightGray;
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
        /// ComboBox data source
        /// </summary>
        public object DataSource
        {
            get { return comboBox.DataSource; }
            set { comboBox.DataSource = value;}
        }

        /// <summary>
        /// ComboBox display member
        /// </summary>
        public string DisplayMember
        {
            get { return comboBox.DisplayMember; }
            set { comboBox.DisplayMember = value; }
        }

        /// <summary>
        /// ComboBox value member
        /// </summary>
        public string ValueMember
        {
            get { return comboBox.ValueMember; }
            set { comboBox.ValueMember = value; }
        }

        /// <summary>
        /// Selected index changed
        /// </summary>
        public event EventHandler SelectedIndexChanged
        {
            add { comboBox.SelectedIndexChanged += value; }
            remove { comboBox.SelectedIndexChanged -= value; }
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
        /// Selected Index
        /// </summary>
        public int SelectedIndex
        {
            get { return comboBox.SelectedIndex; }
            set { comboBox.SelectedIndex = value; }
        }

        /// <summary>
        /// Selected value
        /// </summary>
        /// <typeparam name="TValue">value type</typeparam>
        /// <returns>Value</returns>
        public TValue SelectedValue<TValue>()
        {
            return comboBox.SelectedItem != null ? (TValue) comboBox.SelectedItem : default(TValue);
        }

        /// <summary>
        /// Selected text
        /// </summary>
        public string SelectedText
        {
            get { return comboBox.SelectedItem != null ? comboBox.SelectedItem.ToString() : comboBox.SelectedText; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    comboBox.SelectedIndex = -1;
                }
                else
                {
                    comboBox.SelectedText = value;    
                }
                if (!comboBox.Focused)
                {
                    comboBox.BackColor = (IsRequired && comboBox.SelectedIndex == -1)
                                            ? Color.PeachPuff : Color.WhiteSmoke;    
                }
            }
        }
        
        /// <summary>
        /// On selected index changed
        /// </summary>
        private void OnIndexChanged(object sender, EventArgs e)
        {
            if (!comboBox.Focused && comboBox.Enabled)
            {
                comboBox.BackColor = IsRequired && comboBox.SelectedIndex == -1 ? Color.PeachPuff : Color.WhiteSmoke;
            }
        }

        private void OnGotFocus(object sender, EventArgs e)
        {
            comboBox.BackColor = Color.LightYellow;
        }

        private void OnLostFocus(object sender, EventArgs e)
        {
            comboBox.BackColor = IsRequired && comboBox.SelectedIndex == -1 ? Color.PeachPuff : Color.WhiteSmoke;
        }
    }
}
