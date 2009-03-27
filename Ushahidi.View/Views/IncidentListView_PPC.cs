using Ushahidi.Common.Controls;

namespace Ushahidi.View.Views
{
    public partial class IncidentListView : BaseView
    {
        public IncidentListView()
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