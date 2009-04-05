using System;
using Ushahidi.Model;

namespace Ushahidi.View.Models
{
    /// <summary>
    /// Sync Model
    /// </summary>
    public class SyncModel : BaseModel
    {
        /// <summary>
        /// Last sync
        /// </summary>
        public DateTime LastSync
        {
            get { return DataManager.LastSyncDate; }
            set { DataManager.LastSyncDate = value; }
        }

        public override bool Save()
        {
            return DataManager.Save();
        }
    }
}
