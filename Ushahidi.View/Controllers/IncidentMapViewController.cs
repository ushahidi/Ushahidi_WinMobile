using Ushahidi.View.Views;
using Ushahidi.View.Models;

namespace Ushahidi.View.Controllers
{
    public class IncidentMapViewController : BaseViewController<IncidentMapView, IncidentMapModel>
    {
        /// <summary>
        /// Load the view
        /// </summary>
        public override void Load()
        {
            View.Categories = Model.Categories.Items;
        }
    }
}