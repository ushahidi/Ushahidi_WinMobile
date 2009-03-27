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
            get { return DataManager.Categories; }
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
