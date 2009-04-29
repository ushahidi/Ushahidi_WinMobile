using Ushahidi.View.Views;
using Ushahidi.View.Models;

namespace Ushahidi.View.Controllers
{
    /// <summary>
    /// Incident Map View Controller
    /// </summary>
    public class IncidentMapViewController : BaseViewController<IncidentMapView, IncidentMapModel>
    {
        public override void Load(object[] parameters)
        {
            View.Categories = Model.Categories;
        }
    }
}