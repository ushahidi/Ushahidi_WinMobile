using System;
using System.Drawing.Imaging;
using System.Drawing;
using System.Windows.Forms;
using Ushahidi.Common.Logging;

namespace Ushahidi.Common.Controls
{
    /// <summary>
    /// MapBox
    /// </summary>
    public partial class MapBox : UserControl
    {
        public delegate void MarkerChangedHandler(double latitude, double longitude);
        public event MarkerChangedHandler MarkerChanged;

        private const int DISTANCE_DELTA = 5;

        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int ZoomLevel { get; set; }
        
        public Image Image
        {
            get { return _Image; }
            set
            {
                if (_Image != null)
                {
                    _Image.Dispose();
                    _Image = null;
                }
                _Image = value;
                MarkerX = CenterX;
                MarkerY = CenterY;
                Invalidate();
            }
        }private Image _Image;

        private int MarkerX = int.MinValue;
        private int MarkerY = int.MinValue;

        private int CenterX = int.MinValue;
        private int CenterY = int.MinValue;

        private readonly Pen Border = new Pen(Color.Black, 2);
        private readonly Brush Fill = new SolidBrush(Color.Gainsboro);

        public MapBox()
        {
            InitializeComponent();
        }

        public void UpdateMap(Image image, double latitude, double longitude)
        {
            Image = image;
            Latitude = latitude;
            Longitude = longitude;
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (Image != null)
            {
                e.Graphics.DrawImage(Image, ClientRectangle, new Rectangle(0, 0, Image.Width, Image.Height), GraphicsUnit.Pixel);
            }
            else
            {
                e.Graphics.FillRectangle(Fill, ClientRectangle);
            }
            if (MarkerX > double.MinValue && MarkerY > double.MinValue)
            {
                Color transparencyColor = Color.Transparent;
                ImageAttributes imageAttributes = new ImageAttributes();
                imageAttributes.SetColorKey(transparencyColor, transparencyColor);

                int markerX = MarkerX - imageList.ImageSize.Width / 2;
                int markerY = MarkerY - imageList.ImageSize.Height;

                Rectangle rectangle = new Rectangle(markerX, markerY, imageList.ImageSize.Width, imageList.ImageSize.Height);
                e.Graphics.DrawImage(imageList.Images[0], rectangle, 0, 0, imageList.ImageSize.Width, imageList.ImageSize.Height, GraphicsUnit.Pixel, imageAttributes);
            }
            if (Focused)
            {
                e.Graphics.DrawRectangle(Border, ClientRectangle);
            }
        }
        
        protected override void OnMouseDown(MouseEventArgs e)
        {
            Latitude = YToLatitude(LatitudeToY(Latitude) + ((e.Y - CenterY) << (_MaxZoomLevel - ZoomLevel)));
            Longitude = XToLongitude(LongitudeToX(Longitude) + ((e.X - CenterX) << (_MaxZoomLevel - ZoomLevel)));

            MarkerX = e.X;
            MarkerY = e.Y;

            Invalidate();

            if (MarkerChanged != null)
            {
                MarkerChanged(Latitude, Longitude); 
            }
            base.OnMouseDown(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            Log.Info("MapBox.OnKeyDown: {0}", e.KeyCode);
            if (e.KeyCode == Keys.Left)
            {
                MarkerX -= DISTANCE_DELTA;
                Invalidate();
            }
            else if (e.KeyCode == Keys.Right)
            {
                MarkerX += DISTANCE_DELTA;
                Invalidate();
            }
            else if (e.KeyCode == Keys.Up)
            {
                MarkerY -= DISTANCE_DELTA;
                Invalidate();
            }
            else if (e.KeyCode == Keys.Down)
            {
                MarkerY += DISTANCE_DELTA;
                Invalidate();
            }
            else if (e.KeyCode == Keys.Return)
            {
                Latitude = YToLatitude(LatitudeToY(Latitude) + ((MarkerY - CenterY) << (_MaxZoomLevel - ZoomLevel)));
                Longitude = XToLongitude(LongitudeToX(Longitude) + ((MarkerX - CenterX) << (_MaxZoomLevel - ZoomLevel)));

                if (MarkerChanged != null)
                {
                    MarkerChanged(Latitude, Longitude);
                }
            }
            else
            {
                base.OnKeyDown(e);
            }
        }

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

        public override string ToString()
        {
            return string.Format("{0}, {1}", Latitude, Longitude);
        }

        private void OnResize(object sender, EventArgs e)
        {
            CenterX = Width / 2;
            CenterY = Height / 2;
        }

    }
}
