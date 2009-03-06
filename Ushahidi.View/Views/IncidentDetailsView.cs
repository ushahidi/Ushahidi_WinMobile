using System;
using System.Drawing;
using Ushahidi.Common.Extensions;

namespace Ushahidi.View.Views
{
    /// <summary>
    /// Incident details view
    /// </summary>
    public partial class IncidentDetailsView
    {
        private const string VERIFIED = "VERIFIED";
        private const string NOT_VERIFIED = "NOT VERIFIED";

        /// <summary>
        /// Incident title
        /// </summary>
        public string Title
        {
            get { return labelTitle.Text; }
            set { labelTitle.Text = value; }
        }

        /// <summary>
        /// Incident location
        /// </summary>
        public string Locale
        {
            get { return labelLocale.Text; }
            set { labelLocale.Text = value; }
        }

        /// <summary>
        /// Incident description
        /// </summary>
        public string Description
        {
            get { return labelDescription.Text; }
            set { labelDescription.Text = value; }
        }

        /// <summary>
        /// Incident date
        /// </summary>
        public DateTime Date
        {
            get { return labelDate.Text.ToDateTime(); }
            set { labelDate.Text = value.ToString(); }
        }

        /// <summary>
        /// Incident image
        /// </summary>
        public Image Image
        {
            get { return pictureBoxImage.Image; }
            set { pictureBoxImage.Image = value; }
        }

        /// <summary>
        /// Incident verified?
        /// </summary>
        public bool Verified
        {
            get { return labelVerified.Text.Equals(VERIFIED); }
            set
            {
                labelVerified.Text = value ? VERIFIED : NOT_VERIFIED;
                labelVerified.ForeColor = value ? Color.Green : Color.Red;
            }
        }

        /// <summary>
        /// View map event
        /// </summary>
        public event EventHandler ViewMap
        {
            add { menuItemViewMap.Click += value; }
            remove { menuItemViewMap.Click -= value; }
        }

        /// <summary>
        /// Add photo event
        /// </summary>
        public event EventHandler AddPhoto
        {
            add { menuItemAddPhoto.Click += value; }
            remove { menuItemAddPhoto.Click -= value; }
        }

        private void OnViewMap(object sender, EventArgs e)
        {

        }

        private void OnAddPhoto(object sender, EventArgs e)
        {

        }
    }
}
