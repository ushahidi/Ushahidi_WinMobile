using System;

namespace Ushahidi.Map
{
    /// <summary>
    /// Geolocation
    /// </summary>
    public class Geolocation
    {
        /// <summary>
        /// Offset
        /// </summary>
        private const double _Offset = 268435456;

        /// <summary>
        /// Maximum Zoom Level
        /// </summary>
        private const int _MaxZoomLevel = 21;

        /// <summary>
        /// Radius
        /// </summary>
        private const double _Radius = _Offset / Math.PI;

        /// <summary>
        /// Latitude
        /// </summary>
        public double Latitude
        {
            get { return _Latitude; }
            set { _Latitude = value; }
        }private double _Latitude;

        /// <summary>
        /// Longitude
        /// </summary>
        public double Longitude
        {
            get { return _Longitude; }
            set { _Longitude = value; }
        }private double _Longitude;

        /// <summary>
        /// Geolocation
        /// </summary>
        /// <param name="latitude">latitude</param>
        /// <param name="longitude">longitude</param>
        public Geolocation(double latitude, double longitude)
        {
            _Latitude = latitude;
            _Longitude = longitude;
        }

        public Geolocation(int x, int y, double latitude, double longitude, int zoom)
        {
            _Latitude = YToLatitude(LatitudeToY(latitude) + (y << (_MaxZoomLevel - zoom)));
            _Longitude = XToLongitude(LongitudeToX(longitude) + (x << (_MaxZoomLevel - zoom)));
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}", _Latitude, _Longitude);
        }

        public override int GetHashCode()
        {
            return _Latitude.GetHashCode() + _Longitude.GetHashCode();
        }

        private static double LongitudeToX(double x)
        {
            return Math.Round(_Offset + _Radius * x * Math.PI / 180);
        }

        private static double LatitudeToY(double y)
        {
            return Math.Round(_Offset - _Radius * Math.Log((1 + Math.Sin(y * Math.PI / 180)) / (1 - Math.Sin(y * Math.PI / 180))) / 2);
        }

        private static double XToLongitude(double x)
        {
            return ((Math.Round(x) - _Offset) / _Radius) * 180 / Math.PI;
        }

        private static double YToLatitude(double y)
        {
            return (Math.PI / 2 - 2 * Math.Atan(Math.Exp((Math.Round(y) - _Offset) / _Radius))) * 180 / Math.PI;
        }
    }
}
