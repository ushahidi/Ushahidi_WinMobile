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
        /// The description
        /// </summary>
        public string Description
        {
            get
            {
                return "Welcome to Ushahidi, which means “testimony” in Swahili, " +
                       "where we are building a platform that crowdsources crisis information. " +
                       "Allowing anyone to submit crisis information through text messaging " +
                       "using a mobile phone, email or web form.";
            }
        }

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
