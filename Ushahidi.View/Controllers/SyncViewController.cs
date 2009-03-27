using Ushahidi.Model;
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
            Model.Load();
            View.LastSync = Model.LastSync;
            //DataManager2 d = new DataManager2();
            //View.LastSync = d.LastSyncDate;
            //View.LastSync = DataManager2.Instance.LastSyncDate;
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
