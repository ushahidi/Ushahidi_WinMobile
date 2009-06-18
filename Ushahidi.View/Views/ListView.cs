﻿using System;
using System.Linq;
using Ushahidi.Common.Controls;
using Ushahidi.Common.MVC;
using Ushahidi.Model.Models;
using Ushahidi.View.Controllers;
using Ushahidi.View.Controls;
using Ushahidi.Model.Extensions;

namespace Ushahidi.View.Views
{
    /// <summary>
    /// Incidents List View
    /// </summary>
    public partial class ListView : BaseView
    {
        public ListView()
        {
            InitializeComponent();
        }

        public override void Initialize()
        {
            base.Initialize();
            Keyboard.KeyboardChanged += OnKeyboardChanged;
        }

        public override void Translate()
        {
            base.Translate();
            this.Translate("incidentList");
            menuItemAction.Translate("select");
            comboBoxCategories.Translate("category");
        }

        public override void Render()
        {
            base.Render();
            comboBoxCategories.SelectedIndex = 0;
            comboBoxCategories.BackColor = Colors.Background;
            panelContent.BackColor = Colors.Background;
        }

        /// <summary>
        /// Categories
        /// </summary>
        public Models<Category> Categories
        {
            set { comboBoxCategories.DataSource = value; }
            get { return comboBoxCategories.DataSource as Models<Category>; }
        }

        /// <summary>
        /// Incidents
        /// </summary>
        public Models<Incident> Incidents
        {
            get { return _Incidents; }
            set
            {
                _Incidents = value;
                listBoxIncidents.Clear();
                if (value != null)
                {
                    foreach (Incident incident in value.Where(i => string.IsNullOrEmpty(i.Title) == false))
                    {
                        listBoxIncidents.Add(new IncidentListItem(incident));
                    }
                }
            }
        }private Models<Incident> _Incidents;

        private void OnCategoryChanged(object sender, EventArgs e)
        {
            using (new WaitCursor())
            {
                listBoxIncidents.Clear();
                if (Incidents != null)
                {
                    Category category = comboBoxCategories.SelectedValue<Category>();
                    foreach (Incident incident in Incidents)
                    {
                        if (category == null || category.ID == -1 || incident.HasCategory(category.ID))
                        {
                            listBoxIncidents.Add(new IncidentListItem(incident));
                        }
                    }
                }
            }
        }

        private void OnIncidentChanged(object sender, ScrollEventArgs args)
        {
            menuItemAction.Enabled = (args.Item != null);
        }

        private void OnIncidentSelected(object sender, ScrollEventArgs args)
        {
            IncidentListItem listItem = args.Item as IncidentListItem;
            if (listItem != null)
            {
                OnForward<DetailsViewController>(false, listItem.Item);
            }
        }

        private void OnViewIncident(object sender, EventArgs e)
        {
            IncidentListItem listItem = listBoxIncidents.SelectedItem as IncidentListItem;
            if (listItem != null)
            {
                OnForward<DetailsViewController>(false, listItem.Item);
            }
        }

        private void OnKeyboardChanged(object sender, KeyboardEventArgs args)
        {
            panelContent.Height = ClientRectangle.Height - args.Bounds.Height;
        }
    }
}