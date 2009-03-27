using Ushahidi.Common.Controls;
using Ushahidi.View.Controls;

namespace Ushahidi.View.Views
{
    public partial class IncidentDetailsView : BaseView
    {
        public IncidentDetailsView()
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