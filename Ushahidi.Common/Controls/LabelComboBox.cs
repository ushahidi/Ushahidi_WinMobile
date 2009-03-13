using System;
using System.Drawing;
using System.Windows.Forms;
using Ushahidi.Common.Extensions;

namespace Ushahidi.Common.Controls
{
    public partial class LabelComboBox : UserControl
    {
        public LabelComboBox()
        {
            InitializeComponent();
            BackColorFocuser.Register(comboBox);
        }

        /// <summary>
        /// Set focus
        /// </summary>
        /// <returns>true, if focussed</returns>
        public new bool Focus()
        {
            return Enabled ? comboBox.Focus() : false;
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
        /// Combo box data source
        /// </summary>
        public object DataSource
        {
            get { return comboBox.DataSource; }
            set { comboBox.DataSource = value;}
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
            }
        }
    }
}
