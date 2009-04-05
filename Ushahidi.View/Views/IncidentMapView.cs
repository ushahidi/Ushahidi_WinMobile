using Ushahidi.Model.Models;

namespace Ushahidi.View.Views
{
    /// <summary>
    /// Incident Map View
    /// </summary>
    partial class IncidentMapView
    {
        /// <summary>
        /// Categories
        /// </summary>
        public Categories Categories
        {
            set { comboBoxCategories.DataSource = value; }
        }
    }
}
