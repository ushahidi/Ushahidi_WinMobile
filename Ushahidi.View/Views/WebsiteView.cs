using System;
using System.Windows.Forms;
using Ushahidi.Common.Logging;
using Ushahidi.View.Languages;

namespace Ushahidi.View.Views
{
    /// <summary>
    /// Website view
    /// </summary>
    partial class WebsiteView
    {
        public override void Initialize()
        {
            base.Initialize();
            webBrowser.Navigating += OnNavigating;
            webBrowser.Navigated += OnNavigated;
            menuItemAction.Click += OnDone;
        }

        private static void OnNavigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            Log.Info("WebsiteView.OnNavigating");
            Cursor.Current = Cursors.WaitCursor;
        }

        private static void OnNavigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            Log.Info("WebsiteView.OnNavigated");
            Cursor.Current = Cursors.Default;
        }

        public override void Translate()
        {
            base.Translate();
            menuItemAction.Translate("menuItemWebsiteDone");
        }

        /// <summary>
        /// Website URL
        /// </summary>
        public string WebsiteURL 
        { 
            get { return webBrowser.Url != null ? webBrowser.Url.ToString() : string.Empty; }
            set { webBrowser.Url = string.IsNullOrEmpty(value) ? null : new Uri(value); }
        }

        private void OnDone(object sender, EventArgs e)
        {
            OnBack();
        }
    }
}
