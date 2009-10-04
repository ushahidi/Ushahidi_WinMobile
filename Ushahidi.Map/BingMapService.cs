using System;
using System.Drawing;
using System.IO;
using System.Net;
using Ushahidi.Common.Logging;
using Ushahidi.Map.Imaging.Staging;

namespace Ushahidi.Map
{
    /// <summary>
    /// Bing Map Service
    /// </summary>
    public class BingMapService : MapService
    {
        /// <summary>
        /// Bing Username
        /// </summary>
        protected string Username { get; private set; }

        /// <summary>
        /// Bing Password
        /// </summary>
        protected string Password { get; private set; }

        /// <summary>
        /// Map Changed Event
        /// </summary>
        public override event MapEventHandler MapDownloaded;

        /// <summary>
        /// Bing Map Service
        /// </summary>
        /// <param name="username">Bing username</param>
        /// <param name="password">Bing password</param>
        public BingMapService(string username, string password)
        {
            Username = username;
            Password = password;
        }

        /// <summary>
        /// Get Bing Map Image
        /// </summary>
        protected override void GetMapInternal()
        {
            try
            {
                MapUriOptions mapUriOptions = new MapUriOptions
                {
                    Style = Satellite ? MapStyle.AerialWithLabels : MapStyle.Road,
                    StyleSpecified = true,
                    ZoomLevel = Zoom,
                    ZoomLevelSpecified = true,
                    ImageType = ImageType.Jpeg,
                    ImageTypeSpecified = true,
                    ImageSize = new SizeOfint
                    {
                        Width = Width,
                        WidthSpecified = true,
                        Height = Height,
                        HeightSpecified = true
                    }
                };
                MapUriRequest mapUriRequest = new MapUriRequest
                {
                    Credentials = new Credentials
                    {
                        Token = TokenService.GetToken(Username, Password)
                    },
                    Center = new Location
                    {
                        Latitude = Latitude,
                        LatitudeSpecified = true,
                        Longitude = Longitude,
                        LongitudeSpecified = true
                    },
                    Options = mapUriOptions
                };
                using (ImageryService imageryService = new ImageryService())
                {
                    MapUriResponse mapUriResponse = imageryService.GetMapUri(mapUriRequest);
                    Log.Info("MapService.GetMap", "URL: {0}", mapUriResponse.Uri);

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(mapUriResponse.Uri);
                    request.Credentials = new NetworkCredential(Username, Password);
                    request.AllowAutoRedirect = true;
                    request.ReadWriteTimeout = 5000;
                    request.Method = "GET";
                    request.Timeout = 5000;
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        using (Stream stream = response.GetResponseStream())
                        {
                            if (MapDownloaded != null)
                            {
                                MapDownloaded(this, new MapEventArgs(new Bitmap(stream), true));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Exception("MapService.GetMap", "Exception: {0}", ex.Message);
                if (MapDownloaded != null)
                {
                    MapDownloaded(this, new MapEventArgs(null, false));
                }
            }
        }
    }
}
