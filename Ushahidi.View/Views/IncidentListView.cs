using System;
using System.Linq;
using Ushahidi.Common.Controls;
using Ushahidi.Model.Models;
using Ushahidi.View.Controllers;
using Ushahidi.View.Controls;
using Ushahidi.View.Languages;

namespace Ushahidi.View.Views
{
    /// <summary>
    /// Incidents List View
    /// </summary>
    partial class IncidentListView
    {
        public override void Initialize()
        {
            base.Initialize();
            comboBoxIncidentListCategories.SelectedIndexChanged += OnCategoryChanged;
            menuItemAction.Click += OnViewIncident;
            listBoxIncidentListIncidents.IndexChanged += OnSelectedIncidentChanged;
            listBoxIncidentListIncidents.ItemSelected += OnItemSelected;
        }

        public override void Translate()
        {
            base.Translate();
            menuItemAction.Translate("menuItemSettingsSelect");
            comboBoxIncidentListCategories.Translate();
        }

        /// <summary>
        /// Categories
        /// </summary>
        public Categories Categories
        {
            set { comboBoxIncidentListCategories.DataSource = value; }
        }

        protected Category SelectedCategory
        {
            get { return comboBoxIncidentListCategories.SelectedValue<Category>(); }
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
                listBoxIncidentListIncidents.ClearItems();
                if (value != null)
                {
                    foreach (Incident incident in value.Where(i => string.IsNullOrEmpty(i.Title) == false))
                    {
                        listBoxIncidentListIncidents.AddItem(new IncidentListItem(incident));
                    }
                }
            }
        }private Incidents _Incidents;

        private void OnCategoryChanged(object sender, EventArgs e)
        {
            using (new WaitCursor())
            {
                listBoxIncidentListIncidents.ClearItems();
                if (Incidents != null)
                {
                    foreach (Incident incident in SelectedCategory.ID != -1
                                                      ? Incidents.Where(i => string.IsNullOrEmpty(i.Title) == false &&
                                                                             i.HasCategory(SelectedCategory.ID))
                                                      : Incidents.Where(i => string.IsNullOrEmpty(i.Title) == false))
                    {
                        listBoxIncidentListIncidents.AddItem(new IncidentListItem(incident), false);
                    }
                    listBoxIncidentListIncidents.Refresh();
                }
            }
        }

        private void OnSelectedIncidentChanged(ScrollListBoxItem control)
        {
            menuItemAction.Enabled = (control != null);
        }

        private void OnItemSelected(ScrollListBoxItem control)
        {
            IncidentListItem listItem = control as IncidentListItem;
            if (listItem != null)
            {
                OnForward(typeof(IncidentDetailsViewController), false, listItem.Incident);
            }
        }

        private void OnViewIncident(object sender, EventArgs e)
        {
            IncidentListItem listItem = listBoxIncidentListIncidents.SelectedItem as IncidentListItem;
            if (listItem != null)
            {
                OnForward(typeof(IncidentDetailsViewController), false, listItem.Incident);
            }
        }

    }
}
