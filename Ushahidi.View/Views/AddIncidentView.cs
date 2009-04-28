using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Ushahidi.Common.Controls;
using Ushahidi.Model;
using Ushahidi.Model.Models;
using Ushahidi.View.Controllers;
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
            menuItemAddIncidentAddNews.Click += OnAddNews;
            menuItemAddIncidentAddVideo.Click += OnAddVideo;
            menuItemAddIncidentCancel.Click += OnCancel;
            menuItemAddIncidentSave.Click += OnSave;
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
            menuItemAddIncidentAddNews.Translate(this);
            menuItemAddIncidentAddVideo.Translate(this);
        }

        public override void Render()
        {
            ShouldSave = true;
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

        public Media[] MediaItems
        {
            get { return _MediaItems.ToArray(); }
            set
            {
                _MediaItems.Clear();
                if (value != null)
                {
                    _MediaItems.AddRange(value);
                }
            }
        }private readonly List<Media> _MediaItems = new List<Media>();

        /// <summary>
        /// Is the process cancelled?
        /// </summary>
        public bool ShouldSave { get; private set; }

        private void OnAddPhoto(object sender, EventArgs e)
        {
            FileInfo fileInfo = PhotoSelector.ShowDialog(this);
            if (fileInfo != null && fileInfo.Exists)
            {
                using (new WaitCursor())
                {
                    string fileName = string.Format("{0}.jpg", DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss"));
                    string filePath = Path.Combine(DataManager.DataDirectory, fileName);
                    fileInfo.CopyTo(filePath, true);
                    _MediaItems.Add(Media.NewPhoto(fileName));
                    scrollListBoxMediaItems.Add(new PhotoListItem(new Bitmap(filePath)));
                    scrollListBoxMediaItems.AdjustHeight();
                }
            }
        }

        private void OnAddNews(object sender, EventArgs e)
        {
            OnForward<WebsiteViewController>(false, string.Empty, menuItemAddIncidentAddNews.Text);
        }

        private void OnAddVideo(object sender, EventArgs e)
        {
            OnForward<WebsiteViewController>(false, string.Empty, menuItemAddIncidentAddVideo.Text);
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
