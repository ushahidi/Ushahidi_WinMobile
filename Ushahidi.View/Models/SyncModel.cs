using System;

namespace Ushahidi.View.Models
{
    public class SyncModel : BaseModel
    {
        /// <summary>
        /// Last sync
        /// </summary>
        public DateTime LastSync { get; set; }

        /// <summary>
        /// Server
        /// </summary> 
        public string Server { get; set; }
    }
}
