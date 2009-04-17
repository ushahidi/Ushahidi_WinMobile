using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Ushahidi.Common.Controls;
using Ushahidi.Model;
using Ushahidi.Model.Models;
using Ushahidi.View.Controls;
using Ushahidi.View.Languages;

namespace Ushahidi.View.Views
{
    /// <summary>
    /// Add incident view
    /// </summary>
    partial class AddIncidentView
    {
        public override void Initialize()
        {
            base.Initialize();
            menuItemAddIncidentAddPhoto.Click += OnAddPhoto;
            menuItemAddIncidentCancel.Click += OnCancel;
            menuItemAddIncidentSave.Click += OnSave;
            imageListBox.ThumbnailSize = ThumbnailSizes.HalfWidth;
        }

        public override void Translate()
        {
            base.Translate();
            textBoxAddIncidentTitle.Translate();
            dateBoxAddIncidentDate.Translate();
            comboBoxAddIncidentCategories.Translate();
            comboBoxAddIncidentLocales.Translate();
            menuItemAddIncidentSave.Translate(this);
            menuItemAddIncidentCancel.Translate(this);
            menuItemAddIncidentAddPhoto.Translate(this);
        }

        /// <summary>
        /// Incident title
        /// </summary>
        public string Title
        {
            get { return textBoxAddIncidentTitle.Text; }
            set { textBoxAddIncidentTitle.Text = value; }
        }

        /// <summary>
        /// Incident date
        /// </summary>
        public DateTime Date
        {
            get { return dateBoxAddIncidentDate.Date; }
            set { dateBoxAddIncidentDate.Date = value; }
        }

        /// <summary>
        /// Categories data source
        /// </summary>
        public Categories Categories
        {
            set { comboBoxAddIncidentCategories.DataSource = value; }
        }

        /// <summary>
        /// Incident type
        /// </summary>
        public Category Category
        {
            get { return comboBoxAddIncidentCategories.SelectedValue<Category>(); }
            set { comboBoxAddIncidentCategories.SelectedItem = value; }
        }

        /// <summary>
        /// Locales data source
        /// </summary>
        public Locales Locales
        {
            set { comboBoxAddIncidentLocales.DataSource = value; }
        }
        
        /// <summary>
        /// Incident type
        /// </summary>
        public Locale Locale
        {
            get { return comboBoxAddIncidentLocales.SelectedValue<Locale>(); }
            set { comboBoxAddIncidentLocales.SelectedItem = value; }
        }

        /// <summary>
        /// Incident description
        /// </summary>
        public string Description
        {
            get { return textBoxAddIncidentDescription.Text; }
            set { textBoxAddIncidentDescription.Text = value; }
        }

        /// <summary>
        /// Incident images
        /// </summary>
        public IEnumerable<Image> Images
        {
            get { return imageListBox.Images; }
            set { imageListBox.Images = value; }
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
            FileInfo fileInfo = PhotoSelector.ShowDialog(this);
            if (fileInfo != null && fileInfo.Exists)
            {
                using (new WaitCursor())
                {
                    string filePath = Path.Combine(DataManager.DataDirectory, fileInfo.Name);
                    fileInfo.MoveTo(Path.Combine(DataManager.DataDirectory, fileInfo.Name));
                    imageListBox.AddImage(new Bitmap(filePath));
                }
            }
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
