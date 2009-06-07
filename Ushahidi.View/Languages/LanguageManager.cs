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
using Ushahidi.Model;

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
            string resourceName = string.Format("{0}.resources.dll", Assembly.GetExecutingAssembly().GetName().Name);
            foreach(DirectoryInfo directoryInfo in appDirectory.GetDirectories().OrderBy(d => d.Name))
            {
                if (directoryInfo.GetFiles(resourceName).Length > 0)
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
                    _Language = _Languages.First(c => c.Name == DataManager.Language);
                }
                return _Language;
            }
            set
            {
                if (value != null)
                {
                    _Language = value;
                }
            }
        }private static CultureInfo _Language;

        public static string Translate(this string name)
        {
            try
            {
                string translation = ResourceManager.GetString(name, Language);
                Log.Info("LanguageManager.Translate", "{0} = {1}", name, translation);
                return translation;
            }
            catch
            {
                return string.Format("{0}", name);
            }
        }

        public static void Translate(this Control control)
        {
            control.Translate(control.Name);
        }

        public static void Translate(this Control control, string name)
        {
            control.Text = Translate(name) ?? control.Text;
        }

        public static void Translate(this LabelCheckBox labelCheckBox, string name, string checkbox)
        {
            labelCheckBox.Text = Translate(name) ?? labelCheckBox.Text;
            labelCheckBox.CheckBox = Translate(checkbox) ?? labelCheckBox.CheckBox;
        }

        public static void Translate(this MenuItem menuItem, string name)
        {
            menuItem.Text = Translate(name) ?? menuItem.Text;
        }

        public static void Translate(this MenuItem menuItem, Form form)
        {
            foreach (FieldInfo field in form.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance))
            {
                if (field.GetValue(form) == menuItem)
                {
                    menuItem.Text = Translate(field.Name) ?? menuItem.Text;
                    return;
                }
            }
        }

    }
}
