using System;

namespace Ushahidi.View.Views
{
    /// <summary>
    /// Sync view
    /// </summary>
    public partial class SyncView
    {
        /// <summary>
        /// Last sync
        /// </summary>
        public DateTime LastSync
        {
            get { return dateBox.Date; }
            set { dateBox.Date = value;}
        }

        /// <summary>
        /// Server
        /// </summary>
        public string Server
        {
            get { return textBoxServer.Text; }
            set { textBoxServer.Text = value;}
        }
    }
}
