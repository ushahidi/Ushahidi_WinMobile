using System;
using System.ComponentModel;
using System.Linq;
using System.Collections.Generic;
using Ushahidi.Common.Controls;
using Ushahidi.Common.Logging;
using Ushahidi.Common.MVC;
using Ushahidi.Map;
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
        private readonly Locator Locator = new Locator();

        public AddView()
        {
            InitializeComponent();
            Closing += OnClosing;
        }

        public override void Initialize()
        {
            base.Initialize();
            Keyboard.KeyboardChanged += OnKeyboardChanged;
            Locator.LocationChanged += OnDetectLocationChanged;
            panel.BackColor =
            textBoxTitle.BackColor =
            dateBoxDate.BackColor =
            dateBoxTime.BackColor =
            comboBoxLocales.BackColor =
            textBoxLatitude.BackColor =
            textBoxLongitude.BackColor =
            checkBoxesCategories.BackColor =
            textBoxDescription.BackColor =
            textBoxNews.BackColor =
            textBoxVideo.BackColor =
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
            textBoxLatitude.Translate("latitude");
            textBoxLongitude.Translate("longitude");
            textBoxNews.Translate("news");
            textBoxVideo.Translate("video");
            menuItemSubmit.Translate("submit");
            menuItemCancel.Translate("cancel");
            menuItemAddPhoto.Translate("addPhoto");
            menuItemAddNews.Translate("addNewsLink");
            menuItemAddVideo.Translate("addVideoLink");
            menuItemDetectLocation.Translate("detectLocation");
        }

        public override void Render()
        {
            ShouldSave = true;
            menuItemDetectLocation.Enabled = true;
            textBoxDescription.Top = checkBoxesCategories.Bottom;
            textBoxNews.Top = textBoxDescription.Bottom;
            textBoxVideo.Top = textBoxNews.Bottom;
            scrollListBox.Top = textBoxVideo.Bottom;
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

        private void OnClosing(object sender, CancelEventArgs e)
        {
            Locator.Stop();
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
            get
            {
                return new DateTime(dateBoxDate.Value.Year,
                                    dateBoxDate.Value.Month,
                                    dateBoxDate.Value.Day,
                                    dateBoxTime.Value.Hour,
                                    dateBoxTime.Value.Minute,
                                    dateBoxTime.Value.Second,
                                    dateBoxTime.Value.Millisecond);
            }
            set
            {
                dateBoxDate.Value = value;
                dateBoxTime.Value = value;
            }
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
                textBoxNews.Text = "";
                textBoxVideo.Text = "";
                if (value != null)
                {
                    foreach (Media media in value.Where(m => m.IsPhoto))
                    {
                        scrollListBox.Add(media);
                    }
                    Media news = value.FirstOrDefault(m => m.IsNews);
                    if (news != null)
                    {
                        textBoxNews.Value = news.Link;
                    }
                    Media video = value.FirstOrDefault(m => m.IsVideo);
                    if (video != null)
                    {
                        textBoxVideo.Value = video.Link;
                    }
                }
                scrollListBox.AdjustHeight();
            }
        }private readonly List<Media> _MediaItems = new List<Media>();

        public void AddMedia(Media media)
        {
            using (new WaitCursor())
            {
                _MediaItems.Add(media);
                if (media.MediaType == MediaType.News)
                {
                    textBoxNews.Value = media.Link;
                }
                else if (media.MediaType == MediaType.Video)
                {
                    textBoxVideo.Value = media.Link;
                }
                else if (media.MediaType == MediaType.Photo)
                {
                    scrollListBox.Add(media);
                    scrollListBox.AdjustHeight();
                }
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
            textBoxNews.Focus();
            OnForward<MediaViewController>(false, MediaType.News);
        }

        private void OnAddVideo(object sender, EventArgs e)
        {
            ShouldSave = false;
            textBoxVideo.Focus();
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
            Log.Info("AddView.OnCancel");
            ShouldSave = false;
            OnBack();
        }

        private void OnKeyboardChanged(object sender, KeyboardEventArgs args)
        {
            panel.Height = ClientRectangle.Height - args.Height;
        }

        private void OnResize(object sender, EventArgs e)
        {
            textBoxTitle.Width = 
            dateBoxDate.Width = 
            dateBoxTime.Width =
            comboBoxLocales.Width = 
            textBoxLatitude.Width =
            textBoxLongitude.Width =
            checkBoxesCategories.Width = 
            textBoxDescription.Width = 
            textBoxNews.Width =
            textBoxVideo.Width =
            scrollListBox.Width = panel.ClientRectangle.Width;
        }

        private void OnLocaleChanged(object sender, EventArgs e)
        {
            using (new WaitCursor())
            {
                Locale locale = comboBoxLocales.SelectedValue<Locale>();
                if (locale != null)
                {
                    textBoxLatitude.Value = locale.Latitude;
                    textBoxLongitude.Value = locale.Longitude;
                }
                else
                {
                    textBoxLatitude.Value = "";
                    textBoxLongitude.Value = "";
                }
                Locator.Stop();
                menuItemDetectLocation.Enabled = true;
            }
        }

        private void OnDetectLocation(object sender, EventArgs e)
        {
            Log.Info("AddView.OnDetectLocation", "");
            if (Locator.Start())
            {
                menuItemDetectLocation.Enabled = false;
                ProgressPanel.Show(this, "detectingLocation".Translate(), "cancel".Translate(), OnDetectLocationCancelled);
            }
            else
            {
                Dialog.Warning("detectLocation".Translate(), "notActive".Translate());
                menuItemDetectLocation.Enabled = false;
            }
        }

        private void OnDetectLocationCancelled(object sender, EventArgs e)
        {
            Locator.Stop();
            ProgressPanel.Hide(this);
            menuItemDetectLocation.Enabled = true;
        }

        private void OnDetectLocationChanged(object sender, LocationEventArgs args)
        {
            Log.Info("AddView.OnDetectLocationChanged", "");
            using (new WaitCursor())
            {
                Locale locale = new Locale
                {
                    CountryID = null,
                    Latitude = args.Latitude.ToString(),
                    Longitude = args.Longitude.ToString(),
                    Name = args.Address
                };

                DataManager.AddLocale(locale);

                textBoxLatitude.Value = args.Latitude.ToString();
                textBoxLongitude.Value = args.Longitude.ToString();

                comboBoxLocales.Add(locale);
                comboBoxLocales.SelectedItem = locale;
            }
        }
    }
}
