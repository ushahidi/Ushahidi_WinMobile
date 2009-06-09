using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Ushahidi.Common.Extensions
{
    public static class ControlExtensions
    {
        public static int MaxBottom(this Control.ControlCollection controls)
        {
            return controls.Count > 0 ? controls.All().Max(c => c.Bottom) : 0;
        }

        public static int MaxTabIndex(this Control control)
        {
            return Math.Max(control.TabIndex, control.Controls.Count > 0 ? control.Controls.All().Max(c => c.TabIndex) : 0);
        }

        public static int MaxTabIndex(this Control.ControlCollection controls)
        {

            return controls.Count > 0 ? controls.All().Max(c => c.TabIndex) : 0;
        }

        public static IEnumerable<Control> All(this Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                yield return control;
            }
        }

        public static IEnumerable<Control> Where(this Control.ControlCollection controls, Func<Control, bool> predicate)
        {
            foreach (Control control in controls)
            {
                if (predicate(control))
                {
                    yield return control;
                }
            }
        }

        public static Control FirstOrDefault(this Control.ControlCollection controls, Func<Control, bool> predicate)
        {
            foreach (Control control in controls)
            {
                if (predicate(control))
                {
                    return control;
                }
            }
            return null;
        }

        public static IEnumerable<Control> Children(this Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                foreach (Control grandChild in control.Controls.All())
                    yield return grandChild;

                yield return control;
            }
        }

        public static T GetSelectedValue<T>(this ListView listView)
        {
            if (listView != null && listView.SelectedIndices.Count > 0)
            {
                ListViewItem listViewItem = listView.Items[listView.SelectedIndices[0]];
                return (listViewItem != null && listViewItem.Tag != null) ? (T)listViewItem.Tag : default(T);
            }
            return default(T);
        }

        public static int GetSelectedIndex(this ListView listView)
        {
            if (listView != null && listView.SelectedIndices.Count > 0)
            {
                return listView.SelectedIndices[0];
            }
            return -1;
        }

        public static int GetRequiredHeight(this Control control, Font font, int width, string text)
        {
            if (control != null && string.IsNullOrEmpty(text) == false)
            {
                using (Graphics graphics = control is Label ? control.Parent.CreateGraphics() : control.CreateGraphics())
                {
                    try
                    {
                        RECT bounds = new RECT
                        {
                            left = 0,
                            right = width,
                            top = 0,
                            bottom = 0
                        };
                        bounds.right = width;
                        IntPtr hFont = font.ToHfont();
                        IntPtr hdc = graphics.GetHdc();
                        IntPtr originalObject = SelectObject(hdc, hFont);
                        const int flags = DT_TOP | DT_LEFT | DT_CALCRECT | DT_WORDBREAK;
                        DrawText(hdc, text, text.Length, ref bounds, flags);
                        SelectObject(hdc, originalObject);
                        graphics.ReleaseHdc(hdc);
                        return bounds.bottom - bounds.top;
                    }
                    catch
                    {
                        float rowCount = 1;
                        StringBuilder line = new StringBuilder();
                        foreach (string word in text.Split(' '))
                        {
                            line.Append(word);
                            if (graphics.MeasureString(line.ToString(), font).Width > width)
                            {
                                rowCount++;
                                line.Remove(0, line.Length);
                            }
                            else
                            {
                                line.Append(" ");
                            }
                        }
                        double height = graphics.MeasureString("W", font).Height;
                        return (int)(rowCount * height);
                    }
                }
            }
            return 0;
        }

        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        [DllImport("coredll")]
        private static extern IntPtr SelectObject(IntPtr hdc, IntPtr hObject);

        [DllImport("coredll.dll")]
        private static extern int DrawText(IntPtr hdc, string lpStr, int count, ref RECT lpRect, int format);

        [DllImport("coredll.dll")]
        extern private static IntPtr FindWindowW(string lpClassName, string lpWindowName);

        [DllImport("coredll.dll")]
        extern private static int MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, int bRepaint);

        [DllImport("coredll.dll")]
        extern private static int SetRect(ref RECT lprc, int xLeft, int yTop, int xRight, int yBottom);

        [DllImport("coredll.dll")]
        extern public static int GetWindowRect(IntPtr hWnd, ref RECT lpRect);

        [DllImport("coredll.dll")]
        extern private static int SystemParametersInfo(int uiAction, int uiParam, ref RECT pvParam, int fWinIni);

        private const int DT_TOP = 0x00000000;
        private const int DT_LEFT = 0x00000000;
        private const int DT_WORDBREAK = 0x00000010;
        private const int DT_CALCRECT = 0x00000400;
    }
}
