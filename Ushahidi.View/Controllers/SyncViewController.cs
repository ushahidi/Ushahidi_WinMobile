using Ushahidi.Model;
using Ushahidi.View.Views;

namespace Ushahidi.View.Controllers
{
    /// <summary>
    /// Sync View Controller
    /// </summary>
    public class SyncViewController : BaseViewController<SyncView>
    {
        /// <summary>
        /// Load View with Model data
        /// </summary>
        public override void Load(object[] parameters)
        {
            View.LastSyncDate = DataManager.LastSyncDate;
            View.ServerAddress = DataManager.ServerAddress;
        }

        /// <summary>
        /// Save View data to Model
        /// </summary>
        /// <returns></returns>
        public override bool Save()
        {
            DataManager.ServerAddress = View.ServerAddress;
            DataManager.LastSyncDate = View.LastSyncDate;
            return DataManager.Save();
        }
    }
}
