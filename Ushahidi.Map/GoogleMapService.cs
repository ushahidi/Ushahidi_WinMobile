using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using Ushahidi.Common.Logging;

namespace Ushahidi.Map
{
    /// <summary>
    /// Google Map Service
    /// </summary>
    public class GoogleMapService : MapService
    {
        /// <summary>
        /// Google Map API Key
        /// </summary>
        protected string MapApiKey { get; private set; }
        
        /// <summary>
        /// Map Changed Event
        /// </summary>
        public override event MapEventHandler MapDownloaded;

        /// <summary>
        /// Google Map Service
        /// </summary>
        /// <param name="mapApiKey">Google Map API Key</param>
        public GoogleMapService(string mapApiKey)
        {
            MapApiKey = mapApiKey;
        }

        /// <summary>
        /// Get Google Map Image
        /// </summary>
        protected override void GetMapInternal()
        {
            try
            {
                StringBuilder url = new StringBuilder("http://maps.google.com/staticmap");
                url.AppendFormat("?center={0},{1}", Latitude, Longitude);
                url.AppendFormat("&zoom={0}", Zoom);
                url.AppendFormat("&format={0}", "jpg");
                url.AppendFormat("&size={0}x{1}", Width, Height);
                url.AppendFormat("&sensor={0}", "false");
                url.AppendFormat("&maptype={0}", Satellite ? "satellite" : "roadmap");
                //url.AppendFormat("&markers={0},{1},{2}", Latitude, Longitude, "red");
                url.AppendFormat("&key={0}", MapApiKey);
                Log.Info("GoogleMapService.GetMapInternal()", "URL: {0}", url);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url.ToString());
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
