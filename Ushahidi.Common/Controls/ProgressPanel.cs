using System;
using System.Drawing;
using System.Windows.Forms;

namespace Ushahidi.Common.Controls
{
    public partial class ProgressPanel : UserControl
    {
        protected static ProgressPanel Singleton
        {
            get
            {
                if (_Singleton == null)
                {
                    _Singleton = new ProgressPanel();
                }
                return _Singleton;
            }
        }private static ProgressPanel _Singleton;

        private ProgressPanel()
        {
            InitializeComponent();
        }

        public string Button
        {
            get { return button.Text; }
            set { button.Text = value; }
        }

        public string Label
        {
            get { return label.Text; }
            set { label.Text = value; }
        }

        private void OnTick(object sender, EventArgs e)
        {
            if (progressBar.Value < progressBar.Maximum)
            {
                progressBar.Value++;
            }
            else
            {
                progressBar.Value = progressBar.Minimum;
            }
        }

        public static void Show(Control parent, string label, string button, EventHandler onClick)
        {
            Singleton.Label = label;
            Singleton.Button = button;
            Singleton.button.Click += onClick;
            Singleton.Location = new Point((parent.Width - Singleton.Width) / 2, 
                                           (parent.Height - Singleton.Height) / 2);
            Singleton.Size = new Size(200, 95);
            parent.Controls.Add(Singleton);
            Singleton.BringToFront();
            Singleton.progressBar.Value = Singleton.progressBar.Minimum;
            Singleton.Show();
            Singleton.timer.Enabled = true;
        }

        public static void Hide(Control parent)
        {
            if (_Singleton != null)
            {
                _Singleton.timer.Enabled = true;
                _Singleton.Hide();
                parent.Controls.Remove(_Singleton);
            }
        }
    }
}
