using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Ushahidi.Common.Controls;
using Ushahidi.Common.Logging;
using Ushahidi.Model.Extensions;
using Ushahidi.Map;
using Ushahidi.View.Controls;

namespace Ushahidi.View.Views
{
    /// <summary>
    /// Incident Map View
    /// </summary>
    public partial class MapView : BaseView
    {
        public MapView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Location Service
        /// </summary>
        private LocationService LocationService
        {
            get
            {
                if (_LocationService == null)
                {
                    _LocationService = new LocationService(Username, Password);
                    _LocationService.LocationChanged += OnDetectLocationChanged;
                }
                return _LocationService;
            }
        }private LocationService _LocationService;

        /// <summary>
        /// Map Service
        /// </summary>
        private MapService MapService
        {
            get
            {
                if (_MapService == null)
                {
                    //_MapService = new BingMapService(Username, Password);
                    _MapService = new GoogleMapService(MapApiKey);

                    _MapService.MapDownloaded += OnMapDownloaded;
                }
                return _MapService;
            }
        }private MapService _MapService;

        /// <summary>
        /// Is the process cancelled?
        /// </summary>
        public bool ShouldSave { get; private set; }

        private WaitCursor WaitCursor;

        public string Username { get; set; }
        public string Password { get; set; }
        public string MapApiKey { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        
        public bool Satellite { get; set; }

        public int ZoomLevel
        {
            get { return _ZoomLevel; }
            set
            {
                foreach (MenuItem menuItem in menuItemZoom.MenuItems)
                {
                    menuItem.Click -= OnZoomLevelChanged;
                    menuItem.Checked = Convert.ToInt32(menuItem.Text) == value;
                    menuItem.Click += OnZoomLevelChanged;
                }
                _ZoomLevel = value;
            }
        }private int _ZoomLevel = 1;
        
        public IEnumerable<int> ZoomLevels
        {
            get { return _ZoomLevels; }
            set
            {
                menuItemZoom.MenuItems.Clear();
                foreach (int zoomLevel in value)
                {
                    MenuItem menuItem = new MenuItem
                    {
                        Text = zoomLevel.ToString(),
                        Checked = (zoomLevel == ZoomLevel)
                    };
                    menuItem.Click += OnZoomLevelChanged;
                    menuItemZoom.MenuItems.Add(menuItem);
                }
                _ZoomLevels = value;
            }
        }private IEnumerable<int> _ZoomLevels;

        public string LocationName
        {
            get { return textBoxLocationName.Value; }
            set { textBoxLocationName.Value = value; }
        }

        public override void Initialize()
        {
            base.Initialize();
            textBoxLocationName.BackColor = Colors.Background;
        }

        public override void Translate()
        {
            base.Translate();
            this.Translate("incidentMap");
            menuItemAction.Translate("action");
            menuItemAddLocation.Translate("addLocation");
            menuItemDetectLocation.Translate("detectLocation");
            menuItemZoom.Translate("zoomLevel");
            textBoxLocationName.Translate("locationName");
        }

        public override void Render()
        {
            base.Render();
            menuItemAddIncident.Enabled = false;
            ShouldSave = true;
        }

        public override bool Validate()
        {
            if (ShouldSave)
            {
                if (string.IsNullOrEmpty(LocationName))
                {
                    Dialog.Warning("locationName".Translate(), "missingFieldsVerify".Translate());
                    textBoxLocationName.Focus();
                    return false;
                }
            }
            return true;
        }

        private void OnDetectLocation(object sender, EventArgs e)
        {
            Log.Info("MapView.OnDetectLocation", "");
            if (LocationService.Start())
            {
                menuItemDetectLocation.Enabled = false;
                ProgressPanel.Show(this, "detectingLocation".Translate(), "cancel".Translate(), OnDetectLocationCancelled);
            }
            else
            {
                Dialog.Warning("detectLocation".Translate(), "notActive".Translate());
                menuItemDetectLocation.Enabled = false;
            }
            menuItemAddIncident.Enabled = false;
        }

        private void OnDetectLocationCancelled(object sender, EventArgs e)
        {
            Log.Info("MapView.OnDetectLocationCancelled", "");
            LocationService.Stop();
            ProgressPanel.Hide(this);
            menuItemDetectLocation.Enabled = true;
            if (WaitCursor != null)
            {
                WaitCursor.Dispose();
                WaitCursor = null;
            }
        }

        private void OnDetectLocationChanged(object sender, LocationEventArgs args)
        {
            Log.Info("MapView.OnDetectLocationChanged", "");
            ProgressPanel.Hide(this);
            WaitCursor = new WaitCursor();
            Latitude = args.Latitude;
            Longitude = args.Longitude;
            MapService.GetMap(args.Latitude, args.Longitude, pictureBox.Width, pictureBox.Height, ZoomLevel, Satellite);
        }

        private void OnZoomLevelChanged(object sender, EventArgs e)
        {
            Log.Info("MapView.OnZoomLevelChanged", "");
            WaitCursor = new WaitCursor();
            ZoomLevel = Convert.ToInt32(((MenuItem)sender).Text);
            MapService.GetMap(Latitude, Longitude, pictureBox.Width, pictureBox.Height, ZoomLevel, Satellite);
        }

        private void OnMapDownloaded(object sender, MapEventArgs args)
        {
            Log.Info("MapView.OnMapDownloaded", "");
            Invoke(new UpdatePictureBoxHandler(UpdatePictureBox), args.Image);
        }

        private delegate void UpdatePictureBoxHandler(Image image);
        
        private void UpdatePictureBox(Image image)
        {
            if (pictureBox.Image != null)
            {
                pictureBox.Image.Dispose();
                pictureBox.Image = null;
            }
            pictureBox.Image = image;
            menuItemAddIncident.Enabled = true;
            if (WaitCursor != null)
            {
                WaitCursor.Dispose();
                WaitCursor = null;
            }
        }

        private void OnAddLocation(object sender, EventArgs e)
        {
            Log.Info("MapView.OnAddLocation");
            ShouldSave = true;
            OnBack();   
        }

        private void OnCancel(object sender, EventArgs e)
        {
            Log.Info("MapView.OnCancel");
            ShouldSave = false;
            OnBack();
        }
    }
}
