using System;
using System.Drawing;
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
            scrollListBox.BackColor = Color.White;
            scrollListBox.BackColorEven = Color.Gainsboro;
            scrollListBox.BackColorOdd = Color.WhiteSmoke;
            scrollListBox.BackSelectedColor = Color.Black;
            scrollListBox.ForeSelectedColor = Color.White;
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
                scrollListBox.Clear();
                if (value != null)
                {
                    foreach (Incident incident in value.Where(i => string.IsNullOrEmpty(i.Title) == false))
                    {
                        scrollListBox.Add(new IncidentListItem(incident));
                    }
                }
            }
        }private Models<Incident> _Incidents;

        private void OnCategoryChanged(object sender, EventArgs e)
        {
            using (new WaitCursor())
            {
                scrollListBox.Clear();
                if (Incidents != null)
                {
                    Category category = comboBoxCategories.SelectedValue<Category>();
                    foreach (Incident incident in Incidents)
                    {
                        if (category == null || category.ID == -1 || incident.HasCategory(category.ID))
                        {
                            scrollListBox.Add(new IncidentListItem(incident));
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
            IncidentListItem listItem = scrollListBox.SelectedItem as IncidentListItem;
            if (listItem != null)
            {
                OnForward<DetailsViewController>(false, listItem.Item);
            }
        }

        private void OnKeyboardChanged(object sender, KeyboardEventArgs args)
        {
            panelContent.Height = ClientRectangle.Height - args.Height;
        }
    }
}
