using Ushahidi.Model;
using Ushahidi.View.Views;

namespace Ushahidi.View.Controllers
{
    /// <summary>
    /// Map View Controller
    /// </summary>
    public class MapViewController : BaseViewController<MapView>
    {
        public override void Load(object[] parameters)
        {
            View.Categories = DataManager.Categories;
        }
    }
}