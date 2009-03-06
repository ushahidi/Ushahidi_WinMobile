using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Ushahidi.Common.Controls
{
    /// <summary>
    /// Dialog class used to show various MessageBox dialogs
    /// </summary>
    public static class Dialog
    {
        /// <summary>
        /// Info dialog
        /// </summary>
        /// <param name="caption">caption</param>
        /// <param name="text">text</param>
        /// <returns>DialogResult</returns>
        public static bool Info(string caption, string text)
        {
            return DialogResult.OK == MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// Info dialog
        /// </summary>
        /// <param name="caption">caption</param>
        /// <param name="textFormat">text</param>
        /// <param name="args">parameter values</param>
        /// <returns>DialogResult</returns>
        public static bool Info(string caption, string textFormat, params string[] args)
        {
            return Info(caption, string.Format(textFormat, args));
        }

        /// <summary>
        /// Error dialog
        /// </summary>
        /// <param name="caption">caption</param>
        /// <param name="text">text format</param>
        /// <returns>DialogResult</returns>
        public static bool Error(string caption, string text)
        {
            return Error(caption, text, null as Exception);
        }

        /// <summary>
        /// Error dialog
        /// </summary>
        /// <param name="caption">caption</param>
        /// <param name="textFormat">text format</param>
        /// <param name="args">parameter values</param>
        /// <returns>DialogResult</returns>
        public static bool Error(string caption, string textFormat, params string[] args)
        {
            return Error(caption, string.Format(textFormat, args));
        }

        /// <summary>
        /// Error dialog
        /// </summary>
        /// <param name="caption">caption</param>
        /// <param name="text">text</param>
        /// <param name="exception">parameter values</param>
        /// <returns>DialogResult</returns>
        public static bool Error(string caption, string text, Exception exception)
        {
            Debug.WriteLine(text, caption);
            Debug.WriteLine(exception);
            return DialogResult.OK == MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// Question dialog
        /// </summary>
        /// <param name="caption">caption</param>
        /// <param name="text">text</param>
        /// <returns>DialogResult</returns>
        public static bool Question(string caption, string text)
        {
            return DialogResult.Yes == MessageBox.Show(text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// Question dialog
        /// </summary>
        /// <param name="caption">caption</param>
        /// <param name="textFormat">text format</param>
        /// <param name="args">parameter values</param>
        /// <returns>DialogResult</returns>
        public static bool Question(string caption, string textFormat, params string[] args)
        {
            return Question(caption, string.Format(textFormat, args));
        }

        /// <summary>
        /// Error dialog
        /// </summary>
        /// <param name="caption">caption</param>
        /// <param name="text">text</param>
        /// <returns>DialogResult</returns>
        public static bool Warning(string caption, string text)
        {
            return DialogResult.OK == MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// Warning dialog
        /// </summary>
        /// <param name="caption">caption</param>
        /// <param name="textFormat">text format</param>
        /// <param name="args">parameter values</param>
        /// <returns>DialogResult</returns>
        public static bool Warning(string caption, string textFormat, params string[] args)
        {
            return Warning(caption, string.Format(textFormat, args));
        }

        /// <summary>
        /// Help dialog
        /// </summary>
        /// <param name="caption">caption</param>
        /// <param name="text">text</param>
        /// <returns>DialogResult</returns>
        public static bool Help(string caption, string text)
        {
            return DialogResult.OK == MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// Help dialog
        /// </summary>
        /// <param name="caption">caption</param>
        /// <param name="textFormat">text</param>
        /// <param name="args">parameter values</param>
        /// <returns>DialogResult</returns>
        public static bool Help(string caption, string textFormat, params string[] args)
        {
            return Info(caption, string.Format(textFormat, args));
        }
    }
}
