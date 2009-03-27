﻿using System;

namespace Ushahidi.View.Views
{
    /// <summary>
    /// Website view
    /// </summary>
    partial class WebsiteView
    {
        /// <summary>
        /// Website URL
        /// </summary>
        public Uri WebsiteURL 
        { 
            get { return webBrowser.Url; }
            set { webBrowser.Url = value;}
        }

    }
}
