using Ushahidi.Common.Extensions;
using Ushahidi.Model.Extensions;
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
            string parameterOne = parameters.ItemAtIndex<string>(0);
            View.URL = string.IsNullOrEmpty(parameterOne) ? null : parameterOne;
            
            string parameterTwo = parameters.ItemAtIndex<string>(1);
            View.Text = string.IsNullOrEmpty(parameterTwo) ? "website".Translate() : parameterTwo;
        }
    }
}
