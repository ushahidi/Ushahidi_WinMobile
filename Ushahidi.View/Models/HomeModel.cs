using System.Drawing;
using Ushahidi.View.Resources;

namespace Ushahidi.View.Models
{
    /// <summary>
    /// Home model
    /// </summary>
    public class HomeModel : BaseModel
    {
        /// <summary>
        /// The logo
        /// </summary>
        public Image Logo
        {
            get
            {
                if (_Logo == null)
                {
                    _Logo = ResourcesManager.LoadImageResource("ushahidi_btn.png");
                }
                return _Logo;
            }
        }private Image _Logo;
    }
}
