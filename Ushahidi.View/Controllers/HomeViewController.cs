using Ushahidi.Common.Controls;
using Ushahidi.Model;
using Ushahidi.View.Models;
using Ushahidi.View.Views;

namespace Ushahidi.View.Controllers
{
    /// <summary>
    /// Home View Controller
    /// </summary>
    public class HomeViewController : BaseViewController<HomeView, HomeModel>
    {
        /// <summary>
        /// Load the view
        /// </summary>
        public override void Load()
        {
            Keyboard.AutoShowHideKeyboard = DataManager.ShowKeyboard;
            View.Description = Model.Description;
            View.Logo = Model.Logo;
        }
    }
}
