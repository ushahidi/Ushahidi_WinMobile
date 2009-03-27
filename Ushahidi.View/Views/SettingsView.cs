using System;

namespace Ushahidi.View.Views
{
    /// <summary>
    /// Settings View
    /// </summary>
    partial class SettingsView
    {
        /// <summary>
        /// Server Address
        /// </summary>
        public string ServerAddress
        {
            get { return textBoxServer.Text; }
            set { textBoxServer.Text = value; }
        }

        /// <summary>
        /// Default Locale
        /// </summary>
        public string DefaultLocale
        {
            get { return textBoxLocale.Text; }
            set { textBoxLocale.Text = value; }
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
    }
}
