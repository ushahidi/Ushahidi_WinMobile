using Ushahidi.View.Models;
using Ushahidi.View.Views;

namespace Ushahidi.View.Controllers
{
    public class IncidentListViewController : BaseViewController<IncidentListView, IncidentListModel>
    {
        public override void Load(object[] parameters)
        {
            View.Categories = Model.Categories;
            View.Incidents = Model.Incidents;
        }
    }
}
