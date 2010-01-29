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

        /// <summary>
        /// Latitude
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Zoom Level
        /// </summary>
        public int Zoom { get; set; }

        /// <summary>
        /// Is the map loading?
        /// </summary>
        public bool Loading { get; set; }

        /// <summary>
        /// Map Image
        /// </summary>
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
                if (value != null)
                {
                    MarkerX = CenterX;
                    MarkerY = CenterY;
                }
                _Image = value;
                Invalidate();
                Loading = (value == null);
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
            CenterX = Width / 2;
            CenterY = Height / 2;
            //mProc = new WndProcDelegate(WndProc);
            //mOldWndProc = SetWindowLong(Handle, GWL_WNDPROC, Marshal.GetFunctionPointerForDelegate(mProc));

            //RegisterHotKey(Handle, KeyIDs.VolumeUp, KeyModifiers.None, VirtualKeys.VolumeUp);
            //RegisterHotKey(Handle, KeyIDs.VolumeDown, KeyModifiers.None, VirtualKeys.VolumeDown);
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
                try
                {
                    Color transparencyColor = Color.Transparent;
                    ImageAttributes imageAttributes = new ImageAttributes();
                    imageAttributes.SetColorKey(transparencyColor, transparencyColor);

                    int markerX = MarkerX - imageList.ImageSize.Width / 2;
                    int markerY = MarkerY - imageList.ImageSize.Height;

                    Rectangle rectangle = new Rectangle(markerX, markerY, imageList.ImageSize.Width, imageList.ImageSize.Height);
                    e.Graphics.DrawImage(imageList.Images[0], rectangle, 0, 0, imageList.ImageSize.Width, imageList.ImageSize.Height, GraphicsUnit.Pixel, imageAttributes);
                }
                catch
                {
                    //do nothing                   
                }
            }
            if (Focused)
            {
                e.Graphics.DrawRectangle(Border,
                                        (int)(Border.Width / 2),
                                        (int)(Border.Width / 2),
                                        (int)(ClientRectangle.Width - Border.Width - (Border.Width / 2)),
                                        (int)(ClientRectangle.Height - Border.Width - (Border.Width / 2)));
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (Loading) return;

            Latitude = YToLatitude(LatitudeToY(Latitude) + ((e.Y - CenterY) << (_MaxZoomLevel - Zoom)));
            Longitude = XToLongitude(LongitudeToX(Longitude) + ((e.X - CenterX) << (_MaxZoomLevel - Zoom)));

            MarkerX = e.X;
            MarkerY = e.Y;

            Invalidate();

            if (MarkerChanged != null)
            {
                Loading = true;
                MarkerChanged(Latitude, Longitude);
            }
            base.OnMouseDown(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (Loading)
            {
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Escape || e.KeyCode == Keys.Back || e.KeyCode == Keys.Cancel)
            {
                e.Handled = true;
                Parent.SelectNextControl(this, true, true, true, true);
            }
            else if (e.KeyCode == Keys.Left)
            {
                MarkerX -= DISTANCE_DELTA;
                Invalidate();
                if (MarkerX <= imageList.ImageSize.Width / 2)
                {
                    Log.Info("Left Edge");
                    if (ReCalculate() && MarkerChanged != null)
                    {
                        Loading = true;
                        MarkerChanged(Latitude, Longitude);
                    }
                }
            }
            else if (e.KeyCode == Keys.Right)
            {
                MarkerX += DISTANCE_DELTA;
                Invalidate();
                if (MarkerX >= Width - (imageList.ImageSize.Width / 2))
                {
                    Log.Info("Right Edge");
                    if (ReCalculate() && MarkerChanged != null)
                    {
                        Loading = true;
                        MarkerChanged(Latitude, Longitude);
                    }
                }
            }
            else if (e.KeyCode == Keys.Up)
            {
                MarkerY -= DISTANCE_DELTA;
                Invalidate();
                if (MarkerY <= imageList.ImageSize.Height)
                {
                    Log.Info("Top Edge");
                    if (ReCalculate() && MarkerChanged != null)
                    {
                        Loading = true;
                        MarkerChanged(Latitude, Longitude);
                    }
                }
            }
            else if (e.KeyCode == Keys.Down)
            {
                MarkerY += DISTANCE_DELTA;
                Invalidate();
                if (MarkerY >= Height - 2)
                {
                    Log.Info("Bottom Edge");
                    if (ReCalculate() && MarkerChanged != null)
                    {
                        Loading = true;
                        MarkerChanged(Latitude, Longitude);
                    }
                }
            }
            else if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Enter)
            {
                if (ReCalculate() && MarkerChanged != null)
                {
                    Loading = true;
                    MarkerChanged(Latitude, Longitude);
                }
            }
            else if (e.KeyCode == Keys.F6 || e.KeyCode == Keys.Add)
            {
                Log.Info("MapBox", "ZoomIn");
                if (ZoomIn != null && Latitude != double.MinValue && Longitude != double.MinValue)
                {
                    ZoomIn(this, EventArgs.Empty);
                }
            }
            else if (e.KeyCode == Keys.F7 || e.KeyCode == Keys.Subtract)
            {
                Log.Info("MapBox", "ZoomOut");
                if (ZoomOut != null && Latitude != double.MinValue && Longitude != double.MinValue)
                {
                    ZoomOut(this, EventArgs.Empty);
                }
            }
            else
            {
                if (ReCalculate() && MarkerChanged != null)
                {
                    Loading = true;
                    MarkerChanged(Latitude, Longitude);
                }
                Parent.SelectNextControl(this, true, true, true, true);
                base.OnKeyDown(e);
            }
        }

        /// <summary>
        /// Recalculate Latitude and Longitude
        /// </summary>
        public bool ReCalculate()
        {
            Log.Info("MapBox.ReCalculate", "Before Latitude:{0} Longitude:{1}", Latitude, Longitude);
            if (Latitude == double.MinValue) return false;
            if (Longitude == double.MinValue) return false;
            if (MarkerY != CenterY || MarkerX != CenterX)
            {
                Latitude = YToLatitude(LatitudeToY(Latitude) + ((MarkerY - CenterY) << (_MaxZoomLevel - Zoom)));
                Longitude = XToLongitude(LongitudeToX(Longitude) + ((MarkerX - CenterX) << (_MaxZoomLevel - Zoom)));
                Log.Info("MapBox.ReCalculate", "After Latitude:{0} Longitude:{1}", Latitude, Longitude);
                return true;
            }
            return false;
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
            Log.Info("MapBox.OnResize", "CenterX:{0} CenterY:{1}", CenterX, CenterY);
        }

        private void OnGotFocus(object sender, EventArgs e)
        {
            Log.Info("MapBox.OnGotFocus");
            Invalidate();

            //OverrideKey(VK_TVOLUMEUP, false);
            //OverrideKey(VK_TVOLUMEDOWN, false);

            //_MapMessageWindow = new MapMessageWindow(this);

            //Subclass(hWindow, messageWindow.Hwnd);

            //UnregisterFunc1(KeyModifiers.None, VirtualKeys.VolumeUp);
            //UnregisterFunc1(KeyModifiers.None, VirtualKeys.VolumeDown);

            //RegisterHotKey(MyMsgWindow.Hwnd, KeyIDs.VolumeUp, KeyModifiers.None, VirtualKeys.VolumeUp);
            //RegisterHotKey(MyMsgWindow.Hwnd, KeyIDs.VolumeDown, KeyModifiers.None, VirtualKeys.VolumeDown);

            //IntPtr handle = SHFindMenuBar(Handle);
            //Message volumeUpMessage = Message.Create(handle, SHCMBM_OVERRIDEKEY, (IntPtr)3, MakeLParam((SHMBOF_NODEFAULT | SHMBOF_NOTIFY), (SHMBOF_NODEFAULT | SHMBOF_NOTIFY)));
            //MessageWindow.SendMessage(ref volumeUpMessage);

            //Message volumeDownMessage = Message.Create(handle, SHCMBM_OVERRIDEKEY, (IntPtr)4, MakeLParam((SHMBOF_NODEFAULT | SHMBOF_NOTIFY), (SHMBOF_NODEFAULT | SHMBOF_NOTIFY)));
            //MessageWindow.SendMessage(ref volumeDownMessage);
        }

        private void OnLostFocus(object sender, EventArgs e)
        {
            Log.Info("MapBox.OnLostFocus");
            Invalidate();

            //OverrideKey(VK_TVOLUMEUP, true);
            //OverrideKey(VK_TVOLUMEDOWN, true);

            //_MapMessageWindow.Dispose();
            //_MapMessageWindow = null;

            //Unsubclass(hWindow);

            //UnregisterHotKey(MyMsgWindow.Hwnd, KeyIDs.VolumeUp);
            //UnregisterHotKey(MyMsgWindow.Hwnd, KeyIDs.VolumeDown);

            //IntPtr handle = SHFindMenuBar(Parent.Handle);s
            //Message volumeUpMessage = Message.Create(handle, SHCMBM_OVERRIDEKEY, (IntPtr)3, MakeLParam(0, (SHMBOF_NODEFAULT | SHMBOF_NOTIFY)));
            //MessageWindow.SendMessage(ref volumeUpMessage);

            //Message volumeDownMessage = Message.Create(handle, SHCMBM_OVERRIDEKEY, (IntPtr)4, MakeLParam(0, (SHMBOF_NODEFAULT | SHMBOF_NOTIFY)));
            //MessageWindow.SendMessage(ref volumeDownMessage);
        }

        /// <summary>
        /// Zoom In Event
        /// </summary>
        public event EventHandler ZoomIn;

        /// <summary>
        /// Zoom Out Event
        /// </summary>
        public event EventHandler ZoomOut;

        /// <summary>
        /// Fire Zoom In Event
        /// </summary>
        internal void OnZoomIn()
        {
            Log.Info("MapBox", "OnZoomIn");
            if (ZoomIn != null && Latitude != double.MinValue && Longitude != double.MinValue)
            {
                ZoomIn(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Fire Zoom Out Event
        /// </summary>
        internal void OnZoomOut()
        {
            Log.Info("MapBox", "OnZoomOut");
            if (ZoomOut != null && Latitude != double.MinValue && Longitude != double.MinValue)
            {
                ZoomOut(this, EventArgs.Empty);
            }
        }

        //private MapMessageWindow MapMsgWindow
        //{
        //    get
        //    {
        //        if (_MapMsgWindow == null)
        //        {
        //            _MapMsgWindow = new MapMessageWindow(this);
        //        }
        //        return _MapMsgWindow;
        //    }
        //}private MapMessageWindow _MapMsgWindow;
        //private MapMessageWindow _MapMessageWindow;

        //protected virtual int WndProc(IntPtr hwnd, uint msg, uint wParam, int lParam)
        //{
        //    Log.Info("MapBox.WndProc");
        //    switch (lParam)
        //    {
        //        case VK_TVOLUMEUP:
        //            Log.Info("MapBox.WndProc", "VK_TVOLUMEUP");
        //            OnZoomIn();
        //            break;
        //        case VK_TVOLUMEDOWN:
        //            Log.Info("MapBox.WndProc", "VK_TVOLUMEDOWN");
        //            OnZoomOut();
        //            break;

        //    }
        //    return CallWindowProc(mOldWndProc, Handle, msg, wParam, lParam);
        //}

        //IntPtr mOldWndProc;
        //public const int GWL_WNDPROC = -4;
        //private const int Mode_KeyUP = 0x1000;
        //private const int VK_Back = 27;
        //private const int HOTKEYID = 0xB000;  

        //private void OverrideKey(int wparam, bool restore)
        //{
        //    Log.Info("MapBox.OverrideKey", "wparam:{0} restore:{1}", wparam, restore);
        //    IntPtr handle = SHFindMenuBar(Handle);
        //    IntPtr lparam = restore ? MakeLParam(0, HiWord(SHMBOF_NODEFAULT | SHMBOF_NOTIFY))
        //                            : MakeLParam(LoWord(SHMBOF_NODEFAULT | SHMBOF_NOTIFY), HiWord(SHMBOF_NODEFAULT | SHMBOF_NOTIFY));
        //    Message message = Message.Create(handle, SHCMBM_OVERRIDEKEY,  (IntPtr)wparam, lparam);
        //    MessageWindow.SendMessage(ref message);
        //}

        //protected enum KeyIDs
        //{
        //    VolumeUp = 3,
        //    VolumeDown = 4
        //}

        //protected enum KeyModifiers : uint
        //{
        //    None = 0,
        //    Alt = 1,
        //    Control = 2,
        //    Shift = 4,
        //    Windows = 8
        //}

        //protected enum VirtualKeys
        //{
        //    VolumeUp = 0x75,
        //    VolumeDown = 0x76
        //}

        //[DllImport("native.dll")]
        //private extern static void Subclass(IntPtr subclassWindow, IntPtr messageWindow);

        //[DllImport("native.dll")]
        //private extern static void Unsubclass(IntPtr subclassWindow);

        //[DllImport("coredll.dll")]
        //protected static extern uint RegisterHotKey(IntPtr hWnd, KeyIDs id, KeyModifiers modifiers, VirtualKeys vk);

        //[DllImport("coredll.dll")]
        //private static extern bool UnregisterHotKey(IntPtr hWnd, KeyIDs id);

        //[DllImport("coredll.dll")]
        //protected static extern bool UnregisterFunc1(KeyModifiers modifiers, VirtualKeys id);

        //[DllImport("coredll.dll")]
        //protected static extern short GetAsyncKeyState(int vKey);

        //[DllImport("aygshell")]
        //private extern static IntPtr SHFindMenuBar(IntPtr hwnd);

        //[DllImport("coredll.dll")]
        //private extern static int CallWindowProc(IntPtr lpPrevWndFunc, IntPtr hwnd, uint msg, uint wParam, int lParam);

        //[DllImport("coredll.dll")]
        //public extern static IntPtr SetWindowLong(IntPtr hwnd, int nIndex, IntPtr dwNewLong);

        //private const int VK_TVOLUMEUP = 3;
        //private const int VK_TVOLUMEDOWN = 4;
        //private const int SHCMBM_OVERRIDEKEY = 0x0593;
        //private const int SHMBOF_NODEFAULT = 0x00000001;
        //private const int SHMBOF_NOTIFY = 0x00000002;

        //public static IntPtr MakeLParam(int LoWord, int HiWord)
        //{
        //    return (IntPtr)((HiWord << 16) | (LoWord & 0xffff));
        //}

        //public static int HiWord(int Number)
        //{
        //    return (Number >> 16) & 0xffff;
        //}

        //public static int LoWord(int Number)
        //{
        //    return Number & 0xffff;
        //} 

        ///// <summary>
        ///// Zoom In Event
        ///// </summary>
        //public event EventHandler ZoomIn;

        ///// <summary>
        ///// Zoom Out Event
        ///// </summary>
        //public event EventHandler ZoomOut;

        //WndProcDelegate mProc; 

        //public delegate int WndProcDelegate(IntPtr hwnd, uint msg, uint wParam, int lParam);

        ///// <summary>
        ///// Custom MessageWindow to allow intecepting WndProc call
        ///// </summary>
        //private class MapMessageWindow : MessageWindow
        //{
        //    /// <summary>
        //    /// Volume Up
        //    /// </summary>
        //    private const int VK_TVOLUMEUP = 7667712;

        //    /// <summary>
        //    /// Volume Down
        //    /// </summary>
        //    private const int VK_TVOLUMEDOWN = 7733248;

        //    /// <summary>
        //    /// Map Box Reference
        //    /// </summary>
        //    private readonly MapBox MapBox;
            
        //    /// <summary>
        //    /// Save a reference to the form so it can be notified when messages are received
        //    /// </summary>
        //    /// <param name="mapBox">MapBox</param>
        //    public MapMessageWindow(MapBox mapBox)
        //    {
        //        MapBox = mapBox;
        //    }
            
        //    /// <summary>
        //    /// Override the default WndProc behavior to examine messages.
        //    /// </summary>
        //    protected override void WndProc(ref Message msg)
        //    {
        //        Log.Info("MsgWindow.WndProc", "Msg:{0} LParam:{1}", msg.Msg, (int)msg.LParam);
        //        switch ((int)msg.LParam)
        //        {
        //            case VK_TVOLUMEUP:
        //                Log.Info("MsgWindow.WndProc", "VK_TVOLUMEUP");
        //                MapBox.OnZoomIn();
        //                break;
        //            case VK_TVOLUMEDOWN:
        //                Log.Info("MsgWindow.WndProc", "VK_TVOLUMEDOWN");
        //                MapBox.OnZoomOut();
        //                break;
        //            default:
        //                base.WndProc(ref msg);
        //                break;
        //        }
        //        base.WndProc(ref msg);
        //    }
        //}
    }
}
