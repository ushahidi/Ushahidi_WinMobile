using System;
using System.Globalization;
using Ushahidi.Common.Controls;
using Ushahidi.Model;
using Ushahidi.Model.Extensions;
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
            buttonClearCache.Click += OnClearCache;
            textBoxEmail.BackColor = Colors.Background;
            textBoxFirstName.BackColor = Colors.Background;
            textBoxLastName.BackColor = Colors.Background;
            comboBoxLanguages.BackColor = Colors.Background;
            comboBoxMapType.BackColor = Colors.Background;
            checkBoxKeyboard.BackColor = Colors.Background;
            panelContent.BackColor = Colors.Background;
        }

        public override void Translate()
        {
            base.Translate();
            this.Translate("settings");
            menuItemAction.Translate("done");
            textBoxEmail.Translate("email");
            textBoxFirstName.Translate("firstName");
            textBoxLastName.Translate("lastName");
            comboBoxLanguages.Translate("language");
            comboBoxMapType.Translate("mapType");
            checkBoxKeyboard.Translate("keyboard", "autoShow");
            buttonClearCache.Translate("clearCache");
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
            panelContent.Height = ClientRectangle.Height - args.Bounds.Height;
        }

        private static void OnClearCache(object sender, EventArgs e)
        {
            if (Dialog.Question("clearCache".Translate(), "areYouSure".Translate()))
            {
                bool result;
                using (new WaitCursor())
                {
                    result = DataManager.ClearCacheFiles();
                }
                if (result)
                {
                    DataManager.LastSyncDate = DateTime.MinValue;
                    Dialog.Info("clearCache".Translate(), "done".Translate());
                }
            }
        }
    }
}
