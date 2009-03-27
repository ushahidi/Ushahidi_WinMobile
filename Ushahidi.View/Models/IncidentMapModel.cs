using System.Collections.Generic;
using Ushahidi.Model;
using Ushahidi.Model.Models;

namespace Ushahidi.View.Models
{
    public class IncidentMapModel : BaseModel
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
