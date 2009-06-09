using System;
using System.Collections.Generic;
using Ushahidi.Common.Controls;
using Ushahidi.Common.MVC;
using Ushahidi.Model;
using Ushahidi.Model.Models;
using Ushahidi.View.Controllers;
using Ushahidi.View.Controls;
using Ushahidi.Model.Extensions;

namespace Ushahidi.View.Views
{
    /// <summary>
    /// Add incident view
    /// </summary>
    public partial class AddView : BaseView
    {
        public AddView()
        {
            InitializeComponent();
        }

        public override void Initialize()
        {
            base.Initialize();
            Keyboard.KeyboardChanged += OnKeyboardChanged;
            menuItemAddPhoto.Click += OnAddPhoto;
            menuItemAddNews.Click += OnAddNews;
            menuItemAddVideo.Click += OnAddVideo;
            menuItemCancel.Click += OnCancel;
            menuItemSave.Click += OnSave;
        }

        public override void Translate()
        {
            base.Translate();
            this.Translate("addIncident");
            textBoxTitle.Translate("title");
            dateBoxDate.Translate("date");
            comboBoxCategories.Translate("category");
            comboBoxLocales.Translate("location");
            menuItemSave.Translate("saveIncident");
            menuItemCancel.Translate("cancel");
            menuItemAddPhoto.Translate("addPhoto");
            menuItemAddNews.Translate("addNewLink");
            menuItemAddVideo.Translate("addVideoLink");
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
            get { return textBoxTitle.Value; }
            set { textBoxTitle.Value = value; }
        }

        /// <summary>
        /// Incident date
        /// </summary>
        public DateTime Date
        {
            get { return dateBoxDate.Value; }
            set { dateBoxDate.Value = value; }
        }

        /// <summary>
        /// Categories data source
        /// </summary>
        public Models<Category> Categories
        {
            set { comboBoxCategories.DataSource = value; }
        }

        /// <summary>
        /// Incident type
        /// </summary>
        public Category Category
        {
            get { return comboBoxCategories.SelectedValue<Category>(); }
            set { comboBoxCategories.SelectedItem = value; }
        }

        /// <summary>
        /// Locales data source
        /// </summary>
        public Models<Locale> Locales
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
            get { return textBoxDescription.Value; }
            set { textBoxDescription.Value = value; }
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
            Media media = DataManager.ImportPhoto(PhotoSelector.ShowDialog(this));
            if (media != null)
            {
                _MediaItems.Add(media);
                scrollListBox.Add(new PhotoListItem(DataManager.LoadImage(media.Link)));
                scrollListBox.AdjustHeight();
            }
        }

        private void OnAddNews(object sender, EventArgs e)
        {
            OnForward<WebsiteViewController>(false, string.Empty, menuItemAddNews.Text);
        }

        private void OnAddVideo(object sender, EventArgs e)
        {
            OnForward<WebsiteViewController>(false, string.Empty, menuItemAddVideo.Text);
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

        private void OnKeyboardChanged(object sender, KeyboardEventArgs args)
        {
            panelContent.Height = ClientRectangle.Height - args.Bounds.Height;
        }
    }
}
