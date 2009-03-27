using System;
using System.Threading;
using System.Windows.Forms;
using Ushahidi.Common.Controls;
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
        /// On Sync
        /// </summary>
        public void OnSynchronize(object sender, EventArgs args)
        {
            StartTime = DateTime.Now;
            RefreshIncidents = checkBoxIncidents.Checked;
            RefreshCountries = checkBoxCountries.Checked;
            RefreshLocales = checkBoxLocales.Checked;
            RefreshCategories = checkBoxCategories.Checked;
            Thread thread = new Thread(SyncInternal);
            thread.Start();
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
        /// Sync Internal
        /// </summary>
        private void SyncInternal()
        {
            Download(DataManager.RefreshIncidents, RefreshIncidents, "Incidents", 0);
            Download(DataManager.RefreshCountries, RefreshCountries, "Countries", 1);
            Download(DataManager.RefreshLocales, RefreshLocales, "Locales", 2);
            Download(DataManager.RefreshCategories, RefreshCategories, "Categories", 3);
            Invoke(new UpdateProgressHandler(UpdateProgress), "Synchronization Complete", 4, 4);
        }

        private void Download(DownloadHandler downloadHandler, bool shouldRefresh, string taskName, int progress)
        {
            if (shouldRefresh)
            {
                Invoke(new UpdateProgressHandler(UpdateProgress), string.Format("Refreshing {0}...", taskName), progress, 4);
                if (downloadHandler.Invoke())
                {
                    Invoke(new UpdateProgressHandler(UpdateProgress), string.Format("{0} Refreshed", taskName), progress, 4);
                }
                else
                {
                    Invoke(new UpdateProgressHandler(UpdateProgress), string.Format("{0} Unsuccessful", taskName), progress, 4);
                }
            }
            else
            {
                Invoke(new UpdateProgressHandler(UpdateProgress), string.Format("Skipping {0}...", taskName), progress, 4);
            }
        }

        private delegate bool DownloadHandler();

        private delegate void UpdateProgressHandler(string text, int value, int maximum);
        private void UpdateProgress(string text, int value, int maximum)
        {
            progressBox.Text = text;
            progressBox.Value = value;
            progressBox.Maximum = maximum;
            if (value < maximum)
            {
                Cursor.Current = Cursors.WaitCursor;
            }
            else
            {
                Cursor.Current = Cursors.Default;
                if (Dialog.Info("Synchronization", "Complete: {0} seconds", 
                            DateTime.Now.Subtract(StartTime).TotalSeconds.ToString()))
                {
                    progressBox.Value = 0;
                    progressBox.Text = "";
                    LastSync = DateTime.Now;
                }
            }
        }
    }
}
