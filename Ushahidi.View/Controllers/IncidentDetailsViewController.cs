using System;
using Ushahidi.View.Models;
using Ushahidi.View.Views;

namespace Ushahidi.View.Controllers
{
    public class IncidentDetailsViewController : BaseViewController<IncidentDetailsView, IncidentDetailsModel>
    {
        public IncidentDetailsViewController()
        {
            View.ViewMap += OnViewMap;
            View.AddPhoto += OnAddPhoto;
        }

        /// <summary>
        /// Load the view
        /// </summary>
        public override void Load()
        {
            View.Image = Model.Images.Length > 0 ? Model.Images[0] : null;
            View.Title = Model.Title;
            View.Locale = Model.Location;
            View.Date = Model.Date;
            View.Verified = Model.Verified;
            View.Description = Model.Description;
        }

        /// <summary>
        /// On view map
        /// </summary>
        private void OnViewMap(object sender, EventArgs e)
        {
            //TODO show map
        }

        /// <summary>
        /// On add photo
        /// </summary>
        private void OnAddPhoto(object sender, EventArgs e)
        {
            //TODO add photo
        }
    }
}
