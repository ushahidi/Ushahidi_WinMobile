namespace Ushahidi.View.Views
{
    public partial class SettingsView
    {
        /// <summary>
        /// Default locale
        /// </summary>
        public string DefaultLocale
        {
            get { return textBoxDefaultLocation.Text; }
            set { textBoxDefaultLocation.Text = value; }
        }
    }
}
