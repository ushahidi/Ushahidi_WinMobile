using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Xml;
using Microsoft.Win32;
using Ushahidi.Common.Logging;
using Ushahidi.Common.Net;
using Ushahidi.Model.Models;
using Ushahidi.Common;
using Ushahidi.Common.MVC;

namespace Ushahidi.Model
{
    /// <summary>
    /// Data manager
    /// </summary>
    public class DataManager
    {
        #region Settings

        /// <summary>
        /// Server Address
        /// </summary>
        public static string ServerAddress { get; set; }

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
            get
            {
                if (_DataDictionary == null)
                {
                    _DataDictionary = Path.Combine(Runtime.AppDirectory, "Data");
                    if (Directory.Exists(_DataDictionary) == false)
                    {
                        Directory.CreateDirectory(_DataDictionary);
                    }
                }
                return _DataDictionary;
            }
        }private static string _DataDictionary;

        private const string RegKeyUshahidi = "Ushahidi";
        private const string RegKeyServer = "Server";
        private const string RegKeyLanguage = "Language";
        private const string RegKeyLastSync = "LastSync";
        private const string RegKeyShowKeyboard = "ShowKeyboard";
        private const string RegKeyFirstName = "FirstName";
        private const string RegKeyLastName = "LastName";
        private const string RegKeyEmail = "Email";

        static DataManager()
        {
            RegistryKey registryKey = Registry.LocalMachine.CreateSubKey(RegKeyUshahidi);
            if (registryKey != null)
            {
                ServerAddress = registryKey.GetValue(RegKeyServer, "http://demo.ushahidi.com").ToString();

                string languageCode = registryKey.GetValue(RegKeyLanguage, "en").ToString();
                Language = Languages.FirstOrDefault(c => c.Name == languageCode);

                string lastSyncDate = registryKey.GetValue(RegKeyLastSync, "").ToString();
                LastSyncDate = string.IsNullOrEmpty(lastSyncDate) ? DateTime.MinValue : DateTime.Parse(lastSyncDate);

                ShowKeyboard = Convert.ToBoolean(registryKey.GetValue(RegKeyShowKeyboard, true));

                FirstName = registryKey.GetValue(RegKeyFirstName, "").ToString();

                LastName = registryKey.GetValue(RegKeyLastName, "").ToString();

                Email = registryKey.GetValue(RegKeyEmail, "").ToString();

                registryKey.Close();
            }
        }

