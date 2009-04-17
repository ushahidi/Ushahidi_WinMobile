using System;
using System.Drawing;
using Ushahidi.View.Models;
using Ushahidi.View.Views;

namespace Ushahidi.View.Controllers
{
    public class IncidentPhotoViewController : BaseViewController<IncidentPhotoView, IncidentPhotoModel>
    {
        public override void Load(object [] parameters)
        {
            if (parameters == null || parameters.Length == 0)
            {
                throw new ArgumentNullException("parameters", "Parameters can not be null");
            }
            View.Image = parameters[0] as Image;
        }
    }
}
