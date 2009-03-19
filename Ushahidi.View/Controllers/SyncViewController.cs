using Ushahidi.View.Views;
using Ushahidi.View.Models;

namespace Ushahidi.View.Controllers
{
    /// <summary>
    /// Sync view controller
    /// </summary>
    public class SyncViewController : BaseViewController<SyncView, SyncModel>
    {
        /// <summary>
        /// Load the view
        /// </summary>
        public override void Load()
        {
            View.Server = Model.Server;
            View.LastSync = Model.LastSync;
        }
    }
}
