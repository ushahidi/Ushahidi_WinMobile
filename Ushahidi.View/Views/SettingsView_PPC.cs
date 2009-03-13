using Ushahidi.View.Controls;

namespace Ushahidi.View.Views
{
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
    }
}