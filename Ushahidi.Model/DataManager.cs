using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using Microsoft.Win32;
using Ushahidi.Common.Logging;
using Ushahidi.Common.Net;
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
        /// First Name
        /// </summary>
        public static string FirstName { get; set; }

        /// <summary>
        /// Last Name
        /// </summary>
        public static string LastName { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public static string Email { get; set; }

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
        private const string RegKeyFirstName = "FirstName";
        private const string RegKeyLastName = "LastName";
        private const string RegKeyEmail = "Email";
        
        /// <summary>
        /// Load
        /// </summary>
        /// <returns>true, if successful</returns>
        private static void Load()
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

                FirstName = registryKey.GetValue(RegKeyFirstName, "").ToString();
                Log.Info("DataManager.LoadSettings", "FirstName:{0}", FirstName);

                LastName = registryKey.GetValue(RegKeyLastName, "").ToString();
                Log.Info("DataManager.LoadSettings", "LastName:{0}", LastName);

                Email = registryKey.GetValue(RegKeyEmail, "").ToString();
                Log.Info("DataManager.LoadSettings", "Email:{0}", Email);

                registryKey.Close();
            }
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
                registryKey.SetValue(RegKeyFirstName, FirstName);
                registryKey.SetValue(RegKeyLastName, LastName);
                registryKey.SetValue(RegKeyEmail, Email);
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
            Log.Info("DataManager.RefreshCategories");
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
            Log.Info("DataManager.RefreshCountries");
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
            Log.Info("DataManager.RefreshLocales");
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
            get { return string.Format("{0}/api?task=incidents&by=locid&id=3&resp=xml", ServerAddress); }
        }

        /// <summary>
        /// Download Incidents and file JSON to disk
        /// </summary>
        /// <returns>true, if successful</returns>
        public static bool RefreshIncidents()
        {
            Log.Info("DataManager.RefreshIncidents");
            if (DownloadAndSaveXml(IncidentsURL, IncidentsFilepath))
            {
                _Incidents = null;
                return true;
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
                    _Incidents = new Incidents();
                    //Load user created incidents
                    foreach (string filePath in Directory.GetFiles(DataDirectory, "*.inc"))
                    {
                        Incident incident = Incident.Load(filePath);
                        if (incident != null)
                        {
                            incident.IsNew = true;
                            _Incidents.Add(incident);
                        }
                    }
                    //Load existing incidents downloaded from server
                    foreach (Incident incident in Incidents.Load(IncidentsFilepath))
                    {
                        _Incidents.Add(incident);
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
            Incidents.Add(incident);
            string filePath = Path.Combine(DataDirectory, string.Format("{0}.inc", Guid.NewGuid()));
            Log.Info("DataManager.AddIncident", "{0}", filePath);
            return incident.Save(filePath);
        }

        /// <summary>
        /// Upload all new incidents
        /// </summary>
        /// <returns>true, if successful</returns>
        public static bool UploadIncidents()
        {
            foreach(string filePath in Directory.GetFiles(DataDirectory, "*.inc"))
            {
                Incident incident = Incident.Load(filePath);
                if (incident != null)
                {
                    string url = string.Format("{0}/api?task=report", ServerAddress);
                    Log.Info("DataManager.UploadIncidents", url);

                    StringBuilder param = new StringBuilder();
                    param.AppendFormat("resp={0}", "xml");
                    param.AppendFormat("&incident_title={0}", Http.UrlEncode(incident.Title));
                    param.AppendFormat("&incident_description={0}", Http.UrlEncode(incident.Description));
                    param.AppendFormat("&incident_date={0}", incident.Date.ToString("dd/MM/yy"));
                    param.AppendFormat("&incident_hour={0}", incident.Date.ToString("hh"));
                    param.AppendFormat("&incident_minute={0}", incident.Date.ToString("mm"));
                    param.AppendFormat("&incident_ampm={0}", incident.Date.ToString("tt").ToLower());
                    param.AppendFormat("&incident_category={0}", Http.UrlEncode(incident.CategoryTitle));
                    param.AppendFormat("&latitude={0}", incident.Latitude);
                    param.AppendFormat("&longitude={0}", incident.Longitude);
                    param.AppendFormat("&location_name={0}", incident.LocationName);
                    param.AppendFormat("&person_first={0}", Http.UrlEncode(FirstName));
                    param.AppendFormat("&person_last={0}", Http.UrlEncode(LastName));
                    param.AppendFormat("&person_email={0}", Http.UrlEncode(Email));

                    Log.Info("DataManager.UploadIncidents", param.ToString());

                    try
                    {
                        byte[] postBytes = Encoding.ASCII.GetBytes(param.ToString());
                        Uri uri = new Uri(url, UriKind.Absolute);
                        HttpWebRequest webRequest = (HttpWebRequest) WebRequest.Create(uri);
                        webRequest.Method = "POST";
                        webRequest.ContentType = "application/x-www-form-urlencoded";
                        webRequest.ContentLength = postBytes.Length;
                        using (Stream requestStream = webRequest.GetRequestStream())
                        {
                            requestStream.Write(postBytes, 0, postBytes.Length);
                            requestStream.Close();
                        }
                        using (HttpWebResponse webResponse = (HttpWebResponse) webRequest.GetResponse())
                        {
                            using (Stream responseStream = webResponse.GetResponseStream())
                            {
                                using (StreamReader responseStreamReader = new StreamReader(responseStream))
                                {
                                    string responseText = responseStreamReader.ReadToEnd();
                                    Log.Info("DataManager.UploadIncidents", responseText);
                                    Response result = Response.Parse(responseText);
                                    if (result != null && result.Success)
                                    {
                                        //if upload successful, delete file form disk
                                        Log.Info("DataManager.UploadIncidents", "Deleting {0}", filePath);
                                        File.Delete(filePath);
                                    }
                                    else
                                    {
                                        Log.Critical("DataManager.UploadIncidents", "Failure {0}", filePath);
                                    }
                                }
                            }
                        }
                    }
                    catch(WebException ex)
                    {
                        Log.Exception("DataManager.UploadIncidents", "WebException {0} {1)", ex.Status, ex.Message);
                    }
                }
            }
            return true;
        }

        #endregion

        #region Media

        /// <summary>
        /// Load image from disk
        /// </summary>
        /// <param name="fileName">filename</param>
        /// <returns>Image, if filepath exists</returns>
        public static Image LoadImage(string fileName)
        {
            string filePath = Path.Combine(DataDirectory, fileName);
            return File.Exists(filePath) ? new Bitmap(filePath) : null;
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
            if (Directory.Exists(DataDirectory) == false)
            {
                Log.Info("DataManager.DownloadJSON", "Directory Created:{0}", DataDirectory);
                Directory.CreateDirectory(DataDirectory);
            }
            string xmlString = DownloadXml(url);
            if (string.IsNullOrEmpty(xmlString) == false)
            {
                if (File.Exists(filepath))
                {
                    Log.Info("DataManager.DownloadJSON", "File Deleted:{0}", filepath);
                    File.Delete(filepath);
                }
                Log.Info("DataManager.DownloadJSON", "File Created:{0}", filepath);
                using (StreamWriter writer = new StreamWriter(filepath))
                {
                    writer.WriteLine(xmlString);
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// Download and return XML from URL
        /// </summary>
        /// <param name="url">url</param>
        /// <returns>XML as string</returns>
        private static string DownloadXml(string url)
        {
            Log.Info("DataManager.DownloadXml", "URL: {0}", url);
            Uri uri = new Uri(url, UriKind.Absolute);
            WebRequest request = WebRequest.Create(uri);
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (Stream dataStream = response.GetResponseStream())
            {
                using (XmlReader reader = XmlReader.Create(dataStream))
                {
                    if (reader.ReadToDescendant("payload"))
                    {
                        return reader.ReadInnerXml();
                        //string xmlString = reader.ReadInnerXml();
                        //for (int i = 0; i < 10; i++)
                        //{
                        //    xmlString = xmlString.Replace(string.Format("<incident{0}>", i), "");
                        //    xmlString = xmlString.Replace(string.Format("</incident{0}>", i), "");
                        //}
                        //return xmlString;
                    }
                }
            }
            return null;
        }

        #endregion

    }
}
