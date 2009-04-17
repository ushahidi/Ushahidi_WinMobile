using System;
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
            menuItemAction.Click += OnDone;
        }

        public override void Translate()
        {
            base.Translate();
            menuItemAction.Translate("menuItemWebsiteDone");
        }

        /// <summary>
        /// Website URL
        /// </summary>
        public Uri WebsiteURL 
        { 
            get { return webBrowser.Url; }
            set { webBrowser.Url = value;}
        }

        private void OnDone(object sender, EventArgs e)
        {
            OnBack();
        }

    }
}
