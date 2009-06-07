using System;
using System.Windows.Forms;
using Ushahidi.Common.Logging;
using Ushahidi.View.Languages;

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
        public string WebsiteURL 
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
