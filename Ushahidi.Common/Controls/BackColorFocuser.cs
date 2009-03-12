using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Ushahidi.Common.Controls
{
    /// <summary>
    /// Back color focuser
    /// </summary>
    public static class BackColorFocuser
    {
        /// <summary>
        /// Dictionary of initial colors
        /// </summary>
        public static Dictionary<string, Color> InitialBackColors = new Dictionary<string, Color>();

        /// <summary>
        /// Register a control for on focu
        /// </summary>
        /// <param name="control"></param>
        public static void Register(Control control)
        {
            if (control != null)
            {
                control.GotFocus += OnGotFocus;
                control.LostFocus += OnLostFocus;
            }
        }

        /// <summary>
        /// Upon got focus, change background color
        /// </summary>
        private static void OnGotFocus(object sender, EventArgs e)
        {
            Control control = sender as Control;
            if (control != null)
            {
                InitialBackColors[GetControlName(control)] = control.BackColor;
                control.BackColor = Color.LightYellow;
            }
        }

        /// <summary>
        /// Upon lost of focus, reset background color
        /// </summary>
        private static void OnLostFocus(object sender, EventArgs e)
        {
            Control control = sender as Control;
            if (control != null)
            {
                control.BackColor = InitialBackColors[GetControlName(control)];
            }
        }
    
        /// <summary>
        /// Get control name
        /// </summary>
        /// <param name="control">control</param>
        /// <returns>unique control name</returns>
        private static string GetControlName(Control control)
        {
            return (control.Parent != null) 
                ? string.Format("{0}_{1}", control.Parent.Name, control.Name) 
                : control.Name;
        }

    }
}
