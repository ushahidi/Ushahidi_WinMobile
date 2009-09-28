using System;

namespace Ushahidi.Map
{
    public class LocationEventArgs : EventArgs
    {
        public LocationEventArgs(double latitude, double longitude, string address)
        {
            Latitude = latitude;
            Longitude = longitude;
            Address = address;
            LatitudeValid = true;
            LongitudeValid = true;
        }

        public LocationEventArgs(double latitude, double longitude, string address, bool latitudeValid, bool longitudeValid)
        {
            Latitude = latitude;
            Longitude = longitude;
            Address = address;
            LatitudeValid = latitudeValid;
            LongitudeValid = longitudeValid;
        }

        public string Address { get; private set; }
        public double Latitude { get; private set; }
        public double Longitude { get; private set; }

        public bool LatitudeValid { get; private set; }
        public bool LongitudeValid { get; private set; } 
    }
}
