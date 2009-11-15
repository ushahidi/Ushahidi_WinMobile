using Ushahidi.Common.Logging;
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
            Log.Info("SyncViewController.Load", "");
            View.LastSyncDate = DataManager.LastSyncDate;
            View.ServerAddress = DataManager.ServerAddress;
            View.ShouldDownloadIncidents = DataManager.ShouldDownloadIncidents;
            View.ShouldDownloadMedia = DataManager.ShouldDownloadMedia;
            View.ShouldDownloadMaps = DataManager.ShouldDownloadMaps;
        }

        /// <summary>
        /// Save View data to Model
        /// </summary>
        /// <returns></returns>
        public override bool Save()
        {
            Log.Info("SyncViewController.Save", "");
            DataManager.ServerAddress = View.ServerAddress;
            DataManager.LastSyncDate = View.LastSyncDate;
            DataManager.ShouldDownloadIncidents = View.ShouldDownloadIncidents;
            DataManager.ShouldDownloadMedia = View.ShouldDownloadMedia;
            DataManager.ShouldDownloadMaps = View.ShouldDownloadMaps;
            return DataManager.Save();
        }
    }
}
