using System.Drawing;
using Ushahidi.Common.Controls;
using Ushahidi.Model;
using Ushahidi.View.Resources;
using Ushahidi.View.Views;

namespace Ushahidi.View.Controllers
{
    /// <summary>
    /// Home View Controller
    /// </summary>
    public class HomeViewController : BaseViewController<HomeView>
    {
        /// <summary>
        /// Load the view
        /// </summary>
        public override void Load(object[] parameters)
        {
            Keyboard.AutoShow = DataManager.ShowKeyboard;
            View.Logo = UshahidiLogo;
        }

        /// <summary>
        /// The logo
        /// </summary>
        private readonly Image UshahidiLogo = ResourcesManager.LoadImageResource("ushahidi_btn.png");
    }
}
