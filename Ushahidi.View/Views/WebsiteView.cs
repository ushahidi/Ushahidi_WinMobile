using System;
using System.Windows.Forms;
using Ushahidi.Common.Logging;
using Ushahidi.Model.Extensions;

namespace Ushahidi.View.Views
{
    /// <summary>
    /// Website view
    /// </summary>
    public partial class WebsiteView : BaseView
    {
        public WebsiteView()
        {
            InitializeComponent();
        }

        public override void Translate()
        {
            base.Translate();
            this.Translate("website");
            menuItemAction.Translate("done");
        }

        private void OnNavigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            Log.Info("WebsiteView.OnNavigating");
            Cursor.Current = Cursors.WaitCursor;
        }

        private void OnNavigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            Log.Info("WebsiteView.OnNavigated");
            Cursor.Current = Cursors.Default;
        }

        public bool ViewOnly
        {
            get { return _ViewOnly; }
            set
            {
                _ViewOnly = value;
                if (value)
                {
                    menuItemAction.Translate("menuItemWebsiteDone");
                }
                else
                {
                    menuItemAction.Text = Text;
                }
            }
        }private bool _ViewOnly = false;

        /// <summary>
        /// Website URL
        /// </summary>
        public string URL 
        { 
            get { return webBrowser.Url != null ? webBrowser.Url.ToString() : string.Empty; }
            set { webBrowser.Url = string.IsNullOrEmpty(value) ? null : new Uri(value); }
        }

        private void OnDone(object sender, EventArgs e)
        {
            OnBack(webBrowser.Url);
        }
    }
}
