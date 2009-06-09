using System;
using System.ComponentModel;
using System.Globalization;
using Ushahidi.Common.Controls;
using Ushahidi.Model;
using Ushahidi.Model.Extensions;

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
        }

        public override void Translate()
        {
            base.Translate();
            this.Translate("settings");
            menuItemAction.Translate("action");
            textBoxEmail.Translate("email");
            textBoxFirstName.Translate("firstName");
            textBoxLastName.Translate("lastName");
            comboBoxLanguages.Translate("language");
            checkBoxKeyboard.Translate("keyboard", "autoShow");
        }

        public override void Render()
        {
            ShouldSave = true;
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
        /// Is the process cancelled?
        /// </summary>
        public bool ShouldSave { get; private set; }

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
            DataManager.Language = comboBoxLanguages.SelectedValue<CultureInfo>();
            Translate();
        }

        private void OnKeyboardChanged(object sender, KeyboardEventArgs args)
        {
            panelContent.Height = ClientRectangle.Height - args.Bounds.Height;
        }
    }
}
