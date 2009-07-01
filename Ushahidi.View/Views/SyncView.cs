using System;
using System.Threading;
using System.Windows.Forms;
using Ushahidi.Common.Controls;
using Ushahidi.Common.Logging;
using Ushahidi.Common.Net;
using Ushahidi.Model;
using Ushahidi.Model.Extensions;
using Ushahidi.View.Controls;

namespace Ushahidi.View.Views
{
    /// <summary>
    /// Sync View
    /// </summary>
    public partial class SyncView : BaseView
    {
        public SyncView()
        {
            InitializeComponent();    
        }

        public override void Initialize()
        {
            base.Initialize();
            Keyboard.KeyboardChanged += OnKeyboardChanged;
            dateBoxLastSync.BackColor = Colors.Background;
            textBoxServer.BackColor = Colors.Background;
            progressBox.BackColor = Colors.Background;
            panelContent.BackColor = Colors.Background;
        }

        public override void Translate()
        {
            base.Translate();
            this.Translate("synchronize");
            dateBoxLastSync.Translate("lastSynchronization");
            textBoxServer.Translate("server");
            menuItemAction.Translate("synchronize");
        }

        public override void Render()
        {
            base.Render();
            progressBox.Value = 0;
            listView.Items.Clear();
            listView.Focus();
        }

        /// <summary>
        /// Last sync
        /// </summary>
        public DateTime LastSyncDate
        {
            get { return dateBoxLastSync.Value; }
            set { dateBoxLastSync.Value = value;}
        }

        public string ServerAddress
        {
            get { return textBoxServer.Value; }
            set { textBoxServer.Value = value; }
        }

        /// <summary>
        /// Start time
        /// </summary>
        private DateTime StartTime { get; set; }

        private bool Synchronizing
        {
            set
            {
                textBoxServer.Enabled = 
                menuItemAction.Enabled = 
                menuItemMenu.Enabled = !value;
            }
        }

        /// <summary>
        /// On Sync
        /// </summary>
        public void OnSynchronize(object sender, EventArgs args)
        {
            Log.Info("SyncView.OnSynchronize");
            progressBox.Value = 0;
            progressBox.Maximum = 10;
            listView.Items.Clear();
            columnHeaderProgress.Width = -2;
            StartTime = DateTime.Now;
            Synchronizing = true;
            Internet.TestURL = textBoxServer.Value;
            DataManager.ScreenWidth = Screen.PrimaryScreen.Bounds.Width;
            DataManager.ScreenHeight = Screen.PrimaryScreen.Bounds.Height;
            DataManager.ServerAddress = textBoxServer.Value;
            listView.Focus();
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
                if (Download(Internet.HasNetworkConnection, "testingNetworkConnection".Translate(), 0) == false)
                {
                    Invoke(new UpdateProgressHandler(UpdateProgress), Status.NoNetwork, "No Network Connection", 0);
                }
                else if (Download(Internet.HasInternetConnection, "testingInternetConnection".Translate(), 1) == false)
                {
                    Invoke(new UpdateProgressHandler(UpdateProgress), Status.NoInternet, "noInternetConnection".Translate(), 1);
                }
                else if (Download(DataManager.UploadIncidents, "uploadingIncidents".Translate(), 2) &&
                         Download(DataManager.UploadPhotos, "uploadingPhotos".Translate(), 3) &&
                         Download(DataManager.DownloadIncidents, "downloadingIncidents".Translate(), 4) &&
                         Download(DataManager.DownloadCountries, "downloadingCountries".Translate(), 5) &&
                         Download(DataManager.DownloadLocales, "downloadingLocations".Translate(), 6) &&
                         Download(DataManager.DownloadCategories, "downloadingCategories".Translate(), 7) &&
                         Download(DataManager.DownloadMedia, "downloadingMedia".Translate(), 8) &&
                         Download(DataManager.DownloadMaps, "downloadingMaps".Translate(), 9))
                {
                    Invoke(new UpdateProgressHandler(UpdateProgress), Status.Complete, "synchronizationComplete".Translate(), 10);
                }
                else
                {
                    Invoke(new UpdateProgressHandler(UpdateProgress), Status.Failure, "synchronizationFailure".Translate(), 10);
                }

            }
            catch (Exception ex)
            {
                Log.Exception("SyncView.SyncInternal", "Exception: {0}", ex.Message);
                Invoke(new UpdateProgressHandler(UpdateProgress), Status.Failure, "synchronizationFailure".Translate(), 10);
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
            Invoke(new UpdateProgressHandler(UpdateProgress), Status.Downloading, taskName, progress);
            if (downloadHandler.Invoke())
            {
                 Log.Info("SyncView.Download", "Task {0} Successful", taskName);
                 return true;
            }
            Log.Info("SyncView.Download", "Task {0} Failed", taskName);
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
            columnHeaderProgress.Width = -2;
            if (status == Status.Downloading)
            {
                Cursor.Current = Cursors.WaitCursor;    
            }
            else
            {
                if (status == Status.NoNetwork && Dialog.Warning("noNetworkConnection".Translate(), "verifyNetworkConnection".Translate()))
                {
                    Log.Info("SyncView.UpdateProgress", "noNetworkConnection");
                }
                else if (status == Status.NoInternet && Dialog.Warning("noInternetConnection".Translate(), "verifyInternetConnection".Translate()))
                {
                    Log.Info("SyncView.UpdateProgress", "noInternetConnection");
                }
                else if (status == Status.Failure && Dialog.Warning("synchronizationFailure".Translate(), "{0} {1}", totalSeconds.ToString(), "seconds".Translate()))
                {
                    Log.Info("SyncView.UpdateProgress", "synchronizationFailure");
                }
                else if (status == Status.Complete && Dialog.Info("synchronizationComplete".Translate(), "{0} {1}", totalSeconds.ToString(), "seconds".Translate()))
                {
                    Log.Info("SyncView.UpdateProgress", "synchronizationComplete");
                    LastSyncDate = DateTime.Now;
                }
                Synchronizing = false;
                progressBox.Value = 0;
                progressBox.Text = "";
                Cursor.Current = Cursors.Default;
            }
            columnHeaderProgress.Width = -2;
        }

        private void OnKeyboardChanged(object sender, KeyboardEventArgs args)
        {
            panelContent.Height = ClientRectangle.Height - args.Bounds.Height;
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
