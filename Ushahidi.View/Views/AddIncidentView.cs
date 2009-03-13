using System;
using System.Drawing;
using Ushahidi.Common.Extensions;

namespace Ushahidi.View.Views
{
    /// <summary>
    /// Add incident view
    /// </summary>
    public partial class AddIncidentView
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
            get { return textBoxDate.Text.ToDateTime(); }
            set { textBoxDate.Text = value.ToString(); }
        }

        /// <summary>
        /// Incident type
        /// </summary>
        public string Type
        {
            get { return comboBoxType.SelectedText; }
            set { comboBoxType.SelectedText = value; }
        }

        /// <summary>
        /// Incident type
        /// </summary>
        public string Locale
        {
            get { return comboBoxLocale.SelectedText; }
            set { comboBoxLocale.SelectedText = value; }
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
        /// Type data source
        /// </summary>
        public object Types
        {
            get { return comboBoxType.DataSource; }
            set { comboBoxType.DataSource = value; }
        }

        private void OnSaveIncident(object sender, EventArgs e)
        {

        }

        private void OnAddPhoto(object sender, EventArgs e)
        {

        }

        private void OnCancel(object sender, EventArgs e)
        {

        }
    }
}
