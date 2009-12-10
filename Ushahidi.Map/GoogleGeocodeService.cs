using System;
using System.Collections.Generic;
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
                request.KeepAlive = false;
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    using (Stream dataStream = response.GetResponseStream())
                    {
                        XmlDocument document = new XmlDocument();
                        document.Load(dataStream);
                        
                        GeocodeEventArgs geocodeEventArgs = new GeocodeEventArgs
                        {
                            Address = GetElementByTagName(document, "address"),
                            Administrative = GetElementByTagName(document, "AdministrativeAreaName"),
                            SubAdministrative = GetElementByTagName(document, "SubAdministrativeAreaName"),
                            Locality = GetElementByTagName(document, "LocalityName"),
                            Thoroughfare = GetElementByTagName(document, "ThoroughfareName"),
                            PostalCode = GetElementByTagName(document, "PostalCodeNumber"),
                            Country = GetElementByTagName(document, "CountryNameCode")
                        };

                        if (ReverseGeocoded != null)
                        {
                            ReverseGeocoded(this, geocodeEventArgs);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Exception("GoogleGeocodeService.ReverseGeocodeInternal", "Exception: {0}", ex.Message);
            }
        }

        private static string GetElementByTagName(XmlDocument document, string name)
        {
            foreach (XmlNode node in document.GetElementsByTagName(name))
            {
                return node.InnerText;
            }
            return null;
        }

        public delegate void ReverseGeocodedHandler(object sender, GeocodeEventArgs args);

        public event ReverseGeocodedHandler ReverseGeocoded;

        
    }

    public class GeocodeEventArgs : EventArgs
    {
        /// <summary>
        /// address
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// AdministrativeAreaName
        /// </summary>
        public string Administrative { get; set; }

        /// <summary>
        /// SubAdministrativeAreaName
        /// </summary>
        public string SubAdministrative { get; set; }

        /// <summary>
        /// LocalityName
        /// </summary>
        public string Locality { get; set; }

        /// <summary>
        /// ThoroughfareName
        /// </summary>
        public string Thoroughfare { get; set; }

        /// <summary>
        /// PostalCodeNumber
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        /// CountryNameCode
        /// </summary>
        public string Country { get; set; }

        public override string ToString()
        {
            List<string> items = new List<string>(new[] { Locality, SubAdministrative, Administrative, Country });
            items.RemoveAll(s => string.IsNullOrEmpty(s));
            return string.Join(", ", items.ToArray());
        }
    }
}
