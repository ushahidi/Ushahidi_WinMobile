using System;
using System.Drawing;
using System.Windows.Forms;
using Ushahidi.View.Controls;

namespace Ushahidi.View.Views
{
    public partial class IncidentListView
    {
        /// <summary>
        /// Filter data source
        /// </summary>
        public object Types
        {
            get { return comboBoxTypes.DataSource; }
            set { comboBoxTypes.DataSource = value; }
        }

        /// <summary>
        /// Clear incidents
        /// </summary>
        public void ClearIncidents()
        {
            listBoxIncidents.ClearItems();
        }

        /// <summary>
        /// Add incident
        /// </summary>
        /// <param name="title">incident title</param>
        /// <param name="locale">incident locale</param>
        /// <param name="date">incident date</param>
        /// <param name="contributors">incident contributors</param>
        /// <param name="responses">incident responses</param>
        /// <param name="links">incident links</param>
        /// <param name="verified">is incident verified?</param>
        public void AddIncident(string title, string locale, DateTime date, int contributors, int responses, int links, bool verified, Image image)
        {
            IncidentListItem incidentListItem = new IncidentListItem(title, locale, date, verified)
            {
                Image = image
            };
            listBoxIncidents.AddItem(incidentListItem, false);
        }

        protected void OnFilterChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(listBoxIncidents.SelectedIndex.ToString(), "OnFilterChanged");
        }

        private void OnIncidentsIndexChanged(Control control)
        {
            //MessageBox.Show("OnIncidentsIndexChanged");
        }

        private void OnIncidentsItemSelected(Control control)
        {
            //MessageBox.Show("OnIncidentsItemSelected");
        }
    }
}
