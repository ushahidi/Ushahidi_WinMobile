using Ushahidi.Common.Controls;

namespace Ushahidi.View.Views
{
    public partial class WebsiteView : BaseView
    {
        public WebsiteView()
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