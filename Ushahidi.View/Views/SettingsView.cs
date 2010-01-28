using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Ushahidi.Common;
using Ushahidi.Common.Controls;
using Ushahidi.Common.MVC;
using Ushahidi.Model;
using Ushahidi.Model.Extensions;
using Ushahidi.Model.Models;
using Ushahidi.View.Controls;

namespace Ushahidi.View.Views
{
    /// <summary>
    /// Settings View
    /// </summary>
    public partial class SettingsView : BaseView
    {
        public SettingsView()
        {
            InitializeComponent();    
        }

        public override void Initialize()
        {
            base.Initialize();
            Keyboard.KeyboardChanged += OnKeyboardChanged;
            textBoxVersion.BackColor = Colors.Background;
            textBoxEmail.BackColor = Colors.Background;
            textBoxFirstName.BackColor = Colors.Background;
            textBoxLastName.BackColor = Colors.Background;
            comboBoxLanguages.BackColor = Colors.Background;
            comboBoxMapType.BackColor = Colors.Background;
            checkBoxKeyboard.BackColor = Colors.Background;
            checkBoxGPS.BackColor = Colors.Background;
            panelContent.BackColor = Colors.Background;
            comboBoxLocales.BackColor = Colors.Background;
            comboBoxPhotoSizes.BackColor = Colors.Background;
            checkBoxKeyboard.Visible = checkBoxKeyboard.Enabled = checkBoxKeyboard.TabStop = Runtime.IsPocketPC;
        }

        public override void Translate()
        {
            base.Translate();
            this.Translate("settings");
            menuItemAction.Translate("action");
            textBoxVersion.Translate("version");
            textBoxEmail.Translate("email");
            textBoxFirstName.Translate("firstName");
            textBoxLastName.Translate("lastName");
            comboBoxLanguages.Translate("language");
            comboBoxMapType.Translate("mapType");
            comboBoxLocales.Translate("defaultLocation");
            comboBoxPhotoSizes.Translate("imageSize");
            checkBoxGPS.Translate("gps", "enabled");
            checkBoxKeyboard.Translate("keyboard", "autoShow");
            menuItemClear.Translate("clearCache");
            menuItemDone.Translate("done");
        }

        public override void Render()
        {
            base.Render();
            textBoxVersion.Width = panelContent.ClientRectangle.Width;
            textBoxEmail.Width = panelContent.ClientRectangle.Width;
            textBoxFirstName.Width = panelContent.ClientRectangle.Width;
            textBoxLastName.Width = panelContent.ClientRectangle.Width;
            comboBoxLanguages.Width = panelContent.ClientRectangle.Width;
            comboBoxMapType.Width = panelContent.ClientRectangle.Width;
            checkBoxKeyboard.Width = panelContent.ClientRectangle.Width;
            comboBoxLocales.Width = panelContent.ClientRectangle.Width;
            comboBoxPhotoSizes.Width = panelContent.ClientRectangle.Width;
            checkBoxGPS.Width = panelContent.ClientRectangle.Width;
        }
       
