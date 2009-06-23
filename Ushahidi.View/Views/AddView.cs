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
            menuItemSave.Translate("saveIncident");
            menuItemCancel.Translate("cancel");
            menuItemAddPhoto.Translate("addPhoto");
            menuItemAddNews.Translate("addNewsLink");
            menuItemAddVideo.Translate("addVideoLink");
        }

        public override void Render()
        {
            ShouldSave = true;
            textBoxTitle.Top = 0;
            dateBoxDate.Top = textBoxTitle.Bottom;
            comboBoxLocales.Top = dateBoxDate.Bottom;
            checkBoxesCategories.Top = comboBoxLocales.Bottom;
            textBoxDescription.Top = checkBoxesCategories.Bottom;
            scrollListBox.Top = textBoxDescription.Bottom;
            scrollListBox.AdjustHeight();
            textBoxTitle.BackColor = Colors.Background;
            dateBoxDate.BackColor = Colors.Background;
            comboBoxLocales.BackColor = Colors.Background;
            checkBoxesCategories.BackColor = Colors.Background;
            textBoxDescription.BackColor = Colors.Background;
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
            textBoxTitle.Width = panel.ClientRectangle.Width;
            dateBoxDate.Width = panel.ClientRectangle.Width;
            comboBoxLocales.Width = panel.ClientRectangle.Width;
            checkBoxesCategories.Width = panel.ClientRectangle.Width;
            textBoxDescription.Width = panel.ClientRectangle.Width;
            scrollListBox.Width = panel.ClientRectangle.Width;
        }
    }
}
