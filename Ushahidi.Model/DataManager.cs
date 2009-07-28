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
        #region Settings

        private const string RegKeyUshahidi = "Ushahidi";
        private const string RegKeyServer = "Server";
        private const string RegKeyLanguage = "Language";
        private const string RegKeyLastSync = "LastSync";
        private const string RegKeyShowKeyboard = "ShowKeyboard";
        private const string RegKeyDownloadMaps = "DownloadMaps";
        private const string RegKeyDownloadMedia = "DownloadMedia";
        private const string RegKeyDownloadIncidents = "DownloadIncidents";
        private const string RegKeyFirstName = "FirstName";
        private const string RegKeyLastName = "LastName";
        private const string RegKeyEmail = "Email";
        private const string RegKeyMapType = "Maptype";
        private const string GoogleMapApiKey = "ABQIAAAAbBp5ldXb8kPYkZBnJ3s41RSEmPulsHbWDF8kadrMDbdex3-Z4BTbs5-9i1AkCIoGYgsph72Mjc1g_Q";

        /// <summary>
        /// Screen Width
        /// </summary>
        public static int ScreenWidth { get; set; }

        /// <summary>
        /// Screen Height
        /// </summary>
        public static int ScreenHeight { get; set; }

        /// <summary>
        /// Server Address
        /// </summary>
        public static string ServerAddress { get; set; }

        /// <summary>
        /// Last sync date
        /// </summary>
        public static DateTime LastSyncDate { get; set; }

        /// <summary>
        /// Download Maps
        /// </summary>
        public static bool ShouldDownloadMaps { get; set; }

        /// <summary>
        /// Download Media
        /// </summary>
        public static bool ShouldDownloadMedia { get; set; }

        /// <summary>
        /// Download Incidents
        /// </summary>
        public static bool ShouldDownloadIncidents { get; set; }

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

                ShouldDownloadIncidents = Convert.ToBoolean(registryKey.GetValue(RegKeyDownloadIncidents, true));

                ShouldDownloadMedia = Convert.ToBoolean(registryKey.GetValue(RegKeyDownloadMedia, true));

                ShouldDownloadMaps = Convert.ToBoolean(registryKey.GetValue(RegKeyDownloadMaps, true));

                FirstName = registryKey.GetValue(RegKeyFirstName, "").ToString();

                LastName = registryKey.GetValue(RegKeyLastName, "").ToString();

                Email = registryKey.GetValue(RegKeyEmail, "").ToString();

                MapType = registryKey.GetValue(RegKeyMapType, MapTypes.ElementAt(0)).ToString();

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
                registryKey.SetValue(RegKeyDownloadIncidents, ShouldDownloadIncidents.ToString());
                registryKey.SetValue(RegKeyDownloadMedia, ShouldDownloadMedia.ToString());
                registryKey.SetValue(RegKeyDownloadMaps, ShouldDownloadMaps.ToString());
                registryKey.SetValue(RegKeyFirstName, FirstName);
                registryKey.SetValue(RegKeyLastName, LastName);
                registryKey.SetValue(RegKeyEmail, Email);
                registryKey.SetValue(RegKeyMapType, MapType);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Clear all cache files
        /// </summary>
        /// <returns>true, if successful</returns>
        public static bool ClearCacheFiles()
        {
            Log.Info("DataManager.ClearCacheFiles");
            return DeleteFolderContents(IncidentsDirectory) &&
                   DeleteFolderContents(CountriesDirectory) && 
                   DeleteFolderContents(CategoriesDirectory) &&
                   DeleteFolderContents(LocalesDirectory) &&
                   DeleteFolderContents(MediaDirectory) &&
                   DeleteFolderContents(MapDirectory);
        }

        private static bool DeleteFolderContents(string directory)
        {
            Log.Info("DataManager.DeleteFolderContents", "Directory: {0}", directory);
            foreach(string filePath in Directory.GetFiles(directory).Reverse())
            {
                try
                {
                    File.Delete(filePath);
                }
                catch(Exception ex)
                {
                    Log.Exception("DataManager.DeleteFolderContents", "Exception: {0} {1}", directory, ex.Message);
                }
            }
            return true;
        }

        #endregion

        #region Languages

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
                    _Language = Languages.First(c => c.Name == "en");
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

        protected static ResourceManager ResourceManager
        {
            get
            {
                if (_ResourceManager == null)
                {
                    Assembly executingAssembly = Assembly.GetExecutingAssembly();
                    string resourceName = string.Format("{0}.Languages.Language", executingAssembly.GetName().Name);
                    _ResourceManager = new ResourceManager(resourceName, executingAssembly);
                }
                return _ResourceManager;
            }
        }private static ResourceManager _ResourceManager;

        public static string Translate(string name)
        {
            try
            {
                string translation = ResourceManager.GetString(name, Language);
                Log.Info("DataManager.Translate", "{0} = {1}", name, translation);
                return translation;
            }
            catch (Exception ex)
            {
                Log.Exception("DataManager.Translate", "{0} {1} {2}", name, Language.Name, ex.Message);
                return string.Format("{0}_{1}", name, Language.Name);
            }
        }

        #endregion

        #region Categories

        /// <summary>
        /// Categories Directory
        /// </summary>
        private static string CategoriesDirectory
        {
            get
            {
                if (_CategoriesDirectory == null)
                {
                    _CategoriesDirectory = Path.Combine(Runtime.AppDirectory, "Categories");
                    if (Directory.Exists(_CategoriesDirectory) == false)
                    {
                        Directory.CreateDirectory(_CategoriesDirectory);
                    }
                }
                return _CategoriesDirectory;
            }
        }private static string _CategoriesDirectory;

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
        public static bool DownloadCategories()
        {
            Log.Info("DataManager.DownloadCategories", "serverAddress={0}", ServerAddress);
            Categories = Categories.Download(CategoriesURL, CategoriesDirectory);
            return Categories != null;
        }

        /// <summary>
        /// Categories
        /// </summary>
        public static Categories Categories
        {
            private set { _Categories = value; }
            get
            {
                if (_Categories == null)
                {
                    _Categories = Categories.Load(CategoriesDirectory);
                }
                return _Categories;
            }
        }private static Categories _Categories;

        #endregion

        #region Countries

        /// <summary>
        /// Countries Directory
        /// </summary>
        private static string CountriesDirectory
        {
            get
            {
                if (_CountriesDirectory == null)
                {
                    _CountriesDirectory = Path.Combine(Runtime.AppDirectory, "Countries");
                    if (Directory.Exists(_CountriesDirectory) == false)
                    {
                        Directory.CreateDirectory(_CountriesDirectory);
                    }
                }
                return _CountriesDirectory;
            }
        }private static string _CountriesDirectory;

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
        public static bool DownloadCountries()
        {
            Log.Info("DataManager.DownloadCountries", "serverAddress={0}", ServerAddress);
            Countries = Countries.Download(CountriesURL, CountriesDirectory);
            return Countries != null;
        }

        /// <summary>
        /// Countries
        /// </summary>
        public static Countries Countries
        {
            private set { _Countries = value; }
            get
            {
                if (_Countries == null)
                {
                    _Countries = Countries.Load(CountriesDirectory);
                }
                return _Countries;
            }
        }private static Countries _Countries;

            #endregion

        #region Locales

        /// <summary>
        /// Locales Directory
        /// </summary>
        private static string LocalesDirectory
        {
            get
            {
                if (_LocalesDirectory == null)
                {
                    _LocalesDirectory = Path.Combine(Runtime.AppDirectory, "Locales");
                    if (Directory.Exists(_LocalesDirectory) == false)
                    {
                        Directory.CreateDirectory(_LocalesDirectory);
                    }
                }
                return _LocalesDirectory;
            }
        }private static string _LocalesDirectory;

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
        public static bool DownloadLocales()
        {
            Log.Info("DataManager.DownloadLocales", "serverAddress={0}", ServerAddress);
            Locales = Locales.Download(LocalesURL, LocalesDirectory);
            return Locales != null;
        }

        /// <summary>
        /// Locales
        /// </summary>
        public static Locales Locales
        {
            private set { _Locales = value; }
            get
            {
                if (_Locales == null)
                {
                    _Locales = Locales.Load(LocalesDirectory);
                }
                return _Locales;
            }
        }private static Locales _Locales;

        #endregion

        #region Incidents

        /// <summary>
        /// Incidents Directory
        /// </summary>
        private static string IncidentsDirectory
        {
            get
            {
                if (_IncidentsDirectory == null)
                {
                    _IncidentsDirectory = Path.Combine(Runtime.AppDirectory, "Incidents");
                    if (Directory.Exists(_IncidentsDirectory) == false)
                    {
                        Directory.CreateDirectory(_IncidentsDirectory);
                    }
                }
                return _IncidentsDirectory;
            }
        }private static string _IncidentsDirectory;

        /// <summary>
        /// Incidents URL
        /// </summary>
        private static string IncidentsURL
        {
            get { return string.Format("{0}/api?task=incidents&by=all&resp=xml", ServerAddress); }
        }

        /// <summary>
        /// Download Incidents
        /// </summary>
        /// <returns>true, if successful</returns>
        public static bool DownloadIncidents()
        {
            Log.Info("DataManager.DownloadIncidents", "serverAddress={0}", ServerAddress);
            Incidents = Incidents.Download(IncidentsURL, IncidentsDirectory);
            return Incidents != null;
        }

        /// <summary>
        /// Incidents
        /// </summary>
        public static Incidents Incidents
        {
            private set { _Incidents = value;}
            get
            {
                if (_Incidents == null)
                {
                    _Incidents = Incidents.Load(IncidentsDirectory);
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
            string fileName = string.Format("{0}.xml", DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss"));
            incident.FilePath = Path.Combine(IncidentsDirectory, fileName);
            incident.Upload = true;
            return incident.Save();
        }

        /// <summary>
        /// Upload Incident Media
        /// </summary>
        /// <returns>true, if successful</returns>
        public static bool UploadMedia()
        {
            foreach (Incident incident in Incidents.Where(i => i.ID > 0))
            {
                foreach(Media media in incident.MediaItems.Where(m => m.Upload))
                {
                    PostData postData = new PostData(Encoding.UTF8);
                    postData.Add("resp", "xml");
                    postData.Add("id", incident.ID.ToString());
                    postData.Add("url", media.Link);
                    if (media.IsNews)
                    {
                        postData.Add("task", "tagnews"); 
                    }
                    else if (media.IsVideo)
                    {
                        postData.Add("task", "tagvideo"); 
                    }
                    else if (media.IsAudio)
                    {
                        postData.Add("task", "tagaudio"); 
                    }
                    else if (media.IsPhoto)
                    {
                        postData.Add("task", "tagphoto"); 
                    }
                    else
                    {
                        continue;
                    }
                    if (PostWebRequest(postData))
                    {
                        Log.Info("DataManager.UploadMedia", "Upload media successful");
                        media.Upload = false;
                        if(incident.Save())
                        {
                            Log.Info("DataManager.UploadMedia", "Incident Saved: {0}", incident.ID);
                        }
                    }
                    else
                    {
                        Log.Critical("DataManager.UploadMedia", "Upload media failed");
                    }
                }
            }
            return true;
        }

        /// <summary>
        /// Upload all new incidents
        /// </summary>
        /// <returns>true, if successful</returns>
        public static bool UploadIncidents()
        {
            foreach(Incident incident in Incidents.Where(i => i.Upload))
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
                if (incident.NewsLinks.Count(m => m.Upload) > 0)
                {
                    Media newsMedia = incident.NewsLinks.Last(m => m.Upload);
                    newsMedia.Upload = false;
                    postData.Add("incident_news", newsMedia.Link);
                }
                if (incident.VideoLinks.Count(m => m.Upload) > 0)
                {
                    Media videoMedia = incident.VideoLinks.Last(m => m.Upload);
                    videoMedia.Upload = false;
                    postData.Add("incident_video", videoMedia.Link);
                }
                foreach (Media media in incident.Photos.Where(m => m.Upload))
                {
                    Image image = LoadImage(media.Link);
                    if (image != null)
                    {
                        media.Upload = false;
                        postData.Add("incident_photo[]", media.Link, image);
                    }
                }
                if (PostWebRequest(postData))
                {
                    Log.Info("DataManager.UploadIncidents", "Upload incident successful");
                    incident.Upload = false;
                    if (incident.Save())
                    {
                        Log.Info("DataManager.UploadIncidents", "Incident Saved: {0}", incident.ID);
                    }
                }
                else
                {
                    Log.Critical("DataManager.UploadIncidents", "Upload incident failed");   
                }
            }
            return true;
        }

        /// <summary>
        /// Post WebRequst
        /// </summary>
        /// <param name="postData">post data</param>
        /// <returns>true, is succesful</returns>
        private static bool PostWebRequest(PostData postData)
        {
            try
            {
                string url = string.Format("{0}{1}{2}", ServerAddress, ServerAddress.EndsWith("/") ? "" : "/", "api/");
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
                webRequest.Credentials = CredentialCache.DefaultCredentials;
                webRequest.Method = "POST";
                webRequest.ContentType = string.Format("multipart/form-data; boundary={0}", PostData.Boundary);
                webRequest.AllowAutoRedirect = true;
                webRequest.ReadWriteTimeout = 15000;
                webRequest.Timeout = 15000;
                byte[] bytes = postData.ToBytes();
                webRequest.ContentLength = bytes.Length;
                using (Stream requestStream = webRequest.GetRequestStream())
                {
                    requestStream.Write(bytes, 0, bytes.Length);
                    requestStream.Close();
                }
                using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
                {
                    using (Stream responseStream = webResponse.GetResponseStream())
                    {
                        using (StreamReader responseReader = new StreamReader(responseStream))
                        {
                            string responseText = responseReader.ReadToEnd();
                            Response result = Response.Parse(responseText);
                            return result != null && result.Success;
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                if (ex.Status == WebExceptionStatus.ProtocolError)
                {
                    using (HttpWebResponse response = ex.Response as HttpWebResponse)
                    {
                        if (response != null)
                        {
                            Log.Exception("DataManager.UploadIncidents", "WebException {0} {1) {2}", ex.Status,
                                          ex.Message, response.StatusDescription);
                        }
                    }
                }
                else
                {
                    Log.Exception("DataManager.UploadIncidents", "WebException {0} {1)", ex.Status, ex.Message);
                }
            }
            catch (Exception ex)
            {
                Log.Exception("DataManager.UploadIncidents", "Exception {0}", ex.Message);
            }
            return false;
        }

        #endregion

        #region Maps

        /// <summary>
        /// Maps Directory
        /// </summary>
        private static string MapDirectory
        {
            get
            {
                if (_MapDirectory == null)
                {
                    _MapDirectory = Path.Combine(Runtime.AppDirectory, "Maps");
                    if (Directory.Exists(_MapDirectory) == false)
                    {
                        Directory.CreateDirectory(_MapDirectory);
                    }
                }
                return _MapDirectory;
            }
        }private static string _MapDirectory;

        public static IEnumerable<string> MapTypes
        {
            get { return _MapTypes; }
        }private static readonly string[] _MapTypes = new[] { "Roadmap", "Mobile", "Satellite", "Terrain", "Hybrid" };

        public static string MapType
        {
            get
            {
                if (_MapType == null)
                {
                    _MapType = MapTypes.ElementAt(0);
                }
                return _MapType;
            }
            set { _MapType = value; }
        }private static string _MapType;

        public static bool DownloadMaps()
        {
            foreach (Incident incident in Incidents)
            {
                if (incident.Locale != null)
                {
                    FileInfo filePath = GetMapFilePath(incident.ID, MapType);
                    if (filePath.Exists == false || filePath.Length == 0)
                    {
                        try
                        {
                            StringBuilder url = new StringBuilder("http://maps.google.com/staticmap");
                            url.AppendFormat("?center={0},{1}", incident.LocaleLatitude, incident.LocaleLongitude);
                            url.AppendFormat("&zoom={0}", 12);
                            url.AppendFormat("&format={0}", "jpg");
                            url.AppendFormat("&size={0}x{1}", ScreenWidth, ScreenHeight);
                            url.AppendFormat("&sensor={0}", "true_or_false");
                            url.AppendFormat("&maptype={0}", MapType.ToLower());
                            url.AppendFormat("&markers={0},{1},{2}", incident.LocaleLatitude, incident.LocaleLongitude, "red");
                            url.AppendFormat("&key={0}", GoogleMapApiKey);
                            Media.Download(url.ToString(), filePath.ToString());
                        }
                        catch (Exception ex)
                        {
                            Log.Exception("DataManager.DownloadMaps", "Incident:{0} Exception:{1}", incident.ID, ex.Message);
                        }
                    }
                }
            }
            return true;
        }

        public static Image LoadMap(int incidentID)
        {
            List<string> mapTypes = new List<string> { MapType };
            mapTypes.AddRange(MapTypes.Except(new[] { MapType }));
            foreach (string mapType in mapTypes)
            {
                FileInfo file = GetMapFilePath(incidentID, mapType);
                if (file.Exists)
                {
                    return new Bitmap(file.FullName);
                }
            }
            return null;
        }

        public static bool HasMap(int incidentID)
        {
            if (incidentID > -1)
            {
                foreach (string mapType in MapTypes)
                {
                    if (GetMapFilePath(incidentID, mapType).Exists)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private static FileInfo GetMapFilePath(int incidentID, string mapType)
        {
            return new FileInfo(Path.Combine(MapDirectory, string.Format("{0}_{1}.jpg", incidentID, mapType.ToLower())));
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
        public static bool DownloadMedia()
        {
            Log.Info("DataManager.DownloadMedia");
            foreach(Incident incident in Incidents)
            {
                foreach(Media media in incident.MediaItems.Where(m => m.MediaType == MediaType.Photo))
                {
                   if (string.IsNullOrEmpty(media.ThumbnailLink) == false)
                   {
                       string mediaURL = string.Format("{0}/media/uploads/{1}", ServerAddress, media.ThumbnailLink);
                       string filePath = Path.Combine(MediaDirectory, media.ThumbnailLink);
                       if (Media.Download(mediaURL, filePath))
                       {
                            Log.Info("Download Thumbnail {0} to {1}", mediaURL, filePath); 
                       }
                       else
                       {
                           Log.Exception("Download Thumbnail Failed {0}", mediaURL);
                       }
                   }
                   if (string.IsNullOrEmpty(media.Link) == false)
                   {
                       string mediaURL = string.Format("{0}/media/uploads/{1}", ServerAddress, media.Link);
                       string filePath = Path.Combine(MediaDirectory, media.Link);
                       if (Media.Download(mediaURL, filePath))
                       {
                           Log.Info("Download Image {0} to {1}", mediaURL, filePath);
                       }
                       else
                       {
                           Log.Exception("Download Image Failed {0}", mediaURL);
                       }
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
                using(Bitmap thumbnail = Media.CreateThumbnail(imagePath, 100))
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
    }
}
