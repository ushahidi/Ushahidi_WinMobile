using Ushahidi.Common.MVC;
using Ushahidi.Model;
using Ushahidi.Model.Models;
using Ushahidi.View.Views;

namespace Ushahidi.View.Controllers
{
    public class ListViewController : BaseViewController<ListView>
    {
        public override void Load(object[] parameters)
        {
            Models<Category> categories = new Models<Category>
            {
                new Category {ID = -1, Title = null, Description = null},
                DataManager.Categories
            };
            View.Categories = categories;
            View.Incidents = DataManager.Incidents;
        }
    }
}
