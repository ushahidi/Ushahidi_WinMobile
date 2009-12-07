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
            label.Font = label.Font.ToBold();
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
                    comboBox.BackColor = value ? Color.LightSalmon : Color.White;
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
                comboBox.BackColor = value ? Color.White : Color.WhiteSmoke;
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
        /// ComboBox data source
        /// </summary>
        public object DataSource
        {
            get { return comboBox.DataSource; }
            set
            {
                if (value != null)
                {
                    DataSourceChanging = true;
                    comboBox.SelectedIndex = -1;
                    comboBox.DataSource = value;
                    DataSourceChanging = false;
                }
                else
                {
                    comboBox.SelectedIndex = -1;
                    comboBox.DataSource = null;
                    comboBox.Items.Clear();
                }
                comboBox.SelectedIndex = -1;
            }
        }private bool DataSourceChanging;

        /// <summary>
        /// ComboBox display member
        /// </summary>
        public string DisplayMember
        {
            get { return comboBox.DisplayMember; }
            set { comboBox.DisplayMember = value; }
        }

        public void Add(object item)
        {
            comboBox.Items.Add(item);
        }

        public int Count
        {
            get { return comboBox.Items.Count; }
        }

        public void Clear()
        {
            comboBox.Items.Clear();
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
            add { _SelectedIndexChanged += value; }
            remove { _SelectedIndexChanged -= value; }
        }private event EventHandler _SelectedIndexChanged;

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
        /// Selected Index
        /// </summary>
        public int SelectedIndex
        {
            get { return comboBox.SelectedIndex; }
            set { comboBox.SelectedIndex = value; }
        }

        /// <summary>
        /// Selected item
        /// </summary>
        public object SelectedItem
        {
            get { return comboBox.SelectedItem; }
            set
            {
                if (value != null)
                {
                    comboBox.SelectedItem = value;    
                }
                else
                {
                    comboBox.SelectedIndex = -1;
                }
            }
        }

        /// <summary>
        /// Selected value
        /// </summary>
        /// <typeparam name="TValue">value type</typeparam>
        /// <returns>Value</returns>
        public TValue SelectedValue<TValue>()
        {
            return comboBox.SelectedIndex != -1 && comboBox.SelectedItem != null ? (TValue)comboBox.SelectedItem : default(TValue);
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
                                            ? Color.LightSalmon : Color.White;    
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
                comboBox.BackColor = IsRequired && comboBox.SelectedIndex == -1 ? Color.LightSalmon : Color.White;
            }
            if (_SelectedIndexChanged != null && DataSourceChanging == false)
            {
                _SelectedIndexChanged(this, e);
            }
        }

        private void OnGotFocus(object sender, EventArgs e)
        {
            comboBox.BackColor = Color.LightYellow;
        }

        private void OnLostFocus(object sender, EventArgs e)
        {
            comboBox.BackColor = IsRequired && comboBox.SelectedIndex == -1 ? Color.LightSalmon : Color.White;
        }
    }

}
