using System.Drawing;
using System.IO;
using Ushahidi.Common;
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
            View.Logo = Logo;
        }

        /// <summary>
        /// Logo
        /// </summary>
        protected Image Logo
        {
            get
            {
                if (_Logo == null)
                {
                    string filePath = Path.Combine(Runtime.AppDirectory, "logo.png");
                    _Logo = File.Exists(filePath) ? new Bitmap(filePath) : ResourcesManager.LoadImageResource("ushahidi_btn.png");
                }
                return _Logo;
            }
        }private Image _Logo; 
    }
}
