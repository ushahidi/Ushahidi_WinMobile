using Ushahidi.Common.Controls;

namespace Ushahidi.View.Views
{
    /// <summary>
    /// Settings view
    /// </summary>
    public partial class SettingsView : BaseView
    {
        /// <summary>
        /// Dummy checkbox placeholder
        /// </summary>
        private readonly LabelCheckBox checkBoxSettingsKeyboard = new LabelCheckBox();

        public SettingsView()
        {
            InitializeComponent();
        }
    }
}