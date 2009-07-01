using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Ushahidi.Common.Extensions;

namespace Ushahidi.Common.Controls
{
    /// <summary>
    /// Label + ListView
    /// </summary>
    public partial class LabelListView : UserControl
    {
        public LabelListView()
        {
            InitializeComponent();
            label.Font = label.Font.ToBold();
            columnHeader.Width = -2;
        }

        /// <summary>
        /// Set focus
        /// </summary>
        /// <returns>true, if focussed</returns>
        public new bool Focus()
        {
            return listView.Enabled ? listView.Focus() : false;
        }

        /// <summary>
        /// Enabled
        /// </summary>
        public new bool Enabled
        {
            get { return listView.Enabled; }
            set
            {
                listView.Enabled = value;
                listView.BackColor = value ? Color.White : Color.WhiteSmoke;
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

        public void Add(string text)
        {
            listView.Items.Add(new ListViewItem(text));
            columnHeader.Width = -2;
        }

        public int Count
        {
            get { return listView.Items.Count; }
        }

        public string[] Items
        {
            get
            {
                List<string> items = new List<string>();
                foreach(ListViewItem listViewItem in listView.Items)
                {
                    items.Add(listViewItem.Text);
                }
                return items.ToArray();
            }
            set
            {
                listView.Items.Clear();
                if (value != null)
                {
                    foreach (string item in value)
                    {
                        listView.Items.Add(new ListViewItem(item));
                        columnHeader.Width = -2;
                    }
                }
            }
        }

        public void Clear()
        {
            listView.Items.Clear();
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

        private void OnGotFocus(object sender, EventArgs e)
        {
            listView.BackColor = Color.LightYellow;
        }

        private void OnLostFocus(object sender, EventArgs e)
        {
            listView.BackColor = Color.White;
        }
    }
}
