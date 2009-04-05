using System;
using System.Threading;
using System.Windows.Forms;
using Ushahidi.Common.Controls;
using Ushahidi.Common.Logging;
using Ushahidi.Common.Net;
using Ushahidi.Model;

namespace Ushahidi.View.Views
{
    /// <summary>
    /// Sync View
    /// </summary>
    partial class SyncView
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
        /// Start time
        /// </summary>
        private DateTime StartTime { get; set; }

        /// <summary>
        /// On Sync
        /// </summary>
        public void OnSynchronize(object sender, EventArgs args)
        {
            Log.Info("SyncView.OnSynchronize");
            progressBox.Value = 0;
            progressBox.Maximum = 7;
            listView.Items.Clear();
            columnHeader.Width = -2;
            StartTime = DateTime.Now;
            Internet.TestURL = string.Format("{0}/help", DataManager.ServerAddress);
            new Thread(SyncInternal).Start();
        }

        /// <summary>
        /// Sync Internal
        /// </summary>
        private void SyncInternal()
        {
            Log.Info("SyncView.SyncInternal");
            try
            {
                if (Download(Internet.HasNetworkConnection, "Testing Network Connection", 0) == false)
                {
                    Invoke(new UpdateProgressHandler(UpdateProgress), Status.NoNetwork, "No Network Connection", 0);
                }
                else if (Download(Internet.HasInternetConnection, "Testing Internet Connection", 1) == false)
                {
                    Invoke(new UpdateProgressHandler(UpdateProgress), Status.NoInternet, "No Internet Connection", 1);
                }
                else if (Download(DataManager.UploadIncidents, "Uploading Incidents", 2) &&
                         Download(DataManager.RefreshIncidents, "Refreshing Incidents", 3) &&
                         Download(DataManager.RefreshCountries, "Refreshing Countries", 4) &&
                         Download(DataManager.RefreshLocales, "Refreshing Locales", 5) &&
                         Download(DataManager.RefreshCategories, "Refreshing Categories", 6))
                {
                    Invoke(new UpdateProgressHandler(UpdateProgress), Status.Complete, "Refresh Complete", 7);
                }
                else
                {
                    Invoke(new UpdateProgressHandler(UpdateProgress), Status.Failure, "Refresh Failure", 7);
                }

            }
            catch (Exception ex)
            {
                Log.Exception("SyncView.SyncInternal", "Exception: {0}", ex.Message);
                Invoke(new UpdateProgressHandler(UpdateProgress), Status.Failure, "Refresh Failure", 7);
            }
        }

        /// <summary>
        /// Download
        /// </summary>
        /// <param name="downloadHandler">download handler delegate</param>
        /// <param name="taskName">task name</param>
        /// <param name="progress">progress</param>
        /// <returns>true, if successful</returns>
        private bool Download(DownloadHandler downloadHandler, string taskName, int progress)
        {
            Log.Info("SyncView.Download", "Task: {0}", taskName);
            Invoke(new UpdateProgressHandler(UpdateProgress), Status.Downloading, taskName, progress);
            if (downloadHandler.Invoke())
            {
                 return true;
            }
            return false;
        }

        /// <summary>
        /// The download handler delegate
        /// </summary>
        /// <returns></returns>
        private delegate bool DownloadHandler();

        /// <summary>
        /// Progress handler delegate
        /// </summary>
        /// <param name="status">download staatus</param>
        /// <param name="text">progress text</param>
        /// <param name="value">progress value</param>
        private delegate void UpdateProgressHandler(Status status, string text, int value);

        /// <summary>
        /// Update progress bar
        /// </summary>
        /// <param name="status">download status</param>
        /// <param name="text">progress text</param>
        /// <param name="value">progress value</param>
        private void UpdateProgress(Status status, string text, int value)
        {
            progressBox.Value = value;
            listView.Items.Add(new ListViewItem(text));
            double totalSeconds = DateTime.Now.Subtract(StartTime).TotalSeconds;
            if (status == Status.Downloading)
            {
                Cursor.Current = Cursors.WaitCursor;    
            }
            else if (status == Status.NoNetwork && Dialog.Warning("No Network Connection", "Please verify your device has a network connection"))
            {
                progressBox.Value = 0;
                progressBox.Text = "";
                Cursor.Current = Cursors.Default;
            }
            else if (status == Status.NoInternet && Dialog.Warning("No Internet Connection", "Please verify your device has an internet connection"))
            {
                progressBox.Value = 0;
                progressBox.Text = "";
                Cursor.Current = Cursors.Default;
            }
            else if (status == Status.Failure && Dialog.Warning("Refresh Failure", "{0} seconds", totalSeconds.ToString()))
            {
                progressBox.Value = 0;
                progressBox.Text = "";
                Cursor.Current = Cursors.Default;
            }
            else if (status == Status.Complete && Dialog.Info("Refresh Complete", "{0} seconds", totalSeconds.ToString()))
            {
                progressBox.Value = 0;
                progressBox.Text = "";
                LastSync = DateTime.Now;
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// Download Status
        /// </summary>
        enum Status
        {
            Downloading,
            Failure,
            Complete,
            NoNetwork,
            NoInternet
        }
    }
}
