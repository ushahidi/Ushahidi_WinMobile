﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Ushahidi.Common.Extensions
{
    public static class ControlExtensions
    {
        public static IEnumerable<Control> All(this Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                yield return control;
            }
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

        /// <summary>
        /// Get text height
        /// </summary>
        /// <param name="control">control</param>
        /// <param name="font">font</param>
        /// <param name="width">width</param>
        /// <param name="text">text</param>
        /// <returns>Height</returns>
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

        private const int DT_TOP = 0x00000000;
        private const int DT_LEFT = 0x00000000;
        private const int DT_WORDBREAK = 0x00000010;
        private const int DT_CALCRECT = 0x00000400;
    }
}
