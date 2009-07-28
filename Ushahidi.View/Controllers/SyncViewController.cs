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
            View.ShouldDownloadMaps = DataManager.ShouldDownloadMaps;
            View.ShouldDownloadMedia = DataManager.ShouldDownloadMedia;
        }

        /// <summary>
        /// Save View data to Model
        /// </summary>
        /// <returns></returns>
        public override bool Save()
        {
            DataManager.ServerAddress = View.ServerAddress;
            DataManager.LastSyncDate = View.LastSyncDate;
            DataManager.ShouldDownloadMaps = View.ShouldDownloadMaps;
            DataManager.ShouldDownloadMedia = View.ShouldDownloadMedia;
            return DataManager.Save();
        }
    }
}
