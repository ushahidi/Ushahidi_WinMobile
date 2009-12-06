using System;
using System.Windows.Forms;
using Microsoft.WindowsMobile.Samples.Location;
using Ushahidi.Common.Logging;

namespace Ushahidi.Map
{
    /// <summary>
    /// Location Service
    /// </summary>
    public class LocationService : IDisposable
    {
        public delegate void LocationEventHandler(object sender, LocationEventArgs args);

        public delegate void StateEventHandler(object sender, StateEventArgs args);

        /// <summary>
        /// Location Changed Event Handler
        /// </summary>
        public event LocationEventHandler LocationChanged;

        /// <summary>
        /// State Changed Event Handler
        /// </summary>
        public event StateEventHandler StateChanged;

        /// <summary>
        /// GPS
        /// </summary>
        private Gps Gps
        {
            get
            {
                if (_Gps == null)
                {
                    _Gps = new Gps();
                    _Gps.LocationChanged += OnLocationChanged;
                    _Gps.DeviceStateChanged += OnDeviceStateChanged;
                }
                return _Gps;
            }
        }private Gps _Gps;

        protected Timer Timer
        {
            get
            {
                if (_Timer == null)
                {
                    _Timer = new Timer
                    {
                        Interval = 60*1000
                    };
                    _Timer.Tick += OnTimeOut;
                }
                return _Timer;
            }
        }private Timer _Timer;

        /// <summary>
        /// De-constructor
        /// </summary>
        ~LocationService()
        {
            if (_Gps != null && _Gps.Opened)
            {
                _Gps.Close();
            }
            _Gps = null;
        }

        /// <summary>
        /// Start Location Service
        /// </summary>
        /// <returns>true, if successful</returns>
        public bool Start()
        {
            Log.Info("LocationService.Start");
            try
            {
                if (Gps.Opened == false)
                {
                    Gps.Open();
                    Timer.Enabled = true;
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.Exception("LocationService.Start", "Exception: {0}", ex);
                return false;
            }
        }

        /// <summary>
        /// Stop Location Service
        /// </summary>
        public void Stop()
        {
            Log.Info("LocationService.Stop");
            if (Gps != null && Gps.Opened)
            {
                Gps.Close();
            }
        }

        private void OnTimeOut(object sender, EventArgs e)
        {
            Log.Info("LocationService.Timeout");
            Timer.Enabled = false;
            Stop();
            if (LocationChanged != null)
            {
                LocationChanged(this, new LocationEventArgs(0, 0, string.Empty, false, false));
            }
        }

        private void OnLocationChanged(object sender, LocationChangedEventArgs args)
        {
            Log.Info("LocationService.OnLocationChanged", "lat={0} long={1}", args.Position.Latitude, args.Position.Longitude);
            Timer.Enabled = false;
            if (LocationChanged != null)
            {
                LocationChanged(this, new LocationEventArgs(args.Position.Latitude,
                                                            args.Position.Longitude,
                                                            string.Empty,
                                                            args.Position.LatitudeValid,
                                                            args.Position.LongitudeValid));
            }
        }

        private void OnDeviceStateChanged(object sender, DeviceStateChangedEventArgs args)
        {
            Log.Info("LocationService.OnDeviceStateChanged", "FriendlyName={0}", args.DeviceState.FriendlyName);
            if (StateChanged != null)
            {
                StateChanged(this, new StateEventArgs(args.DeviceState.FriendlyName, 
                                                       args.DeviceState.DeviceState.ToString(),
                                                       args.DeviceState.ServiceState.ToString()));
            }
        }

        /// <summary>
        /// Close GPS Connection
        /// </summary>
        public void Dispose()
        {
            if (_Gps != null && _Gps.Opened)
            {
                _Gps.Close();
            }
            _Gps = null;
        }
    }
}
