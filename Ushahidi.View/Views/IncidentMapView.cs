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
        public object Categories
        {
            get { return comboBoxCategories.DataSource; }
            set { comboBoxCategories.DataSource = value; }
        }
    }
}
