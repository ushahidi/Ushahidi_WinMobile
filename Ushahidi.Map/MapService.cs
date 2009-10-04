using System;
using System.Threading;

namespace Ushahidi.Map
{
    /// <summary>
    /// Abstract Map Service
    /// </summary>
    public abstract class MapService : IDisposable
    {
        /// <summary>
        /// Map Changed Handler
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="args">MapEventArgs</param>
        public delegate void MapEventHandler(object sender, MapEventArgs args);

        /// <summary>
        /// Map Changed Event
        /// </summary>
        public abstract event MapEventHandler MapDownloaded;

        /// <summary>
        /// Latitude
        /// </summary>
        public double Latitude { get; private set; }

        /// <summary>
        /// Longitude
        /// </summary>
        public double Longitude { get; private set; }

        /// <summary>
        /// Map Width
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        /// Map Height
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// Map Zoom Level
        /// </summary>
        public int Zoom { get; private set; }

        /// <summary>
        /// Map Satellite View?
        /// </summary>
        protected bool Satellite { get; set; }

        /// <summary>
        /// Get Map
        /// </summary>
        /// <param name="latitude">latitude</param>
        /// <param name="longitude">longitude</param>
        /// <param name="width">map width</param>
        /// <param name="height">map height</param>
        /// <param name="zoom">map zoom level</param>
        /// <param name="satellite">map satellite view?</param>
        public void GetMap(double latitude, double longitude, int width, int height, int zoom, bool satellite)
        {
            Latitude = latitude;
            Longitude = longitude;
            Width = width;
            Height = height;
            Zoom = zoom;
            Satellite = satellite;
            new Thread(GetMapInternal).Start();
        }

        /// <summary>
        /// Get Map Implementation
        /// </summary>
        protected abstract void GetMapInternal();

        /// <summary>
        /// Dispose of Resources
        /// </summary>
        public virtual void Dispose()
        {

        }
    }
}
