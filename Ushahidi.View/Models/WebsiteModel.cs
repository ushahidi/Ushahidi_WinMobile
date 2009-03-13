using System;

namespace Ushahidi.View.Models
{
    /// <summary>
    /// Website model
    /// </summary>
    public class WebsiteModel : BaseModel
    {
        /// <summary>
        /// Website URL
        /// </summary>
        public Uri WebsiteURL
        {
            get { return new Uri("http://ushahidi.com");  }
        }
    }
}
