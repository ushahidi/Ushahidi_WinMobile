using System;
using System.Net;
using Microsoft.WindowsMobile.Samples.Location;
using Ushahidi.Common.Logging;
using Ushahidi.Map.Token.Staging;
using Ushahidi.Map.Geocode.Staging;
using Ushahidi.Map.MapPoint.Staging;

namespace Ushahidi.Map
{
    public class Locator
    {
        public delegate void LocationEventHandler(object sender, LocationEventArgs args);

        public delegate void StateEventHandler(object sender, StateEventArgs args);

        public event LocationEventHandler LocationChanged;

        public event StateEventHandler StateChanged;

        private readonly Gps Gps = new Gps();

        public Locator()
        {
            Gps.LocationChanged += OnLocationChanged;
            Gps.DeviceStateChanged += OnDeviceStateChanged;
        }

        ~Locator()
        {
            if (Gps != null && Gps.Opened)
            {
                Gps.Close();
            }  
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

        private static string GetToken()
        {
            Log.Info("Locator.GetToken");
            try
            {
                CommonService commonService = new CommonService
                {
                    //TODO store these credentials in more secure location
                    Credentials = new NetworkCredential("147513", "zSM4v0k-kwyNd")
                };
                Token.Staging.TokenSpecification tokenSpecification = new Token.Staging.TokenSpecification
                {
                    ClientIPAddress = "127.0.0.1",
                    TokenValidityDurationMinutes = 15
                };
                return commonService.GetClientToken(tokenSpecification);
            }
            catch (Exception ex)
            {
                Log.Exception("Locator.GetToken", "Exception: {0}", ex);
            }
            return null;
        }

        private void OnLocationChanged(object sender, LocationChangedEventArgs args)
        {
            Log.Info("Locator.OnLocationChanged", "lat={0} long={1}", args.Position.Latitude, args.Position.Longitude);
            string requestToken = GetToken();
            string locationAddress = string.Empty;
            if (requestToken != null)
            {
                Log.Info("VitualEarth Token", requestToken);
                try
                {
                    ReverseGeocodeRequest reverseGeocodeRequest = new ReverseGeocodeRequest
                    {
                        Credentials = new Credentials { Token = requestToken },
                        Location = new Geocode.Staging.Location
                        {
                            Latitude = args.Position.Latitude,
                            Longitude = args.Position.Longitude,
                            LatitudeSpecified = true,
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

    }
}
