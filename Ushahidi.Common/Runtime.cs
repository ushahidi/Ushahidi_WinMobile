using System;
using System.IO;
using System.Reflection;
using Microsoft.WindowsCE.Forms;
using Ushahidi.Common.Logging;

namespace Ushahidi.Common
{
    public static class Runtime
    {
        static Runtime()
        {
            OSVersion = Environment.OSVersion.Version.ToString();
            AppVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            ClrVersion = Environment.Version.ToString();
            AppDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName);
            try
            {
                IsSmartPhone = SystemSettings.Platform == WinCEPlatform.Smartphone;
                IsPocketPC = SystemSettings.Platform == WinCEPlatform.PocketPC;
            }
            catch
            {
                IsSmartPhone = false;
                IsPocketPC = false;
            }
            HasPhoneCapability = File.Exists(@"\Windows\Phone.dll");

            Log.Info("Runtime", "OSVersion:{0}", OSVersion);
            Log.Info("Runtime", "AppVersion:{0}", AppVersion);
            Log.Info("Runtime", "ClrVersion:{0}", ClrVersion);
            Log.Info("Runtime", "AppDirectory:{0}", AppDirectory);
            Log.Info("Runtime", "IsSmartPhone:{0}", IsSmartPhone);
            Log.Info("Runtime", "IsPocketPC:{0}", IsPocketPC);
            Log.Info("Runtime", "HasPhoneCapability:{0}", HasPhoneCapability);
        }

        /// <summary>
        /// The application version
        /// </summary>
        public static string AppVersion { get; private set; }

        /// <summary>
        /// The subversion version of the application
        /// </summary>
        public static string ClrVersion { get; private set; }

        /// <summary>
        /// The current operating system version
        /// </summary>
        public static string OSVersion { get; private set; }

        /// <summary>
        /// The application directory
        /// </summary>
        public static string AppDirectory { get; private set; }

        /// <summary>
        /// Is the device a SmartPhone?
        /// </summary>
        public static bool IsSmartPhone { get; private set; }

        /// <summary>
        /// Is the device a PocketPC?
        /// </summary>
        public static bool IsPocketPC { get; private set; }

        /// <summary>
        /// Does the device have phone capabilities?
        /// </summary>
        public static bool HasPhoneCapability { get; private set; }
    }
}
