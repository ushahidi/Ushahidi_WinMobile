using System;
using Ushahidi.View.Models;
using Ushahidi.View.Views;

namespace Ushahidi.View.Controllers
{
    /// <summary>
    /// Website View Controller
    /// </summary>
    public class WebsiteViewController : BaseViewController<WebsiteView, WebsiteModel>
    {
        /// <summary>
        /// Load the view
        /// </summary>
        public override void Load(object[] parameters)
        {
            if (parameters == null || parameters.Length == 0)
            {
                throw new ArgumentNullException("parameters", "Parameters can not be null");
            }
            if (parameters.Length > 0)
            {
                View.WebsiteURL = View.Text = parameters[0].ToString();   
            }
            if (parameters.Length > 1)
            {
                View.Text = string.Format("{0}", parameters[1]);   
            }
        }
    }
}
