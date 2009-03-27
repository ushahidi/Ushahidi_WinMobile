using Ushahidi.Model.Models;
using Ushahidi.View.Controls;

namespace Ushahidi.View.Views
{
    /// <summary>
    /// Incidents List View
    /// </summary>
    partial class IncidentListView
    {
        /// <summary>
        /// Categories
        /// </summary>
        public object Categories
        {
            get { return comboBoxCategories.DataSource; }
            set { comboBoxCategories.DataSource = value; }
        }

        /// <summary>
        /// Incidents
        /// </summary>
        public Incidents Incidents
        {
            get { return _Incidents; }
            set
            {
                _Incidents = value;
                if (value != null)
                {
                    listBoxIncidents.ClearItems();
                    foreach(Incident incident in value.Items)
                    {
                        if (string.IsNullOrEmpty(incident.Title) == false)
                        {
                            listBoxIncidents.AddItem(new IncidentListItem(incident));
                        }
                    }
                }
            }
        }private Incidents _Incidents;

    }
}
