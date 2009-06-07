using System;
using Ushahidi.Common.Extensions;
using Ushahidi.View.Views;

namespace Ushahidi.View.Controllers
{
    /// <summary>
    /// Website View Controller
    /// </summary>
    public class WebsiteViewController : BaseViewController<WebsiteView>
    {
        /// <summary>
        /// Load the view
        /// </summary>
        public override void Load(object[] parameters)
        {
            View.WebsiteURL = parameters.ItemAtIndex<string>(0);
        }

        public override bool Save()
        {
            return base.Save();
        }
    }
}
