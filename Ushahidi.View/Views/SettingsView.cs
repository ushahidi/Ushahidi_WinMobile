using System;
using System.ComponentModel;
using System.Globalization;
using Ushahidi.View.Languages;

namespace Ushahidi.View.Views
{
    /// <summary>
    /// Settings View
    /// </summary>
    partial class SettingsView
    {
        public override void Initialize()
        {
            base.Initialize();
            menuItemSettingsDone.Click += OnDone;
            menuItemSettingsCancel.Click += OnCancel;
            comboBoxSettingsLanguages.SelectedIndexChanged += OnLanguageChanged;
        }

        public override void Translate()
        {
            base.Translate();
            menuItemAction.Translate(this);
            textBoxSettingsServer.Translate();
            textBoxSettingsEmail.Translate();
            textBoxSettingsFirstName.Translate();
            textBoxSettingsLastName.Translate();
            comboBoxSettingsLanguages.Translate();
            checkBoxSettingsKeyboard.Translate("autoShow");
        }
        /// <summary>
        /// Server Address
        /// </summary>
        public string ServerAddress
        {
            get { return textBoxSettingsServer.Text; }
            set { textBoxSettingsServer.Text = value; }
        }

        /// <summary>
        /// First Name
        /// </summary>
        public string FirstName
        {
            get { return textBoxSettingsFirstName.Text; }
            set { textBoxSettingsFirstName.Text = value; }
        }

        /// <summary>
        /// Last Name
        /// </summary>
        public string LastName
        {
            get { return textBoxSettingsLastName.Text; }
            set { textBoxSettingsLastName.Text = value; }
        }

        /// <summary>
        /// Languages
        /// </summary>
        public object Languages
        {
            get { return comboBoxSettingsLanguages.DataSource; }
            set { comboBoxSettingsLanguages.DataSource = value; }
        }

        /// <summary>
        /// Current language
        /// </summary>
        public CultureInfo Language
        {
            get { return comboBoxSettingsLanguages.SelectedValue<CultureInfo>(); }
            set { comboBoxSettingsLanguages.SelectedItem = value; }
        }

        /// <summary>
        /// Email
        /// </summary>
        public string Email
        {
            get { return textBoxSettingsEmail.Text; }
            set { textBoxSettingsEmail.Text = value; }
        }

        /// <summary>
        /// Show keyboard?
        /// </summary>
        public bool ShowKeyboard
        {
            get { return checkBoxSettingsKeyboard.Checked; }
            set { checkBoxSettingsKeyboard.Checked = value; }
        }

        /// <summary>
        /// Is the process cancelled?
        /// </summary>
        public bool ShouldSave { get; private set; }

        public override void Render()
        {
            ShouldSave = true;
        }

        /// <summary>
        /// On Done
        /// </summary>
        private void OnDone(object sender, EventArgs e)
        {
            ShouldSave = true;
            OnBack();
        }

        /// <summary>
        /// On Done
        /// </summary>
        private void OnCancel(object sender, EventArgs e)
        {
            ShouldSave = false;
            OnBack();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            ShouldSave = true;
            base.OnClosing(e);
        }

        private void OnLanguageChanged(object sender, EventArgs e)
        {
            LanguageManager.Language = comboBoxSettingsLanguages.SelectedValue<CultureInfo>();
            Translate();
        }
    }
}
