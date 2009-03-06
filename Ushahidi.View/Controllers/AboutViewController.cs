using Ushahidi.View.Models;
using Ushahidi.View.Views;

namespace Ushahidi.View.Controllers
{
    public class AboutViewController : BaseViewController<AboutView, AboutModel>
    {
        /// <summary>
        /// Load the view
        /// </summary>
        public override void Load()
        {
            View.AboutText = Model.AboutText;
            View.AboutLogo = Model.AboutLogo;
        }

        protected override void OnPrimaryAction(object sender, System.EventArgs e)
        {
            OnForward(typeof(WebsiteViewController));
        }
    }
}
