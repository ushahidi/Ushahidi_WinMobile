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
                    _MapService = new GoogleMapService(MapApiKey);
                    _MapService.MapDownloaded += OnMapDownloaded;
                }
                return _MapService;
            }
        }private MapService _MapService;

        private GoogleGeocodeService GoogleGeocodeService
        {
            get
            {
                if (_GoogleGeocodeService == null)
                {
                    _GoogleGeocodeService = new GoogleGeocodeService(MapApiKey);
                    _GoogleGeocodeService.ReverseGeocoded += OnReverseGeocoded;
                }
                return _GoogleGeocodeService;
            }
        }private GoogleGeocodeService _GoogleGeocodeService;

        /// <summary>
        /// Is the process cancelled?
        /// </summary>
        public bool ShouldSave { get; private set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string MapApiKey { get; set; }
        public bool Satellite { get; set; }

        public double Latitude
        {
            get { return mapBox.Latitude; }
        }

        public double Longitude
        {
            get { return mapBox.Longitude; }
        }

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
                mapBox.ZoomLevel = value;
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
            menuItemMenu.Enabled = false;
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
                WaitCursor.Show();
            }
            else
            {
                Dialog.Warning("detectLocation".Translate(), "notActive".Translate());
                menuItemDetectLocation.Enabled = false;
            }
            menuItemAddIncident.Enabled = false;
        }

        private void OnDetectLocationChanged(object sender, LocationEventArgs args)
        {
            Log.Info("MapView.OnDetectLocationChanged", "");
            
            mapBox.Latitude = args.Latitude;
            mapBox.Longitude = args.Longitude;

            WaitCursor.Show();
            MapService.GetMap(args.Latitude, args.Longitude, mapBox.Width, mapBox.Height, ZoomLevel, Satellite);
        }

        private void OnZoomLevelChanged(object sender, EventArgs e)
        {
            Log.Info("MapView.OnZoomLevelChanged", "");
            WaitCursor.Show();
            mapBox.ZoomLevel = ZoomLevel = Convert.ToInt32(((MenuItem)sender).Text);
            MapService.GetMap(mapBox.Latitude, mapBox.Longitude, mapBox.Width, mapBox.Height, ZoomLevel, Satellite);
        }

        private void OnMapDownloaded(object sender, MapEventArgs args)
        {
            Log.Info("MapView.OnMapDownloaded", "");
            GoogleGeocodeService.ReverseGeocode(mapBox.Latitude, mapBox.Longitude);
            Invoke(new UpdateMapHandler(UpdateMap), args.Image, mapBox.Latitude, mapBox.Longitude);
        }

        private delegate void UpdateMapHandler(Image image, double latitude, double longitude);

        private void UpdateMap(Image image, double latitude, double longitude)
        {
            Log.Info("MapView.UpdateMapAndMarker", "{0}, {1}", latitude, longitude);
            mapBox.Latitude = latitude;
            mapBox.Longitude = longitude;
            mapBox.Image = image;
            menuItemAddIncident.Enabled = true;
            WaitCursor.Hide();
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

        private void OnPlacemarkChanged(double latitude, double longitude)
        {
            Log.Info("MapView.OnPlacemarkChanged");
            WaitCursor.Show();
            MapService.GetMap(latitude, longitude, mapBox.Width, mapBox.Height, mapBox.ZoomLevel, Satellite);
        }

        private void OnReverseGeocoded(string address)
        {
            Log.Info("MapView.OnReverseGeocoded: {0}", address);
            Invoke(new UpdateLocationHandler(UpdateLocation), address);
        }

        private delegate void UpdateLocationHandler(string address);

        private void UpdateLocation(string address)
        {
            textBoxLocationName.Value = address;
        }
    }
}
