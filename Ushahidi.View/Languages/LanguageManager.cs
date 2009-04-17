using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Windows.Forms;
using Ushahidi.Common;
using Ushahidi.Common.Controls;
using Ushahidi.Common.Logging;

namespace Ushahidi.View.Languages
{
    /// <summary>
    /// Language Manager
    /// </summary>
    public static class LanguageManager
    {
        private static readonly ResourceManager ResourceManager = new ResourceManager("Ushahidi.View.Languages.Language", Assembly.GetExecutingAssembly());
        static LanguageManager()
        {
            DirectoryInfo appDirectory = new DirectoryInfo(Runtime.AppDirectory);
            foreach(DirectoryInfo directoryInfo in appDirectory.GetDirectories())
            {
                if (directoryInfo.GetFiles("Ushahidi.resources.dll").Length > 0)
                {
                    Log.Info("LanguageManager", "Culture: {0}", directoryInfo.Name);
                    _Languages.Add(new CultureInfo(directoryInfo.Name));
                }
            }
        }

        /// <summary>
        /// Available Languages
        /// </summary>
        public static IEnumerable<CultureInfo> Languages
        {
            get { return _Languages; }
        }private static readonly BindingList<CultureInfo> _Languages = new BindingList<CultureInfo>();
        
        /// <summary>
        /// Current Language
        /// </summary>
        public static CultureInfo Language
        {
            get
            {
                if (_Language == null)
                {
                    _Language = _Languages.First(c => c.Name == "en-US");
                }
                return _Language;
            }
            set { _Language = value; }
        }private static CultureInfo _Language;

        public static string Translate(this string name)
        {
            string translation = ResourceManager.GetString(name, Language);
            Log.Info("LanguageManager.Translate", "{0} = {1}", name, translation);
            return translation;
        }

        public static string Translate(this Control control)
        {
            string translation = ResourceManager.GetString(control.Name, Language);
            if (string.IsNullOrEmpty(translation) == false)
            {
                control.Text = translation;
                return translation;
            }
            return string.Empty;
        }

        public static string Translate(this LabelTextBox labelTextBox)
        {
            string translation = Translate(labelTextBox.Name);
            if (string.IsNullOrEmpty(translation) == false)
            {
                labelTextBox.Label = translation;
                return translation;
            }
            return string.Empty;
        }

        public static string Translate(this LabelDateBox labelDateBox)
        {
            string translation = Translate(labelDateBox.Name);
            if (string.IsNullOrEmpty(translation) == false)
            {
                labelDateBox.Label = translation;
                return translation;
            }
            return string.Empty;
        }

        public static string Translate(this LabelComboBox labelComboBox)
        {
            string translation = Translate(labelComboBox.Name);
            if (string.IsNullOrEmpty(translation) == false)
            {
                labelComboBox.Label = translation;
                return translation;
            }
            return string.Empty;
        }

        public static string Translate(this Form form, Form instance)
        {
            string translation = Translate(form.Name);
            if (string.IsNullOrEmpty(translation) == false)
            {
                form.Text = translation;
                return translation;
            }
            return string.Empty;
        }

        public static string Translate(this ColumnHeader columnHeader, string name)
        {
            string translation = Translate(name);
            if (string.IsNullOrEmpty(translation) == false)
            {
                columnHeader.Text = translation;
                return translation;
            }
            return string.Empty;
        }

        public static string Translate(this MenuItem menuItem, string name)
        {
            string translation = Translate(name);
            if (string.IsNullOrEmpty(translation) == false)
            {
                menuItem.Text = translation;
                return translation;
            }
            return string.Empty;
        }

        public static string Translate(this MenuItem menuItem, Form form)
        {
            foreach (FieldInfo field in form.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance))
            {
                if (field.GetValue(form) == menuItem)
                {
                    string translation = Translate(field.Name);
                    if (string.IsNullOrEmpty(translation) == false)
                    {
                        menuItem.Text = translation;
                        return translation;
                    }
                }
            }
            return string.Empty;
        }

    }
}