        /// <summary>
        /// Save Settings
        /// </summary>
        /// <returns>true, if successful</returns>
        public static bool Save()
        {
            RegistryKey registryKey = Registry.LocalMachine.CreateSubKey(RegKeyUshahidi);
            if (registryKey != null)
            {
                registryKey.SetValue(RegKeyServer, ServerAddress);
                registryKey.SetValue(RegKeyLanguage, Language);
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

        #region Languages

        /// <summary>
        /// Resource Manager
        /// </summary>
        private static readonly ResourceManager ResourceManager = new ResourceManager("Ushahidi.Model.Languages.Language", Assembly.GetExecutingAssembly());

        /// <summary>
        /// Languages
        /// </summary>
        public static IEnumerable<CultureInfo> Languages
        {
            get
            {
                if (_Languages == null)
                {
                    _Languages = new BindingList<CultureInfo>();
                    DirectoryInfo appDirectory = new DirectoryInfo(Runtime.AppDirectory);
                    string resourceName = string.Format("{0}.resources.dll", Assembly.GetExecutingAssembly().GetName().Name);
                    foreach (DirectoryInfo directoryInfo in appDirectory.GetDirectories().OrderBy(d => d.Name))
                    {
                        if (directoryInfo.GetFiles(resourceName).Length > 0)
                        {
                            Log.Info("LanguageManager", "Culture: {0}", directoryInfo.Name);
                            _Languages.Add(new CultureInfo(directoryInfo.Name));
                        }
                    }
                }
                return _Languages;
            }
        }private static BindingList<CultureInfo> _Languages;

        /// <summary>
        /// Current Language
        /// </summary>
        public static CultureInfo Language
        {
            get
            {
                if (_Language == null)
                {
                    _Language = _Languages.First(c => c.Name == "en");
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

        public static string Translate(string name)
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

        #endregion

        #region Categories

        /// <summary>
        /// Refresh Categories
        /// </summary>
        /// <returns></returns>
        public static bool DownloadCategories(string serverAddress)
        {
            Log.Info("DataManager.DownloadCategories", "serverAddress={0}", serverAddress);
            string categoriesURL = string.Format("{0}/api?task=categories&resp=xml", serverAddress);
            Categories = Download<Category>(categoriesURL, Category.Identifier);
            return Categories != null;
        }

        /// <summary>
        /// Categories
        /// </summary>
        public static Models<Category> Categories
        {
            private set { _Categories = value; }
            get
            {
                if (_Categories == null)
                {
                    _Categories = Load<Category>(Category.Identifier);
                }
                return _Categories;
            }
        }private static Models<Category> _Categories;

        #endregion

        #region Countries

        /// <summary>
        /// Download Categories and file JSON to disk
        /// </summary>
        /// <returns></returns>
        public static bool DownloadCountries(string serverAddress)
        {
            Log.Info("DataManager.DownloadCountries", "serverAddress={0}", serverAddress);
            string countriesURL = string.Format("{0}/api?task=countries&resp=xml", serverAddress);
            Countries = Download<Country>(countriesURL, Country.Identifier);
            return Countries != null;
        }

        /// <summary>
        /// Countries
        /// </summary>
        public static Models<Country> Countries
        {
            private set { _Countries = value; }
            get
            {
                if (_Countries == null)
                {
                    _Countries = Load<Country>(Country.Identifier);
                }
                return _Countries;
            }
        }private static Models<Country> _Countries;

            #endregion

        #region Locales

        /// <summary>
        /// Download Locales and file JSON to disk
        /// </summary>
        /// <returns></returns>
        public static bool DownloadLocales(string serverAddress)
        {
            Log.Info("DataManager.DownloadLocales", "serverAddress={0}", serverAddress);
            string localesURL = string.Format("{0}/api?task=locations&resp=xml", serverAddress);
            Locales = Download<Locale>(localesURL, Locale.Identifier);
            return Locales != null;
        }

        /// <summary>
        /// Locales
        /// </summary>
        public static Models<Locale> Locales
        {
            private set { _Locales = value; }
            get
            {
                if (_Locales == null)
                {
                    _Locales = Load<Locale>(Locale.Identifier);
                }
                return _Locales;
            }
        }private static Models<Locale> _Locales;

        #endregion

        #region Incidents

        /// <summary>
        /// Download Incidents and file JSON to disk
        /// </summary>
        /// <returns>true, if successful</returns>
        public static bool DownloadIncidents(string serverAddress)
        {
            Log.Info("DataManager.DownloadIncidents", "serverAddress={0}", serverAddress);
            string incidentsURL = string.Format("{0}/api?task=incidents&by=all&resp=xml", serverAddress);
            Incidents = Download<Incident>(incidentsURL, Incident.Identifier);
            return Incidents != null;
        }

        /// <summary>
        /// Incidents
        /// </summary>
        public static Models<Incident> Incidents
        {
            private set { _Incidents = value;}
            get
            {
                if (_Incidents == null)
                {
                    _Incidents = Load<Incident>(Incident.Identifier);
                }
                return _Incidents;
            }
        }private static Models<Incident> _Incidents;

        /// <summary>
        /// Add a new incident
        /// </summary>
        /// <param name="incident">incident</param>
        public static bool AddIncident(Incident incident)
        {
            Incidents.Add(incident);
            string fileName = string.Format("{0}.{1}", DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss"), Incident.Identifier);
            string filePath = Path.Combine(DataDirectory, fileName);
            Log.Info("DataManager.AddIncident", "{0}", filePath);
            return incident.Save(filePath);
        }

        /// <summary>
        /// Upload all new incidents
        /// </summary>
        /// <returns>true, if successful</returns>
        public static bool UploadIncidents(string url)
        {
            foreach(Incident incident in Incidents)
            {
                try
                {
                    PostData postData = new PostData(Encoding.UTF8);
                    postData.Add("task", "report");
                    postData.Add("resp", "xml");
                    postData.Add("incident_title", incident.Title);
                    postData.Add("incident_description", incident.Description);
                    postData.Add("incident_date", incident.Date.ToString("MM/dd/yyyy"));
                    postData.Add("incident_hour", incident.Date.ToString("hh"));
                    postData.Add("incident_minute", incident.Date.ToString("mm"));
                    postData.Add("incident_ampm", incident.Date.ToString("tt").ToLower());
                    postData.Add("incident_category", incident.Categories.Select(c => c.ID));
                    postData.Add("latitude", incident.LocaleLatitude);
                    postData.Add("longitude", incident.LocaleLongitude);
                    postData.Add("location_name", incident.LocaleName);
                    postData.Add("person_first", FirstName);
                    postData.Add("person_last", LastName);
                    postData.Add("person_email", Email);
                    postData.Add("incident_news", incident.NewsLinks.Select(m => m.Link));
                    postData.Add("incident_video", incident.VideoLinks.Select(m => m.Link));
                    Log.Info("DataManager.UploadIncidents", "{0}", postData.ToString());

                    string uploadURL = string.Format("{0}{1}{2}", ServerAddress, ServerAddress.EndsWith("/") ? "" : "/", "api");
                    HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(uploadURL);
                    webRequest.Method = "POST";
                    webRequest.ContentType = "application/x-www-form-urlencoded";
                    webRequest.KeepAlive = false;
                    webRequest.AllowAutoRedirect = true;
                    webRequest.Timeout = 15000;
                    byte[] bytes = postData.ToUrlEncodedData();
                    webRequest.ContentLength = bytes.Length;
                    using (Stream requestStream = webRequest.GetRequestStream())
                    {
                        requestStream.Write(bytes, 0, bytes.Length);
                        requestStream.Close();
                    }
                    using (HttpWebResponse webResponse = (HttpWebResponse) webRequest.GetResponse())
                    {
                        using (Stream responseStream = webResponse.GetResponseStream())
                        {
                            using (StreamReader responseReader = new StreamReader(responseStream))
                            {
                                string responseText = responseReader.ReadToEnd();
                                Log.Info("DataManager.UploadIncidents", "{0}", responseText);
                                Response result = Response.Parse(responseText);
                                if (result != null && result.Success)
                                {
                                    Log.Info("DataManager.UploadIncidents", "Deleting {0}", incident.FilePath);
                                    string destinationPath = Path.Combine(DataDirectory, Path.GetFileName(incident.FilePath));
                                    File.Move(incident.FilePath, destinationPath);
                                }
                                else
                                {
                                    Log.Critical("DataManager.UploadIncidents", "Failure {0}", incident.FilePath);
                                }
                            }
                        }
                    }
                }
                catch(WebException ex)
                {
                    Log.Exception("DataManager.UploadIncidents", "WebException {0} {1)", ex.Status, ex.Message);
                }
                catch(Exception ex)
                {
                    Log.Exception("DataManager.UploadIncidents", "Exception {0}", ex.Message);
                }
            }
            return true;
        }

        #endregion

        #region Media

        /// <summary>
        /// Data Directory
        /// </summary>
        private static string MediaDirectory
        {
            get
            {
                if (_MediaDirectory == null)
                {
                    _MediaDirectory = Path.Combine(Runtime.AppDirectory, "Media");
                    if (Directory.Exists(_MediaDirectory) == false)
                    {
                        Directory.CreateDirectory(_MediaDirectory);
                    }
                }
                return _MediaDirectory;
            }
        }private static string _MediaDirectory;

        /// <summary>
        /// Download Media and file JSON to disk
        /// </summary>
        /// <returns>true, if successful</returns>
        public static bool DownloadMedia(string serverAddress)
        {
            foreach(Incident incident in Incidents)
            {
                foreach(Media media in incident.MediaItems.Where(m => m.MediaType == MediaType.Photo))
                {
                   if (string.IsNullOrEmpty(media.ThumbnailLink) == false)
                   {
                       string url = string.Format("{0}/media/uploads/{1}", ServerAddress, media.ThumbnailLink);
                       string filePath = Path.Combine(MediaDirectory, media.ThumbnailLink);
                       DownloadImage(url, filePath);
                   }
                   if (string.IsNullOrEmpty(media.Link) == false)
                   {
                       string url = string.Format("{0}/media/uploads/{1}", ServerAddress, media.Link);
                       string filePath = Path.Combine(MediaDirectory, media.Link);
                       DownloadImage(url, filePath);
                   }
                }
            }
            return true;
        }

        /// <summary>
        /// Import Photo
        /// </summary>
        /// <param name="fileInfo">source image path</param>
        /// <returns>destination image path</returns>
        public static Media ImportPhoto(FileInfo fileInfo)
        {
            if (fileInfo != null && fileInfo.Exists)
            {
                string dateString = DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss");
                string imageName = string.Format("{0}.jpg", dateString);
                string thumbnailName = string.Format("{0}_t.jpg", dateString);
                string imagePath = Path.Combine(MediaDirectory, imageName);
                fileInfo.CopyTo(imagePath, true);
                string thumbnailPath = Path.Combine(MediaDirectory, thumbnailName);
                using(Bitmap thumbnail = CreateThumbnail(imagePath, 100))
                {
                    thumbnail.Save(thumbnailPath, ImageFormat.Jpeg);
                }
                return Media.New(imageName, thumbnailName);
            }
            return null;
        }

        /// <summary>
        /// Load image from disk
        /// </summary>
        /// <param name="fileName">filename</param>
        /// <returns>Image, if filepath exists</returns>
        public static Bitmap LoadImage(string fileName)
        {
            if (string.IsNullOrEmpty(fileName) == false)
            {
                string dataPath = Path.Combine(MediaDirectory, fileName);
                if (File.Exists(dataPath))
                {
                    return new Bitmap(dataPath);
                }
            }
            return null;
        }

        public static bool HasImage(string fileName)
        {
            return File.Exists(Path.Combine(MediaDirectory, fileName));
        }

        #endregion

        #region Helpers

        private static Models<TModel> Download<TModel>(string url, string identifier)
            where TModel : Common.MVC.Model
        {
            try
            {
                Models<TModel> models = new Models<TModel>();
                WebRequest request = WebRequest.Create(url);
                request.Timeout = 5000;
                request.Credentials = CredentialCache.DefaultCredentials;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (Stream dataStream = response.GetResponseStream())
                {
                    XmlDocument document = new XmlDocument();
                    document.Load(dataStream);
                    foreach (XmlNode node in document.GetElementsByTagName(identifier))
                    {
                        try
                        {
                            string modelXML = node.OuterXml;
                            TModel model = Common.MVC.Model.Parse<TModel>(modelXML);
                            if (model != null)
                            {
                                model.FilePath = Path.Combine(DataDirectory, string.Format("{0}.{1}", model.ID, identifier));
                                if (File.Exists(model.FilePath))
                                {
                                    File.Delete(model.FilePath);
                                }
                                using(TextWriter writer = new StreamWriter(model.FilePath))
                                {
                                    writer.WriteLine(modelXML);
                                }
                                models.Add(model);
                                //if (model.Save())
                                //{
                                //    models.Add(model);
                                //}
                            }
                        }
                        catch (Exception ex)
                        {
                            Log.Exception("DataManager.Download", "Exception: {0}", ex.Message);
                        }
                    }
                }
                return models;
            }
            catch (Exception ex)
            {
                Log.Exception("DataManager.Download", "{0} {1}", ex.Message, url);
            }
            return null;
        }

        private static Models<TModel> Load<TModel>(string fileExtension)
            where TModel : Common.MVC.Model
        {
            Models<TModel> models = new Models<TModel>();
            foreach (string filePath in Directory.GetFiles(DataDirectory, string.Format("*.{0}", fileExtension)))
            {
                TModel model = Common.MVC.Model.Load<TModel>(filePath);
                if (model != null)
                {
                    model.FilePath = filePath;
                    models.Add(model);
                }
            }
            return models;
        }

        /// <summary>
        /// Download image from server
        /// </summary>
        /// <param name="sourceURL">source url</param>
        /// <param name="destinationFilePath">destination filepath</param>
        /// <returns>true, if successful</returns>
        private static bool DownloadImage(string sourceURL, string destinationFilePath)
        {
            Log.Info("DataManager.DownloadImage", "Source: {0} Destination: {1}", sourceURL, destinationFilePath);
            FileInfo fileInfo = new FileInfo(destinationFilePath);
            if (fileInfo.Exists == false || fileInfo.Length == 0)
            {
                WebRequest request = WebRequest.Create(sourceURL);
                request.Timeout = 5000;
                request.Credentials = CredentialCache.DefaultCredentials;
                HttpWebResponse response = (HttpWebResponse) request.GetResponse();
                using (Stream stream = response.GetResponseStream())
                {
                    using (Image image = new Bitmap(stream))
                    {
                        image.Save(destinationFilePath, ImageFormat.Jpeg);
                    }
                }
                return true;
            }
            return false;
        }

        private static Bitmap CreateThumbnail(string filePath, int widthOrHeight)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    using (Bitmap original = new Bitmap(filePath))
                    {
                        if (original.Width < widthOrHeight && original.Height < widthOrHeight) return original;
                        Rectangle srcRect = new Rectangle(0, 0, original.Width, original.Height);
                        Rectangle destRect = (original.Width > original.Height)
                                 ? new Rectangle(0, 0, widthOrHeight, widthOrHeight*original.Height/original.Width)
                                 : new Rectangle(0, 0, widthOrHeight*original.Width/original.Height, widthOrHeight);

                        Bitmap thumbnail = new Bitmap(destRect.Width, destRect.Height);
                        using (Graphics graphics = Graphics.FromImage(thumbnail))
                        {
                            using (Brush brush = new SolidBrush(Color.White))
                            {
                                graphics.FillRectangle(brush, 0, 0, destRect.Width, destRect.Height);
                                graphics.DrawImage(original, destRect, srcRect, GraphicsUnit.Pixel);
                            }
                        }
                        return thumbnail;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Exception("DataManager.CreateThumbnail", "Exception: {0}", ex.Message);
            }
            return null;
        }

        private static void PurgeIncident(Incident incident, string filePath)
        {
            foreach (Media media in incident.MediaItems.Where(m => m.IsPhoto))
            {
                try
                {
                    string imagePath = Path.Combine(MediaDirectory, media.Link);
                    if (File.Exists(imagePath))
                    {
                        File.Delete(imagePath);
                    }
                }
                catch (Exception ex)
                {
                    Log.Exception("DataManager.PurgeIncident", "Exception Delete Image: {0} {1}", media.Link, ex.Message);
                }
                try
                {
                    string thumbnailPath = Path.Combine(MediaDirectory, media.ThumbnailLink);
                    if (File.Exists(thumbnailPath))
                    {
                        File.Delete(thumbnailPath);
                    }
                }
                catch (Exception ex)
                {
                    Log.Exception("DataManager.PurgeIncident", "Exception Delete Thumbnail: {0} {1}", media.Link, ex.Message);
                }
            }
            try
            {
                File.Delete(filePath);
            }
            catch (Exception ex)
            {
                Log.Exception("DataManager.PurgeIncident", "Exception Delete Incident: {0} {1}", filePath, ex.Message);
            }
        }

        #endregion

    }
}
