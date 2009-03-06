using System.Drawing;
using Ushahidi.View.Resources;

namespace Ushahidi.View.Models
{
    public class AboutModel : BaseModel
    {
        /// <summary>
        /// The about text
        /// </summary>
        public string AboutText
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
        /// The about logo
        /// </summary>
        public Image AboutLogo
        {
            get
            {
                if (_AboutLogo == null)
                {
                    _AboutLogo = ResourcesManager.LoadImageResource("ushahidi_btn.png");
                }
                return _AboutLogo;
            }
        }private Image _AboutLogo;

        /// <summary>
        /// Dispose of resources
        /// </summary>
        public override void Dispose()
        {
            if (_AboutLogo != null)
            {
                _AboutLogo.Dispose();
                _AboutLogo = null;
            }
        }
    }
}
