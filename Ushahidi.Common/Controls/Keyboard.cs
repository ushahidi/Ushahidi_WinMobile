using System;
using System.Windows.Forms;

namespace Ushahidi.Common.Controls
{
    /// <summary>
    /// Keyboard Interface
    /// </summary>
    public interface IKeyboard
    {
        bool AutoShow { get; set; }
        bool Visible { get; set; }
        int Height { get; }
        void Register(Control control);
        event KeyboardChangedHandler KeyboardChanged;
    }

    /// <summary>
    /// Empty Keyboard Implementation
    /// </summary>
    public class KeyboardDefault : IKeyboard
    {
        /// <summary>
        /// AutoShow for KeyboardDefault is always false
        /// </summary>
        public bool AutoShow
        {
            get { return false; }
            set { }
        }

        /// <summary>
        /// Visibility for KeyboardDefault is always false
        /// </summary>
        public bool Visible
        {
            get { return false; }
            set { }
        }

        /// <summary>
        /// Height for KeyboardDefault is always 0
        /// </summary>
        public int Height
        {
            get { return 0; }
        }

        public void Register(Control control) { }

        public event KeyboardChangedHandler KeyboardChanged
        {
            add { }
            remove { }
        }
    }

    /// <summary>
    /// PPC Keyboard Implementation
    /// </summary>
    public class KeyboardPPC : IKeyboard
    {
        public KeyboardPPC()
        {
            _InputPanel.EnabledChanged += OnEnabledChanged;
        }

        /// <summary>
        /// Keyboard InputPanel
        /// </summary>
        private readonly Microsoft.WindowsCE.Forms.InputPanel _InputPanel = new Microsoft.WindowsCE.Forms.InputPanel();

        /// <summary>
        /// The focusssed control
        /// </summary>
        protected static Control FocusedControl { get; set; }

        /// <summary>
        /// Is the keyboard visible?
        /// </summary>
        public bool Visible
        {
            get { return _InputPanel.Enabled; }
            set { _InputPanel.Enabled = value; }
        }

        /// <summary>
        /// Should we auto show the keyboard?
        /// </summary>
        public bool AutoShow { get; set; }

        /// <summary>
        /// The height of the keyboard
        /// </summary>
        public int Height
        {
            get { return _InputPanel.Enabled ? _InputPanel.Bounds.Height : 0; }
        }

        /// <summary>
        /// The keyboard changed event
        /// </summary>
        public event KeyboardChangedHandler KeyboardChanged
        {
            add { _KeyboardChanged += value; }
            remove { _KeyboardChanged -= value; }
        }private event KeyboardChangedHandler _KeyboardChanged;

        /// <summary>
        /// Register a control to show keyboard upon focus
        /// </summary>
        /// <param name="control">control to register for keyboard</param>
        public void Register(Control control)
        {
            if (control != null)
            {
                control.GotFocus += OnControlGotFocus;
                control.LostFocus += OnControlLostFocus;
            }
        }

        /// <summary>
        /// OnGotFocus, and AutoShow enabled then show the keyboard
        /// </summary>
        private void OnControlGotFocus(object sender, EventArgs e)
        {
            if (AutoShow)
            {
                FocusedControl = sender as Control;
                Visible = true;
            }
        }

        /// <summary>
        /// OnLostFocus, and AutoShow enabled then hide the keyboard
        /// </summary>
        private void OnControlLostFocus(object sender, EventArgs e)
        {
            if (AutoShow)
            {
                FocusedControl = null;
                Visible = false;
            }
        }

        /// <summary>
        /// On Keyboad manually enabled/visibility changed, fire KeyboardChanged event
        /// </summary>
        private void OnEnabledChanged(object sender, EventArgs e)
        {
            if (_KeyboardChanged != null)
            {
                _KeyboardChanged(this, new KeyboardEventArgs(Visible, Height, FocusedControl));
            }
        }
    }

    /// <summary>
    /// The keyboard changed handler delegate
    /// </summary>
    public delegate void KeyboardChangedHandler(object sender, KeyboardEventArgs args);

    /// <summary>
    /// InputPanel Keyboard
    /// </summary>
    public static class Keyboard
    {
        private static IKeyboard Implementation
        {
            get
            {
                if (_Implementation == null)
                {
                    try
                    {
                        if (Runtime.IsPocketPC)
                        {
                            _Implementation = new KeyboardPPC();
                        }
                        else
                        {
                            _Implementation = new KeyboardDefault();
                        }
                    }
                    catch
                    {
                        _Implementation = new KeyboardDefault();
                    }
                }
                return _Implementation;
            }
        }private static IKeyboard _Implementation;

        /// <summary>
        /// Keyboard Height
        /// </summary>
        public static int Height
        {
            get { return Implementation.Height; }
        }

        /// <summary>
        /// Autoshow Keyboard?
        /// </summary>
        public static bool AutoShow
        {
            get { return Implementation.AutoShow; }
            set { Implementation.AutoShow = value; }
        }

        /// <summary>
        /// Keyboard Visibility
        /// </summary>
        public static bool Visible
        {
            get { return Implementation.Visible; }
            set { Implementation.Visible = value; }
        }

        /// <summary>
        /// Register a control for GotFocus & LostFocus to show/hide keyboard
        /// </summary>
        /// <param name="control">The control to register</param>
        public static void Register(Control control)
        {
            Implementation.Register(control);
        }

        /// <summary>
        /// The keyboard changed event
        /// </summary>
        public static event KeyboardChangedHandler KeyboardChanged
        {
            add { Implementation.KeyboardChanged += value; }
            remove { Implementation.KeyboardChanged -= value; }
        }

        /// <summary>
        /// Dispose of keyboard
        /// </summary>
        public static void Dispose()
        {
            Implementation.Visible = false;
        }
    }
    /// <summary>
    /// The keyboard changed event args
    /// </summary>
    public class KeyboardEventArgs : EventArgs
    {
        public KeyboardEventArgs(bool visible, int height, Control control)
        {
            Visible = visible;
            Height = height;
            Control = control;
        }

        /// <summary>
        /// Keyboard visible?
        /// </summary>
        public bool Visible { get; private set; }

        /// <summary>
        /// Keyboard height
        /// </summary>
        public int Height { get; private set; }

        /// <summary>
        /// The focussed control
        /// </summary>
        public Control Control { get; private set; }
    }
}
