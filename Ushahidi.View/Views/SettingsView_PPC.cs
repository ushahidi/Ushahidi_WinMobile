using Ushahidi.Common.Controls;

namespace Ushahidi.View.Views
{
    /// <summary>
    /// Settings view
    /// </summary>
    public partial class SettingsView : BaseView
    {
        public SettingsView()
        {
            InitializeComponent();
            Keyboard.KeyboardChanged += OnKeyboardChanged;
        }

        private void OnKeyboardChanged(object sender, KeyboardEventArgs args)
        {
            panelContent.Height = Height - args.KeyboardBounds.Height;
        }

        private void OnKeyboardAutoShow(object sender, System.EventArgs e)
        {
            Keyboard.AutoShowHideKeyboard = checkBoxKeyboard.Checked;
        }
    }
}