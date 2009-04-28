using Ushahidi.Model;
using Ushahidi.Model.Models;

namespace Ushahidi.View.Models
{
    /// <summary>
    /// Incident List Model
    /// </summary>
    public class IncidentListModel : BaseModel
    {
        /// <summary>
        /// Categories
        /// </summary>
        public Categories Categories
        {
            get
            {
                Categories categories = new Categories
                {
                    new Category(-1, null, null)
                };
                foreach (Category category in DataManager.Categories)
                {
                    categories.Add(category);
                }
                return categories;
            }
        }

        /// <summary>
        /// Incidents
        /// </summary>
        public Incidents Incidents
        {
            get { return DataManager.Incidents; }
        }
    }
}
