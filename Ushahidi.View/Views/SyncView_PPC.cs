using Ushahidi.View.Controls;

namespace Ushahidi.View.Views
{
    /// <summary>
    /// Sync view
    /// </summary>
    public partial class SyncView : BaseView
    {
        public SyncView()
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