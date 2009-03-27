using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Xml;
using Microsoft.Win32;
using Ushahidi.Common.Logging;
using Ushahidi.Model.Models;
using Ushahidi.Common;

namespace Ushahidi.Model
{
    /// <summary>
    /// Data manager
    /// </summary>
    public class DataManager
    {
        static DataManager()
        {
            Load();
        }

        #region Settings

        /// <summary>
        /// Server
        /// </summary>
        public static string ServerAddress { get; set; }

        /// <summary>
        /// Locale
        /// </summary>
        public static string DefaultLocale { get; set; }

        /// <summary>
        /// Last sync date
        /// </summary>
        public static DateTime LastSyncDate { get; set; }

        /// <summary>
        /// Auto show keyboard?
        /// </summary>
        public static bool ShowKeyboard { get; set; }

        /// <summary>
        /// Data Directory
        /// </summary>
        private static string DataDirectory
        {
            get { return Path.Combine(Runtime.AppDirectory, "Data"); }   
        }

        private const string RegKeyUshahidi = "Ushahidi";
        private const string RegKeyServer = "Server";
        private const string RegKeyLocale = "Locale";
        private const string RegKeyLastSync = "LastSync";
        private const string RegKeyShowKeyboard = "ShowKeyboard";

        /// <summary>
        /// Load
        /// </summary>
        /// <returns>true, if successful</returns>
        public static bool Load()
        {
            Log.Info("DataManager.LoadSettings");
            RegistryKey registryKey = Registry.LocalMachine.CreateSubKey(RegKeyUshahidi);
            if (registryKey != null)
            {
                ServerAddress = registryKey.GetValue(RegKeyServer, "http://demo.ushahidi.com").ToString();
                Log.Info("DataManager.LoadSettings", "ServerAddress:{0}", ServerAddress);

                DefaultLocale = registryKey.GetValue(RegKeyLocale, "").ToString();
                Log.Info("DataManager.LoadSettings", "DefaultLocale:{0}", DefaultLocale);
                
                string lastSyncDate = (string)registryKey.GetValue(RegKeyLastSync, "");
                LastSyncDate = string.IsNullOrEmpty(lastSyncDate) ? DateTime.MinValue : DateTime.Parse(lastSyncDate);
                Log.Info("DataManager.LoadSettings", "LastSyncDate:{0}", LastSyncDate);

                ShowKeyboard = Convert.ToBoolean(registryKey.GetValue(RegKeyShowKeyboard, true));
                Log.Info("DataManager.LoadSettings", "ShowKeyboard:{0}", ShowKeyboard);

                registryKey.Close();
            }
            return true;
        }

        /// <summary>
        /// Save
        /// </summary>
        /// <returns>true, if successful</returns>
        public static bool Save()
        {
            Log.Info("DataManager.SaveSettings");
            RegistryKey registryKey = Registry.LocalMachine.CreateSubKey(RegKeyUshahidi);
            if (registryKey != null)
            {
                registryKey.SetValue(RegKeyServer, ServerAddress);
                registryKey.SetValue(RegKeyLocale, DefaultLocale);
                registryKey.SetValue(RegKeyLastSync, LastSyncDate.ToString());
                registryKey.SetValue(RegKeyShowKeyboard, ShowKeyboard.ToString());
                return true;
            }
            return false;
        }

        #endregion

        #region Categories

        /// <summary>
        /// Has categories cache?
        /// </summary>
        public static bool HasCategories
        {
            get { return File.Exists(CategoriesFilepath); }
        }

        /// <summary>
        /// Category Filepath
        /// </summary>
        private static string CategoriesFilepath
        {
            get { return Path.Combine(DataDirectory, "Categories.xml"); }   
        }

        /// <summary>
        /// Categories URL
        /// </summary>
        private static string CategoriesURL
        {
            get { return string.Format("{0}/api?task=categories&resp=xml", ServerAddress); }   
        }

        /// <summary>
        /// Refresh Categories
        /// </summary>
        /// <returns></returns>
        public static bool RefreshCategories()
        {
            Log.Info("DataManager.DownloadCategories");
             if(DownloadAndSaveXml(CategoriesURL, CategoriesFilepath))
             {
                 _Categories = Categories.Load(CategoriesFilepath);
                 return true;
             }
            return false;
        }

        /// <summary>
        /// Categories
        /// </summary>
        public static Categories Categories
        {
            get
            {
                if (_Categories == null)
                {
                    _Categories = Categories.Load(CategoriesFilepath);
                }
                return _Categories;
            }
        }private static Categories _Categories;

        #endregion

        #region Countries

        /// <summary>
        /// Has countries cache?
        /// </summary>
        public static bool HasCountries
        {
            get { return File.Exists(CountriesFilepath); }
        }

        /// <summary>
        /// Countries Filepath
        /// </summary>
        private static string CountriesFilepath
        {
            get { return Path.Combine(DataDirectory, "Countries.xml"); }   
        }

        /// <summary>
        /// Countries URL
        /// </summary>
        private static string CountriesURL
        {
            get { return string.Format("{0}/api?task=countries&resp=xml", ServerAddress); }
        }

