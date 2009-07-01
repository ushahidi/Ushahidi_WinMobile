using System.Drawing;
using Ushahidi.View.Resources;
using Ushahidi.View.Views;

namespace Ushahidi.View.Controllers
{
    /// <summary>
    /// About View Controller
    /// </summary>
    public class AboutViewController : BaseViewController<AboutView>
    {
        public override void Load(object[] parameters)
        {
            View.Logo = UshahidiLogo;
        }

        private readonly Image UshahidiLogo = ResourcesManager.LoadImageResource("ushahidi_btn.png");
    }
}