        public override bool Validate()
        {
            if (comboBoxLanguages.SelectedIndex == -1)
            {
                Dialog.Warning("language".Translate(), "missingFieldsVerify".Translate());
                comboBoxLanguages.Focus();
                return false;
            }
            if (comboBoxMapType.SelectedIndex == -1)
            {
                Dialog.Warning("mapType".Translate(), "missingFieldsVerify".Translate());
                comboBoxMapType.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Application version
        /// </summary>
        public string Version
        {
            get { return textBoxVersion.Value; }
            set { textBoxVersion.Value = value; }
        }

        /// <summary>
        /// Locales
        /// </summary>
        public Models<Locale> Locales
        {
            set { comboBoxLocales.DataSource = value; }
        }

        /// <summary>
        /// Default Locale
        /// </summary>
        public Locale DefaultLocale
        {
            get { return comboBoxLocales.SelectedValue<Locale>(); }
            set { comboBoxLocales.SelectedItem = value; }
        }

        /// <summary>
        /// First Name
        /// </summary>
        public string FirstName
        {
            get { return textBoxFirstName.Value; }
            set { textBoxFirstName.Value = value; }
        }

        /// <summary>
        /// Last Name
        /// </summary>
        public string LastName
        {
            get { return textBoxLastName.Value; }
            set { textBoxLastName.Value = value; }
        }

        /// <summary>
        /// Languages
        /// </summary>
        public object Languages
        {
            get { return comboBoxLanguages.DataSource; }
            set { comboBoxLanguages.DataSource = value; }
        }

        /// <summary>
        /// Map Types
        /// </summary>
        public object MapTypes
        {
            get { return comboBoxMapType.DataSource; }
            set { comboBoxMapType.DataSource = value; }
        }

        /// <summary>
        /// Map Types
        /// </summary>
        public string MapType
        {
            get { return comboBoxMapType.SelectedValue<string>(); }
            set { comboBoxMapType.SelectedItem = value; }
        }

        /// <summary>
        /// Image Sizes
        /// </summary>
        public object ImageSizes
        {
            get { return comboBoxPhotoSizes.DataSource; }
            set
            {
                comboBoxPhotoSizes.DataSource = value;
                IEnumerable<ImageSize> imageSizes = value as IEnumerable<ImageSize>;
                comboBoxPhotoSizes.Enabled = imageSizes != null && imageSizes.Count() > 0;
            }
        }

        /// <summary>
        /// Image Size
        /// </summary>
        public ImageSize ImageSize
        {
            get { return comboBoxPhotoSizes != null ? comboBoxPhotoSizes.SelectedValue<ImageSize>() : null; }
            set
            {
                if (comboBoxPhotoSizes != null && value != null)
                {
                    comboBoxPhotoSizes.SelectedItem = value;
                }
                else if (comboBoxPhotoSizes != null && comboBoxPhotoSizes.Count > 0)
                {
                    comboBoxPhotoSizes.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// Current language
        /// </summary>
        public CultureInfo Language
        {
            get { return comboBoxLanguages.SelectedValue<CultureInfo>(); }
            set { comboBoxLanguages.SelectedItem = value; }
        }

        /// <summary>
        /// Email
        /// </summary>
        public string Email
        {
            get { return textBoxEmail.Value; }
            set { textBoxEmail.Value = value; }
        }

        /// <summary>
        /// Show keyboard?
        /// </summary>
        public bool ShowKeyboard
        {
            get { return checkBoxKeyboard.Checked; }
            set { checkBoxKeyboard.Checked = value; }
        }

        /// <summary>
        /// Enble GPS
        /// </summary>
        public bool EnableGPS
        {
            get { return checkBoxGPS.Checked; }
            set { checkBoxGPS.Checked = value; }
        }

        /// <summary>
        /// On Done
        /// </summary>
        private void OnDone(object sender, EventArgs e)
        {
            OnBack();
        }

        private void OnLanguageChanged(object sender, EventArgs e)
        {
            DataManager.Language = comboBoxLanguages.SelectedValue<CultureInfo>();
            Translate();
        }

        private void OnKeyboardChanged(object sender, KeyboardEventArgs args)
        {
            panelContent.Height = ClientRectangle.Height - args.Height;
        }

        private void OnClearCache(object sender, EventArgs e)
        {
            if (Dialog.Question("clearCache".Translate(), "areYouSure".Translate()))
            {
                WaitCursor.Show();
                if (DataManager.ClearCacheFiles())
                {
                    WaitCursor.Hide();
                    DataManager.LastSyncDate = DateTime.MinValue;
                    Dialog.Info("clearCache".Translate(), "done".Translate());
                }
                else
                {
                    WaitCursor.Hide();
                }
            }
        }
    }
}
