using System;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using Ushahidi.Common.Extensions;

namespace Ushahidi.Common.Controls
{
    public partial class LabelCheckBoxes : UserControl
    {
        public LabelCheckBoxes()
        {
            InitializeComponent();
            label.Font = label.Font.ToBold();
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

        public void Add(string name, object value)
        {
            CheckBox checkBox = new CheckBox
            {
                Text = name,
                Tag = value,
                TabIndex = TabIndex + panel.Controls.Count + 1,
                Width = panel.Width/2,
                BackColor = BackColor
            };
            checkBox.CheckStateChanged += OnCheckStateChanged;
            checkBox.Left = (panel.Controls.Count % 2 == 0) ? 0 : panel.Width / 2;
            checkBox.Top = (panel.Controls.Count % 2 == 0) ? panel.Controls.MaxBottom() : panel.Controls.MaxBottom() - checkBox.Height;
            panel.Controls.Add(checkBox);
            Height = panel.Controls.MaxBottom() + panel.Top + label.Top;
        }

        public void Clear()
        {
            panel.Controls.Clear();
            Height = label.Bottom + label.Top;
        }

        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                base.BackColor = panel.BackColor = label.BackColor = value;
                foreach (Control control in panel.Controls)
                {
                    control.BackColor = value;
                }
            }
        }

        public override Color ForeColor
        {
            get { return base.ForeColor; }
            set
            {
                base.ForeColor = panel.ForeColor = label.ForeColor = value;
                foreach (Control control in panel.Controls)
                {
                    control.ForeColor = value;
                }
            }
        }

        public IEnumerable<string> Names
        {
            get { return panel.Controls.Cast<Control>().Select(c => c.Text); }
        }

        public IEnumerable<object> AllValues
        {
            get { return panel.Controls.Cast<CheckBox>().Select(c => c.Tag); }
        }

        public IEnumerable<object> CheckedValues
        {
            get { return panel.Controls.Cast<CheckBox>().Where(c => c.Checked).Select(c => c.Tag); }
        }

        private void OnCheckStateChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            if (CheckChanged != null && checkBox != null)
            {
                CheckChanged(this, new CheckChangedEventArgs(checkBox.Name, checkBox.Tag));
            }
        }

        public delegate void CheckChangedHandler(object sender, CheckChangedEventArgs args);

        public event CheckChangedHandler CheckChanged;
    }

    public class CheckChangedEventArgs : EventArgs
    {
        public CheckChangedEventArgs(string name, object value)
        {
            Name = name;
            Value = value;
        }
        public string Name { get; private set; }

        public object Value { get; private set; }
    }

}
