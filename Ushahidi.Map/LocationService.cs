using System;
using Microsoft.WindowsMobile.Samples.Location;
using Ushahidi.Common.Logging;
using Ushahidi.Map.Geocode.Staging;
//using Ushahidi.Map.MapPoint.Staging;

namespace Ushahidi.Map
{
    /// <summary>
    /// Location Service
    /// </summary>
    public class LocationService : IDisposable
    {
        public delegate void LocationEventHandler(object sender, LocationEventArgs args);

        public delegate void StateEventHandler(object sender, StateEventArgs args);

        public event LocationEventHandler LocationChanged;

        public event StateEventHandler StateChanged;

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

        protected string Username { get; private set; }

        protected string Password { get; private set; }

        public LocationService(string username, string password)
        {
            Username = username;
            Password = password;
        }

        ~LocationService()
        {
            if (_Gps != null && _Gps.Opened)
            {
                _Gps.Close();
            }
            _Gps = null;
        }

        public bool Start()
        {
            Log.Info("Locator.Start");
            try
            {
                if (Gps.Opened == false)
                {
                    Gps.Open();
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.Exception("Locator.Start", "Exception: {0}", ex);
                return false;
            }
        }

        public void Stop()
        {
            Log.Info("Locator.Stop");
            if (Gps.Opened)
            {
                Gps.Close();
            }
        }

        private void OnLocationChanged(object sender, LocationChangedEventArgs args)
        {
            Log.Info("Locator.OnLocationChanged", "lat={0} long={1}", args.Position.Latitude, args.Position.Longitude);
            string requestToken = TokenService.GetToken(Username, Password);
            string locationAddress = string.Empty;
            if (requestToken != null)
            {
                Log.Info("VitualEarth Token", requestToken);
                try
                {
                    ReverseGeocodeRequest reverseGeocodeRequest = new ReverseGeocodeRequest
                    {
                        Credentials = new Credentials { Token = requestToken },
                        Location = new Location
                        {
                            Latitude = args.Position.Latitude,
                            LatitudeSpecified = true,
                            Longitude = args.Position.Longitude,
                            LongitudeSpecified = true
                        }
                    };
                    using (GeocodeService geocodeService = new GeocodeService())
                    {
                        GeocodeResponse geocodeResponse = geocodeService.ReverseGeocode(reverseGeocodeRequest);
                        if (geocodeResponse.Results.Length > 0)
                        {
                            locationAddress = geocodeResponse.Results[0].DisplayName;
                            Log.Info("Locator.OnLocationChanged", "DisplayName={0}", geocodeResponse.Results[0].DisplayName);
                            Log.Info("Locator.OnLocationChanged", "Address={0}", geocodeResponse.Results[0].Address);
                            Log.Info("Locator.OnLocationChanged", "EntityType={0}", geocodeResponse.Results[0].EntityType);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.Exception("Locator.OnLocationChanged", "Exception: {0}", ex);
                    locationAddress = null;
                }
            }
            else
            {
                Log.Info("VitualEarth Token is NULL");
            }
            if (LocationChanged != null)
            {
                LocationChanged(this, new LocationEventArgs(args.Position.Latitude,
                                                            args.Position.Longitude,
                                                            locationAddress,
                                                            args.Position.LatitudeValid,
                                                            args.Position.LongitudeValid));
            }
        }

        private void OnDeviceStateChanged(object sender, DeviceStateChangedEventArgs args)
        {
            Log.Info("Locator.OnDeviceStateChanged", "FriendlyName={0}", args.DeviceState.FriendlyName);
            if (StateChanged != null)
            {
                StateChanged(this, new StateEventArgs(args.DeviceState.FriendlyName, 
                                                       args.DeviceState.DeviceState.ToString(),
                                                       args.DeviceState.ServiceState.ToString()));
            }
        }

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
