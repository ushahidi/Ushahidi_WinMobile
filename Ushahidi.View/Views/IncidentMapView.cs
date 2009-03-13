namespace Ushahidi.View.Views
{
    public partial class IncidentMapView
    {
        /// <summary>
        /// Types
        /// </summary>
        public object Types
        {
            get { return comboBoxTypes.DataSource; }
            set { comboBoxTypes.DataSource = value; }
        }
    }
}
