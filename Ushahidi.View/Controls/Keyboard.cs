using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.WindowsCE.Forms;

namespace Ushahidi.View.Controls
{
    public static class Keyboard
    {
        private static readonly InputPanel InputPanel = new InputPanel();

        static Keyboard()
        {
            InputPanel.EnabledChanged += Keyboard_EnabledChanged;
        }

        /// <summary>
        /// The focused control
        /// </summary>
        private static Control FocusedControl;

        /// <summary>
        /// Auto show/hide keyboard?
        /// </summary>
        public static bool AutoShowHideKeyboard { get; set; }

        /// <summary>
        /// Change keyboard visibility
        /// </summary>
        public static bool KeyboardVisible
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
            if (control != null)
            {
                control.GotFocus += control_GotFocus;
                control.LostFocus += control_LostFocus;
            }
        }

        /// <summary>
        /// GotFocus
        /// </summary>
        private static void control_GotFocus(object sender, EventArgs e)
        {
            if (AutoShowHideKeyboard)
            {
                FocusedControl = sender as Control;
                KeyboardVisible = true;
            }
        }

        /// <summary>
        /// LostFocus
        /// </summary>
        private static void control_LostFocus(object sender, EventArgs e)
        {
            if (AutoShowHideKeyboard)
            {
                FocusedControl = null;
                KeyboardVisible = false;
            }
        }

        /// <summary>
        /// KeyboardInputPanel EnabledChanged
        /// </summary>
        private static void Keyboard_EnabledChanged(object sender, EventArgs e)
        {
            if (_KeyboardChanged != null)
            {
                _KeyboardChanged(InputPanel, new KeyboardEventArgs(KeyboardVisible, KeyboardBounds, FocusedControl));
            }
        }

        /// <summary>
        /// The keyboard bounds
        /// </summary>
        public static Rectangle KeyboardBounds
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
        public KeyboardEventArgs(bool keyboardVisible, Rectangle bounds, Control focussedControl)
        {
            KeyboardVisible = keyboardVisible;
            KeyboardBounds = bounds;
            FocussedControl = focussedControl;
        }

        /// <summary>
        /// Is the keyboard visible?
        /// </summary>
        public bool KeyboardVisible { get; private set; }

        /// <summary>
        /// The area of keyboard
        /// </summary>
        public Rectangle KeyboardBounds { get; private set; }

        /// <summary>
        /// The focussed control
        /// </summary>
        public Control FocussedControl { get; private set; }
    }
}
