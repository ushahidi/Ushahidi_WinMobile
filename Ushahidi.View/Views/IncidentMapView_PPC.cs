using Ushahidi.View.Controls;

namespace Ushahidi.View.Views
{
    public partial class IncidentMapView : BaseView
    {
        public IncidentMapView()
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