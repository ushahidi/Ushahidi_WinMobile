using System;
using System.Drawing;

namespace Ushahidi.Map
{
    public class MapEventArgs : EventArgs
    {
        public MapEventArgs(Image image, bool successful)
        {
            Image = image;
            Successful = successful;
        }

        public Image Image { get; private set; }

        public bool Successful { get; private set; }
    }
}
