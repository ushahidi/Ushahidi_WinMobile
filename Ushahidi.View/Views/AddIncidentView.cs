using System;
using System.Drawing;
using Ushahidi.Model.Models;

namespace Ushahidi.View.Views
{
    /// <summary>
    /// Add incident view
    /// </summary>
    partial class AddIncidentView
    {
        /// <summary>
        /// Incident title
        /// </summary>
        public string Title
        {
            get { return textBoxTitle.Text; }
            set { textBoxTitle.Text = value; }
        }

        /// <summary>
        /// Incident date
        /// </summary>
        public DateTime Date
        {
            get { return dateBox.Date; }
            set { dateBox.Date = value; }
        }

        /// <summary>
        /// Categories data source
        /// </summary>
        public Categories Categories
        {
            set { comboBoxCategories.DataSource = value; }
        }

        /// <summary>
        /// Incident type
        /// </summary>
        public Category Category
        {
            get { return comboBoxCategories.SelectedValue<Category>(); }
            set { comboBoxCategories.SelectedIndex = -1; }
        }

        /// <summary>
        /// Locales data source
        /// </summary>
        public Locales Locales
        {
            set { comboBoxLocales.DataSource = value; }
        }
        
        /// <summary>
        /// Incident type
        /// </summary>
        public Locale Locale
        {
            get { return comboBoxLocales.SelectedValue<Locale>(); }
            set { comboBoxLocales.SelectedItem = value; }
        }

        /// <summary>
        /// Incident description
        /// </summary>
        public string Description
        {
            get { return textBoxDescription.Text; }
            set { textBoxDescription.Text = value; }
        }

        /// <summary>
        /// Incident images
        /// </summary>
        public Image [] Images
        {
            get { return images.Images; }
            set { images.Images = value;}
        }

        /// <summary>
        /// Is the process cancelled?
        /// </summary>
        public bool ShouldSave { get; private set; }

        public override void Render()
        {
            ShouldSave = true;
        }

        private void OnAddPhoto(object sender, EventArgs e)
        {
            //TODO add photo
        }

        private void OnSave(object sender, EventArgs e)
        {
            ShouldSave = true;
            OnBack();
        }

        private void OnCancel(object sender, EventArgs e)
        {
            ShouldSave = false;
            OnBack();
        }
    }
}
