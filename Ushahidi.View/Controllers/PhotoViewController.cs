using System.Drawing;
using Ushahidi.Common.Extensions;
using Ushahidi.View.Views;

namespace Ushahidi.View.Controllers
{
    /// <summary>
    /// Incident Photo View Controller
    /// </summary>
    public class PhotoViewController : BaseViewController<PhotoView>
    {
        public override void Load(object [] parameters)
        {
            if (parameters.Exists(0))
            {
                View.Image = parameters.ItemAtIndex<Bitmap>(0);
            }
        }

        public override bool Save()
        {
            if (View.Image != null)
            {
                View.Image.Dispose();
                View.Image = null;
            }
            return base.Save();
        }
    }
}
