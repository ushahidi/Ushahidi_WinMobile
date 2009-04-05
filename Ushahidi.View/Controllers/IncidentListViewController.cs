using System.ComponentModel;
using Ushahidi.View.Models;
using Ushahidi.View.Views;

namespace Ushahidi.View.Controllers
{
    public class IncidentListViewController : BaseViewController<IncidentListView, IncidentListModel>
    {
        public override void Load()
        {
            View.Categories = Model.Categories;
            View.Incidents = Model.Incidents;
        }

        public override void OnModelChanged(object sender, PropertyChangedEventArgs e)
        {
            //TODO add handling when incident list model changes
        }
    }
}
