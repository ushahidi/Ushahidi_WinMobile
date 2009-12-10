using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ushahidi.Common.Controls;
using Ushahidi.Common.Extensions;
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
        /// <summary>
        /// MethodInvoker delegate declaration, since its not currently supported in Compact Framework 
        /// </summary>
        private delegate void MethodInvoker();

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
                    _LocationService = new LocationService();
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

        /// <summary>
        /// Geocode Service
        /// </summary>
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

        /// <summary>
        /// UserName
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// MapApiKey
        /// </summary>
        public string MapApiKey { get; set; }

        /// <summary>
        /// Is Map Satellite view?
        /// </summary>
        public bool Satellite { get; set; }

        /// <summary>
        /// Latitude
        /// </summary>
        public double Latitude
        {
            get { return mapBox.Latitude; }
            set { mapBox.Latitude = value; }
        }

        /// <summary>
        /// Longitude
        /// </summary>
        public double Longitude
        {
            get { return mapBox.Longitude; }
            set { mapBox.Longitude = value; }
        }

        /// <summary>
        /// Maximum Zoom Level
        /// </summary>
        public int MaxZoomLevel { get; set; }

        /// <summary>
        /// ZoomLevel
        /// </summary>
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
        
        /// <summary>
        /// Zoom Levels
        /// </summary>
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

        /// <summary>
        /// Location Name
        /// </summary>
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

        public override void Loaded()
        {
            base.Loaded();
            if (Latitude != double.MinValue && Longitude != double.MinValue)
            {
                //load default locale
                WaitCursor.Show();
                MapService.GetMap(Latitude, Longitude, mapBox.Width, mapBox.Height, ZoomLevel, Satellite);
            }
        }

        public override void Translate()
        {
            base.Translate();
            this.Translate("incidentMap");
            menuItemAction.Translate("action");
            menuItemSelectLocation.Translate("selectLocation");
            menuItemDetectLocation.Translate("detectLocation");
            menuItemZoom.Translate("zoomLevel");
            textBoxLocationName.Translate("locationName");
        }

        public override void Render()
        {
            base.Render();
            menuItemAction.Enabled = true;
            menuItemMenu.Enabled = false;
            menuItemSelectLocation.Enabled = Latitude != double.MinValue && Longitude != double.MinValue;
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
                textBoxLocationName.Value = string.Empty;
                mapBox.Focus();
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
            Log.Info("MapView.OnDetectLocationChanged", "Latitude:{0} Longitude:{1} Address:{2}", args.Latitude, args.Longitude, args.Address);
            LocationService.Stop();
            MethodInvoker methodInvoker = delegate
            {
                menuItemDetectLocation.Enabled = true;
                if (args.Latitude.AlmostEquals(0, 0) || args.Longitude.AlmostEquals(0, 0))
                {
                    //invalid latitude and longitude
                    Dialog.Warning("detectingLocation".Translate(), "errorTryAgain".Translate());
                    WaitCursor.Hide();
                }
                else if (args.Latitude == double.MinValue  && args.Longitude == double.MinValue)
                {
                    //invalid latitude and longitude
                    Dialog.Warning("detectingLocation".Translate(), "errorTryAgain".Translate());
                    WaitCursor.Hide();
                }
                else
                {
                    menuItemSelectLocation.Enabled = true;
                    WaitCursor.Show();
                    mapBox.Latitude = args.Latitude;
                    mapBox.Longitude = args.Longitude;
                    MapService.GetMap(args.Latitude, args.Longitude, mapBox.Width, mapBox.Height, ZoomLevel, Satellite);        
                }
            };
            if (InvokeRequired)
            {
                BeginInvoke(methodInvoker);    
            }
            else
            {
                methodInvoker.Invoke();
            }
        }

        private void OnMapDownloaded(object sender, MapEventArgs args)
        {
            Log.Info("MapView.OnMapDownloaded", "Image:{0}", args.Image != null);
            MethodInvoker methodInvoker = delegate
            {
                mapBox.Image = args.Image;
                menuItemAddIncident.Enabled = true;
                menuItemDetectLocation.Enabled = true;
                WaitCursor.Hide();
                if (args.Successful)
                {
                    menuItemSelectLocation.Enabled = true;
                    if (string.IsNullOrEmpty(textBoxLocationName.Value))
                    {
                        WaitCursor.Show();
                        GoogleGeocodeService.ReverseGeocode(mapBox.Latitude, mapBox.Longitude);
                    }
                }
                else
                {
                    Dialog.Error("detectingLocation".Translate(), "errorTryAgain".Translate());
                }
            };
            if (InvokeRequired)
            {
                BeginInvoke(methodInvoker);
            }
            else
            {
                methodInvoker.Invoke();
            }
        }

        private void OnPlacemarkChanged(double latitude, double longitude)
        {
            Log.Info("MapView.OnPlacemarkChanged", "Latitude:{0} Longitude:{1}", latitude, longitude);
            MethodInvoker methodInvoker = delegate
            {
                WaitCursor.Show();
                MapService.GetMap(latitude, longitude, mapBox.Width, mapBox.Height, mapBox.ZoomLevel, Satellite);
            };
            if (InvokeRequired)
            {
                BeginInvoke(methodInvoker);
            }
            else
            {
                methodInvoker.Invoke();
            }
        }

        private void OnReverseGeocoded(object sender, GeocodeEventArgs args)
        {
            Log.Info("MapView.OnReverseGeocoded", "Address:{0}", args.Address);
            MethodInvoker methodInvoker = delegate
            {
                textBoxLocationName.Value = args.ToString();
                WaitCursor.Hide();
            };
            if (InvokeRequired)
            {
                BeginInvoke(methodInvoker);
            }
            else
            {
                methodInvoker.Invoke();
            }
        }

        private void OnZoomLevelChanged(object sender, EventArgs e)
        {
           Log.Info("MapView.OnZoomLevelChanged", "ZoomLevel:{0}", ((MenuItem)sender).Text);
           mapBox.ZoomLevel = ZoomLevel = Convert.ToInt32(((MenuItem)sender).Text);
           WaitCursor.Show();
           MapService.GetMap(mapBox.Latitude, mapBox.Longitude, mapBox.Width, mapBox.Height, mapBox.ZoomLevel, Satellite);
        }

        private void OnSelectLocation(object sender, EventArgs e)
        {
            Log.Info("MapView.OnAddLocation");
            LocationService.Stop();
            ShouldSave = true;
            WaitCursor.Hide();
            mapBox.ReCalculate();
            OnBack(mapBox.Latitude, mapBox.Longitude);   
        }

        private void OnCancel(object sender, EventArgs e)
        {
            Log.Info("MapView.OnCancel");
            LocationService.Stop();
            ShouldSave = false;
            WaitCursor.Hide();
            OnBack(double.MinValue, double.MinValue);
        }

        private void OnZoomIn(object sender, EventArgs e)
        {
            Log.Info("MapView", "OnZoomIn");
            if (ZoomLevel < MaxZoomLevel)
            {
                WaitCursor.Show();
                mapBox.ZoomLevel = ++ZoomLevel;
                MapService.GetMap(mapBox.Latitude, mapBox.Longitude, mapBox.Width, mapBox.Height, ZoomLevel, Satellite);
            }
        }

        private void OnZoomOut(object sender, EventArgs e)
        {
            Log.Info("MapView", "OnZoomOut");
            if (ZoomLevel > 1)
            {
                WaitCursor.Show();
                mapBox.ZoomLevel = --ZoomLevel;
                MapService.GetMap(mapBox.Latitude, mapBox.Longitude, mapBox.Width, mapBox.Height, ZoomLevel, Satellite);    
            }
        }
    }
}
