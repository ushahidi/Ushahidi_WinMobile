using Ushahidi.Common.Extensions;
using Ushahidi.Model.Models;
using Ushahidi.View.Views;

namespace Ushahidi.View.Controllers
{
    public class DetailsViewController : BaseViewController<DetailsView>
    {
        /// <summary>
        /// Load the view
        /// </summary>
        public override void Load(object[] parameters)
        {
            if (parameters.Exists(0))
            {
                View.Incident = parameters.ItemAtIndex<Incident>(0);    
            }
        }

        public override bool Save()
        {
            //TODO save incident changes
            return base.Save();
        }
    }
}
