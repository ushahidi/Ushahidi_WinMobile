using Ushahidi.Common.Extensions;
using Ushahidi.Model.Models;
using Ushahidi.View.Views;

namespace Ushahidi.View.Controllers
{
    /// <summary>
    /// Media View Controller
    /// </summary>
    public class MediaViewController : BaseViewController<MediaView>
    {
        public override void Load(object[] parameters)
        {
            if (parameters.Exists(0) && parameters[0] is MediaType)
            {
                View.MediaType = parameters.ItemAtIndex<MediaType>(0);
            }
            View.URL = null;
        }
    }
}
