using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.WindowsCE.Forms;

namespace Ushahidi.Common.Controls
{
    /// <summary>
    /// InputPanel Keyboard
    /// </summary>
    public static class Keyboard
    {
        private static readonly InputPanel InputPanel = new InputPanel();

        static Keyboard()
        {
            InputPanel.EnabledChanged += OnKeyboardEnabledChanged;
        }

        /// <summary>
        /// The focused control
        /// </summary>
        private static Control FocusedControl;

        /// <summary>
        /// Auto show/hide keyboard?
        /// </summary>
        public static bool AutoShow { get; set; }

        /// <summary>
        /// Change keyboard visibility
        /// </summary>
        public static bool Visible
        {
            get { return InputPanel.Enabled; }
            set { InputPanel.Enabled = value; }
        }

        /// <summary>
        /// Register a control for GotFocus & LostFocus to show/hide keyboard
        /// </summary>
        /// <param name="control">The control to register</param>
        public static void Register(Control control)
        {
            if (control != null && Runtime.IsPocketPC)
            {
                control.GotFocus += OnControlGotFocus;
                control.LostFocus += OnControlLostFocus;
            }
        }

        /// <summary>
        /// GotFocus
        /// </summary>
        private static void OnControlGotFocus(object sender, EventArgs e)
        {
            if (AutoShow)
            {
                FocusedControl = sender as Control;
                Visible = true;
            }
        }

        /// <summary>
        /// LostFocus
        /// </summary>
        private static void OnControlLostFocus(object sender, EventArgs e)
        {
            if (AutoShow)
            {
                FocusedControl = null;
                Visible = false;
            }
        }

        /// <summary>
        /// KeyboardInputPanel EnabledChanged
        /// </summary>
        private static void OnKeyboardEnabledChanged(object sender, EventArgs e)
        {
            if (_KeyboardChanged != null)
            {
                _KeyboardChanged(InputPanel, new KeyboardEventArgs(Visible, Bounds, FocusedControl));
            }
        }

        /// <summary>
        /// The keyboard bounds
        /// </summary>
        public static Rectangle Bounds
        {
            get { return InputPanel.Enabled ? InputPanel.Bounds : Rectangle.Empty; }
        }

        /// <summary>
        /// The keyboard changed handler delegate
        /// </summary>
        public delegate void KeyboardChangedHandler(object sender, KeyboardEventArgs args);

        /// <summary>
        /// The keyboard changed event
        /// </summary>
        public static event KeyboardChangedHandler KeyboardChanged
        {
            add { _KeyboardChanged += value; }
            remove { _KeyboardChanged -= value; }
        }private static event KeyboardChangedHandler _KeyboardChanged;

        /// <summary>
        /// Dispose of keyboard
        /// </summary>
        public static void Dispose()
        {
            if (InputPanel != null)
            {
                InputPanel.Enabled = false;
            }
        }
    }
    /// <summary>
    /// The keyboard changed event args
    /// </summary>
    public class KeyboardEventArgs : EventArgs
    {
        public KeyboardEventArgs(bool visible, Rectangle bounds, Control control)
        {
            Visible = visible;
            Bounds = bounds;
            Control = control;
        }

        /// <summary>
        /// Is the keyboard visible?
        /// </summary>
        public bool Visible { get; private set; }

        /// <summary>
        /// The area of keyboard
        /// </summary>
        public Rectangle Bounds { get; private set; }

        /// <summary>
        /// The focussed control
        /// </summary>
        public Control Control { get; private set; }
    }
}
