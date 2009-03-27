using Ushahidi.View.Views;
using Ushahidi.View.Models;

namespace Ushahidi.View.Controllers
{
    /// <summary>
    /// Sync View Controller
    /// </summary>
    public class SyncViewController : BaseViewController<SyncView, SyncModel>
    {
        /// <summary>
        /// Load View with Model data
        /// </summary>
        public override void Load()
        {
            View.LastSync = Model.LastSync;
        }

        /// <summary>
        /// Save View data to Model
        /// </summary>
        /// <returns></returns>
        public override bool Save()
        {
            Model.LastSync = View.LastSync;
            return Model.Save();
        }
    }
}
