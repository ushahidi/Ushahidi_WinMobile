using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Xml;
using Ushahidi.Common.Logging;

namespace Ushahidi.Map
{
    /// <summary>
    /// Google Geocode Service
    /// </summary>
    public class GoogleGeocodeService
    {
        public string MapApiKey { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
        public string Address { get; private set; }

        public GoogleGeocodeService(string mapApiKey)
        {
            Log.Info("GoogleGeocodeServic", "{0}", mapApiKey);
            MapApiKey = mapApiKey;
        }

        public void ReverseGeocode(double latitude, double longitude)
        {
            Log.Info("GoogleGeocodeService.ReverseGeocode", "{0}, {1}", latitude, longitude);
            Latitude = latitude;
            Longitude = longitude;
            Address = null;
            new Thread(ReverseGeocodeInternal).Start();
        }

        private void ReverseGeocodeInternal()
        {
            try
            {
                StringBuilder url = new StringBuilder("http://maps.google.com/maps/geo?oe=utf-8");
                url.AppendFormat("&output={0}", "xml");
                url.AppendFormat("&key={0}", MapApiKey);
                url.AppendFormat("&ll={0},{1}", Latitude, Longitude);

                Log.Info("GoogleGeocodeService.ReverseGeocodeInternal()", "URL: {0}", url);

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url.ToString());
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream dataStream = response.GetResponseStream())
                    {
                        XmlDocument document = new XmlDocument();
                        document.Load(dataStream);
                        foreach (XmlNode node in document.GetElementsByTagName("address"))
                        {
                            if (ReverseGeocoded != null)
                            {
                                Address = node.InnerText;
                                ReverseGeocoded(node.InnerText);
                            }
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Exception("GoogleGeocodeService.ReverseGeocodeInternal", "Exception: {0}", ex.Message);
            }
        }

        public delegate void ReverseGeocodedHandler(string address);

        public event ReverseGeocodedHandler ReverseGeocoded;
    }
}
