using Ushahidi.Common.Extensions;
using Ushahidi.Model.Models;
using Ushahidi.View.Views;

namespace Ushahidi.View.Controllers
{
    /// <summary>
    /// Details View Controller
    /// </summary>
    public class DetailsViewController : BaseViewController<DetailsView>
    {
        /// <summary>
        /// Load the view
        /// </summary>
        public override void Load(object[] parameters)
        {
            if (parameters.Exists(0) && parameters[0] is Incident)
            {
                View.Incident = parameters.ItemAtIndex<Incident>(0);    
            }
            else if (parameters.Exists(0) && parameters[0] is Media)
            {
                Media media = parameters.ItemAtIndex<Media>(0);
                View.AddMedia(media);
            }
        }
    }
}
