using System;
using System.Linq;
using System.Collections.Generic;
using Ushahidi.Common.Controls;
using Ushahidi.Common.Logging;
using Ushahidi.Common.MVC;
using Ushahidi.Model;
using Ushahidi.Model.Models;
using Ushahidi.View.Controllers;
using Ushahidi.View.Controls;
using Ushahidi.Model.Extensions;
using Ushahidi.View.Extensions;

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
            panel.BackColor =
            textBoxTitle.BackColor =
            dateBoxDate.BackColor =
            comboBoxLocales.BackColor =
            checkBoxesCategories.BackColor =
            textBoxDescription.BackColor =
            listViewNews.BackColor =
            listViewVideos.BackColor =
            scrollListBox.BackColor =
            scrollListBox.BackColorEven =
            scrollListBox.BackSelectedColor = Colors.Background;
        }

        public override void Translate()
        {
            base.Translate();
            this.Translate("addIncident");
            textBoxTitle.Translate("title");
            textBoxDescription.Translate("description");
            dateBoxDate.Translate("date");
            checkBoxesCategories.Translate("category");
            comboBoxLocales.Translate("location");
            listViewNews.Translate("news");
            listViewVideos.Translate("video");
            menuItemSave.Translate("saveIncident");
            menuItemCancel.Translate("cancel");
            menuItemAddPhoto.Translate("addPhoto");
            menuItemAddNews.Translate("addNewsLink");
            menuItemAddVideo.Translate("addVideoLink");
        }

        public override void Render()
        {
            ShouldSave = true;
            textBoxDescription.Top = checkBoxesCategories.Bottom;
            listViewNews.Top = textBoxDescription.Bottom;
            listViewVideos.Top = listViewNews.Bottom;
            scrollListBox.Top = listViewVideos.Bottom;
            scrollListBox.AdjustHeight();
        }

        public override bool Validate()
        {
            if (ShouldSave)
            {
                if (string.IsNullOrEmpty(Title))
                {
                    Dialog.Warning("title".Translate(), "missingFieldsVerify".Translate());
                    textBoxTitle.Focus();
                    return false;
                }
                if (dateBoxDate.Value == DateTime.MinValue)
                {
                    Dialog.Warning("date".Translate(), "missingFieldsVerify".Translate());
                    dateBoxDate.Focus();
                    return false;
                }
                if (Locale == null)
                {
                    Dialog.Warning("location".Translate(), "missingFieldsVerify".Translate());
                    comboBoxLocales.Focus();
                    return false;
                }
                if (Categories.Count() == 0)
                {
                    Dialog.Warning("category".Translate(), "missingFieldsVerify".Translate());
                    checkBoxesCategories.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(Description))
                {
                    Dialog.Warning("description".Translate(), "missingFieldsVerify".Translate());
                    textBoxDescription.Focus();
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Incident Title
        /// </summary>
        public string Title
        {
            get { return textBoxTitle.Value; }
            set { textBoxTitle.Value = value; }
        }

        /// <summary>
        /// Incident Date
        /// </summary>
        public DateTime Date
        {
            get { return dateBoxDate.Value; }
            set { dateBoxDate.Value = value; }
        }

        /// <summary>
        /// Categories DataSource
        /// </summary>
        public IEnumerable<Category> Categories
        {
            set
            {
                checkBoxesCategories.Clear();
                foreach (Category category in value)
                {
                    checkBoxesCategories.Add(category.Title, category);
                }
            }
            get { return checkBoxesCategories.CheckedValues.Select(c => c as Category); }
        }

        /// <summary>
        /// Locales DataSource
        /// </summary>
        public Models<Locale> Locales
        {
            set { comboBoxLocales.DataSource = value; }
        }

        /// <summary>
        /// Incident Locale
        /// </summary>
        public Locale Locale
        {
            get { return comboBoxLocales.SelectedValue<Locale>(); }
            set { comboBoxLocales.SelectedItem = value; }
        }

        /// <summary>
        /// Incident Description
        /// </summary>
        public string Description
        {
            get { return textBoxDescription.Value; }
            set { textBoxDescription.Value = value; }
        }

        /// <summary>
        /// Media Items
        /// </summary>
        public Media[] MediaItems
        {
            get { return _MediaItems.ToArray(); }
            set
            {
                _MediaItems.Clear();
                scrollListBox.Clear();
                listViewNews.Clear();
                listViewVideos.Clear();
                if (value != null)
                {
                    foreach (Media media in value)
                    {
                        _MediaItems.Add(media);
                        if (media.IsNews)
                        {
                            listViewNews.Add(media.Link);
                        }
                        else if (media.IsVideo)
                        {
                            listViewVideos.Add(media.Link);
                        }
                        else if (media.IsPhoto)
                        {
                            scrollListBox.Add(media);
                        }
                    }
                }
                scrollListBox.AdjustHeight();
            }
        }private readonly List<Media> _MediaItems = new List<Media>();

        public void AddMedia(Media media)
        {
            _MediaItems.Add(media);
            if (media.MediaType == MediaType.News)
            {
                listViewNews.Add(media.Link);
            }
            else if (media.MediaType == MediaType.Video)
            {
                listViewVideos.Add(media.Link);
            }
            else if (media.MediaType == MediaType.Photo)
            {
                scrollListBox.Add(media);
                scrollListBox.AdjustHeight();    
            }
        }

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
                scrollListBox.Add(media);
                scrollListBox.AdjustHeight();
            }
        }

        private void OnAddNews(object sender, EventArgs e)
        {
            ShouldSave = false;
            OnForward<MediaViewController>(false, MediaType.News);
        }

        private void OnAddVideo(object sender, EventArgs e)
        {
            ShouldSave = false;
            OnForward<MediaViewController>(false, MediaType.Video);
        }

        private void OnSave(object sender, EventArgs e)
        {
            Log.Info("AddView.OnSave");
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
            panel.Height = ClientRectangle.Height - args.Bounds.Height;
        }

        private void OnResize(object sender, EventArgs e)
        {
            textBoxTitle.Width = 
            dateBoxDate.Width = 
            comboBoxLocales.Width = 
            checkBoxesCategories.Width = 
            textBoxDescription.Width = 
            listViewNews.Width =
            listViewVideos.Width =
            scrollListBox.Width = panel.ClientRectangle.Width;
        }
    }
}
