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
        /// Should refresh incidents?
        /// </summary>
        private bool RefreshIncidents { get; set; }

        /// <summary>
        /// Should refresh countries?
        /// </summary>
        private bool RefreshCountries { get; set; }

        /// <summary>
        /// Should refresh locales?
        /// </summary>
        private bool RefreshLocales { get; set; }

        /// <summary>
        /// Should refresh categories?
        /// </summary>
        private bool RefreshCategories { get; set; }

        /// <summary>
        /// On Sync
        /// </summary>
        public void OnSynchronize(object sender, EventArgs args)
        {
            progressBox.Value = 0;
            progressBox.Maximum = 6;
            StartTime = DateTime.Now;
            RefreshIncidents = checkBoxIncidents.Checked;
            RefreshCountries = checkBoxCountries.Checked;
            RefreshLocales = checkBoxLocales.Checked;
            RefreshCategories = checkBoxCategories.Checked;
            Thread thread = new Thread(SyncInternal);
            thread.Start(); 
        }

        /// <summary>
        /// Sync Internal
        /// </summary>
        private void SyncInternal()
        {
            try
            {
                if (Download(Internet.HasNetworkConnection, true, "Testing Network", 0) == false)
                {
                    Invoke(new UpdateProgressHandler(UpdateProgress), Status.NoNetwork, "No Network Connection", 0);
                }
                else if (Download(Internet.HasInternetConnection, true, "Testing Internet", 1) == false)
                {
                    Invoke(new UpdateProgressHandler(UpdateProgress), Status.NoInternet, "No Internet Connection", 0);
                }
                else if (Download(DataManager.RefreshIncidents, RefreshIncidents, "Refreshing Incidents", 2) &&
                         Download(DataManager.RefreshCountries, RefreshCountries, "Refreshing Countries", 3) &&
                         Download(DataManager.RefreshLocales, RefreshLocales, "Refreshing Locales", 4) &&
                         Download(DataManager.RefreshCategories, RefreshCategories, "Refreshing Categories", 5))
                {
                    Invoke(new UpdateProgressHandler(UpdateProgress), Status.Complete, "Refresh Complete", 6);
                }
                else
                {
                    Invoke(new UpdateProgressHandler(UpdateProgress), Status.Failure, "Refresh Failure", 6);
                }

            }
            catch (Exception ex)
            {
                Log.Exception("SyncView.SyncInternal", "Exception: {0}", ex.Message);
                Invoke(new UpdateProgressHandler(UpdateProgress), Status.Failure, "Refresh Failure", 6);
            }
        }

        /// <summary>
        /// Download
        /// </summary>
        /// <param name="downloadHandler">download handler delegate</param>
        /// <param name="shouldRefresh">should refresh?</param>
        /// <param name="taskName">task name</param>
        /// <param name="progress">progress</param>
        /// <returns>true, if successful</returns>
        private bool Download(DownloadHandler downloadHandler, bool shouldRefresh, string taskName, int progress)
        {
            if (shouldRefresh)
            {
                Invoke(new UpdateProgressHandler(UpdateProgress), Status.Downloading, string.Format("{0}...", taskName), progress);
                return downloadHandler.Invoke();
            }
            Invoke(new UpdateProgressHandler(UpdateProgress), Status.Downloading, string.Format("Skipping {0}", taskName), progress);
            return true;
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
            progressBox.Text = text;
            progressBox.Value = value;
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