        /// <summary>
        /// Download Categories and file JSON to disk
        /// </summary>
        /// <returns></returns>
        public static bool RefreshCountries()
        {
            Log.Info("DataManager.DownloadCountries");
            if (DownloadAndSaveXml(CountriesURL, CountriesFilepath))
            {
                _Countries = Countries.Load(CategoriesFilepath);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Countries
        /// </summary>
        public static Countries Countries
        {
            get
            {
                if (_Countries == null)
                {
                     _Countries = Countries.Load(CountriesFilepath);
                }
                return _Countries;
            }
        }private static Countries _Countries;

            #endregion

        #region Locales

        /// <summary>
        /// Has locales cache?
        /// </summary>
        public static bool HasLocales
        {
            get { return File.Exists(LocalesFilepath); }
        }

        /// <summary>
        /// Locales Filepath
        /// </summary>
        private static string LocalesFilepath
        {
            get { return Path.Combine(DataDirectory, "Locales.xml"); }
        }

        /// <summary>
        /// Locales URL
        /// </summary>
        private static string LocalesURL
        {
            get { return string.Format("{0}/api?task=locations&resp=xml", ServerAddress); }
        }

        /// <summary>
        /// Download Locales and file JSON to disk
        /// </summary>
        /// <returns></returns>
        public static bool RefreshLocales()
        {
            Log.Info("DataManager.DownloadLocales");
            if (DownloadAndSaveXml(LocalesURL, LocalesFilepath))
            {
                _Locales = Locales.Load(LocalesFilepath);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Locales
        /// </summary>
        public static Locales Locales
        {
            get
            {
                if (_Locales == null)
                {
                    _Locales = Locales.Load(LocalesFilepath);
                }
                return _Locales;
            }
        }private static Locales _Locales;

        #endregion

        #region Incidents

        /// <summary>
        /// Has incidents cache?
        /// </summary>
        public static bool HasIncidents
        {
            get { return File.Exists(IncidentsFilepath); }
        }

        /// <summary>
        /// Incidents Filepath
        /// </summary>
        private static string IncidentsFilepath
        {
            get { return Path.Combine(DataDirectory, "Incidents.xml"); }
        }

        /// <summary>
        /// Incidents URL
        /// </summary>
        private static string IncidentsURL
        {
            get { return string.Format("{0}/api?task=incidents&by=locid&id=1&resp=xml", ServerAddress); }
        }

        /// <summary>
        /// Download Incidents and file JSON to disk
        /// </summary>
        /// <returns></returns>
        public static bool RefreshIncidents()
        {
            Log.Info("DataManager.DownloadIncidents");
            if (DownloadAndSaveXml(IncidentsURL, IncidentsFilepath))
            {
                if (File.Exists(IncidentsFilepath))
                {
                    //_Incidents = Incidents.Load(IncidentsFilepath);
                    //TODO remove this once Incidents XML no longer contains <incident0>, <incident1>, ... elements
                    using (XmlReader reader = XmlReader.Create(IncidentsFilepath))
                    {
                        if (reader.ReadToDescendant("payload"))
                        {
                            string xml = reader.ReadOuterXml();
                            for (int i = 0; i < 10; i++)
                            {
                                xml = xml.Replace(string.Format("<incident{0}>", i), "");
                                xml = xml.Replace(string.Format("</incident{0}>", i), "");
                            }
                            _Incidents = Serializer.Deserialize<Incidents>(xml);
                        }
                    }
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Incidents
        /// </summary>
        public static Incidents Incidents
        {
            get
            {
                if (_Incidents == null)
                {
                    //_Incidents = Incidents.Load(IncidentsFilepath);
                    //TODO remove this once Incidents XML no longer contains <incident0>, <incident1>, ... elements
                    if (File.Exists(IncidentsFilepath))
                    {
                        using (XmlReader reader = XmlReader.Create(IncidentsFilepath))
                        {
                            if (reader.ReadToDescendant("payload"))
                            {
                                string xml = reader.ReadOuterXml();
                                for (int i = 0; i < 10; i++)
                                {
                                    xml = xml.Replace(string.Format("<incident{0}>", i), "");
                                    xml = xml.Replace(string.Format("</incident{0}>", i), "");
                                }
                                _Incidents = Serializer.Deserialize<Incidents>(xml);
                            }
                        }
                    }
                }
                return _Incidents;
            }
        }private static Incidents _Incidents;

        /// <summary>
        /// Add a new incident
        /// </summary>
        /// <param name="incident">incident</param>
        public static bool AddIncident(Incident incident)
        {
            IList<Incident> incidents = new List<Incident>(Incidents.Items) {incident};
            Incidents.Items = incidents.ToArray();
            return true;
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Download XML and write contents to file
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="filepath">output file path</param>
        /// <returns>true, if successful</returns>
        private static bool DownloadAndSaveXml(string url, string filepath)
        {
            Log.Info("DataManager.DownloadJSON", "URL:{0} FilePath:{1}", url, filepath);
            if (File.Exists(filepath))
            {
                Log.Info("DataManager.DownloadJSON", "File Deleted:{0}", filepath);
                File.Delete(filepath);
            }
            if (Directory.Exists(DataDirectory) == false)
            {
                Log.Info("DataManager.DownloadJSON", "Directory Created:{0}", DataDirectory);
                Directory.CreateDirectory(DataDirectory);
            }
            using (StreamWriter writer = new StreamWriter(filepath))
            {
                writer.WriteLine(DownloadXml(url));
            }
            return true;
        }

        /// <summary>
        /// Download and return XML from URL
        /// </summary>
        /// <param name="url">url</param>
        /// <returns>XML as string</returns>
        private static string DownloadXml(string url)
        {
            Uri uri = new Uri(url, UriKind.Absolute);
            WebRequest request = WebRequest.Create(uri);
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (Stream dataStream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(dataStream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        #endregion

    }
}
