using System;
using System.Linq;
using System.Drawing;
using System.Drawing.Imaging;
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
        #region Settings

        /// <summary>
        /// Server
        /// </summary>
        public static string ServerAddress { get; set; }

        /// <summary>
        /// Language
        /// </summary>
        public static string Language { get; set; }

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
        public static string DataDirectory
        {
            get { return Path.Combine(Runtime.AppDirectory, "Data"); }
        }

        /// <summary>
        /// Upload Directory
        /// </summary>
        public static string UploadDirectory
        {
            get { return Path.Combine(Runtime.AppDirectory, "Upload"); }
        }

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
            if (Directory.Exists(DataDirectory) == false)
            {
                Log.Info("DataManager()", "Data Directory Created:{0}", DataDirectory);
                Directory.CreateDirectory(DataDirectory);
            }
            if (Directory.Exists(UploadDirectory) == false)
            {
                Log.Info("DataManager()", "Upload Directory Created:{0}", UploadDirectory);
                Directory.CreateDirectory(UploadDirectory);
            }
            Log.Info("DataManager.LoadSettings");
            RegistryKey registryKey = Registry.LocalMachine.CreateSubKey(RegKeyUshahidi);
            if (registryKey != null)
            {
                ServerAddress = registryKey.GetValue(RegKeyServer, "http://demo.ushahidi.com").ToString();
                Log.Info("DataManager.LoadSettings", "ServerAddress:{0}", ServerAddress);

                Language = registryKey.GetValue(RegKeyLanguage, "en-US").ToString();
                Log.Info("DataManager.LoadSettings", "Language:{0}", Language);

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
                _Countries = Countries.Load(CountriesFilepath);
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
            get { return string.Format("{0}/api?task=incidents&by=all&resp=xml", ServerAddress); }
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
                    Incidents incidents = new Incidents();
                    foreach (Incident incident in Incidents.Load(IncidentsFilepath))
                    {
                        //incidents downloaded from server
                        incidents.Add(incident);
                    }
                    foreach (Incident incident in IncidentsNotUploaded)
                    {
                        //user created incidents not uploaded
                        incidents.Add(incident);
                    }
                    foreach (Incident incident in IncidentsNotPurged)
                    {
                        //user created incidents uploaded, but not purged
                        Incident incidentNotPurged = incident;
                        if (incidents.Any(i => i.Equals(incidentNotPurged)))
                        {
                            PurgeIncident(incident, incident.FilePath);
                        }
                        else
                        {
                            incidents.Add(incident);   
                        }
                    }
                    _Incidents = new Incidents();
                    foreach (Incident incident in incidents.OrderBy(i => i.Date))
                    {
                        _Incidents.Add(incident); 
                    }
                }
                return _Incidents;
            }
        }private static Incidents _Incidents;

        /// <summary>
        /// User-Created Incidents not yet uploaded
        /// </summary>
        protected static Incidents IncidentsNotUploaded
        {
            get
            {
                if (_IncidentsNotUploaded == null)
                {
                    _IncidentsNotUploaded = new Incidents();
                    foreach (string filePath in Directory.GetFiles(UploadDirectory, "*.inc"))
                    {
                        Incident incident = Incident.Load(filePath);
                        if (incident != null)
                        {
                            incident.FilePath = filePath;
                            incident.IsNew = true;
                            _IncidentsNotUploaded.Add(incident);
                        }
                    }
                }
                return _IncidentsNotUploaded;
            }
        }private static Incidents _IncidentsNotUploaded;

        /// <summary>
        /// User-Created Incidents, uploaded but not purged yet
        /// </summary>
        protected static Incidents IncidentsNotPurged
        {
            get
            {
                if (_IncidentsNotPurged == null)
                {
                    _IncidentsNotPurged = new Incidents();
                    foreach (string filePath in Directory.GetFiles(DataDirectory, "*.inc"))
                    {
                        Incident incident = Incident.Load(filePath);
                        if (incident != null)
                        {
                            incident.FilePath = filePath;
                            incident.IsNew = true;
                            _IncidentsNotPurged.Add(incident);
                        }
                    }
                }
                return _IncidentsNotPurged;
            }
        }private static Incidents _IncidentsNotPurged;

        /// <summary>
        /// Add a new incident
        /// </summary>
        /// <param name="incident">incident</param>
        public static bool AddIncident(Incident incident)
        {
            IncidentsNotUploaded.Add(incident);
            Incidents.Add(incident);
            string filePath = Path.Combine(UploadDirectory, string.Format("{0}.inc", Guid.NewGuid()));
            Log.Info("DataManager.AddIncident", "{0}", filePath);
            return incident.Save(filePath);
        }

        /// <summary>
        /// Upload URL
        /// </summary>
        private static string UploadURL
        {
            get { return string.Format("{0}{1}{2}", ServerAddress, ServerAddress.EndsWith("/") ? "" : "/", "api"); }
        }

        /// <summary>
        /// Upload all new incidents
        /// </summary>
        /// <returns>true, if successful</returns>
        public static bool UploadIncidents()
        {
            foreach(Incident incident in IncidentsNotUploaded)
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
                    postData.Add("latitude", incident.Locale.Latitude);
                    postData.Add("longitude", incident.Locale.Longitude);
                    postData.Add("location_name", incident.Locale.Name);
                    postData.Add("person_first", FirstName);
                    postData.Add("person_last", LastName);
                    postData.Add("person_email", Email);
                    postData.Add("incident_news", incident.NewsLinks.Select(m => m.Link));
                    postData.Add("incident_video", incident.VideoLinks.Select(m => m.Link));
                    Log.Info("DataManager.UploadIncidents", "{0}", postData.ToString());

                    HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(UploadURL);
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

        #region Uploads

        /// <summary>
        /// Uploads Filepath
        /// </summary>
        private static string UploadsFilepath
        {
            get { return Path.Combine(UploadDirectory, "Uploads.xml"); }
        }

        /// <summary>
        /// Uploads
        /// </summary>
        public static Uploads Uploads
        {
            get
            {
                if (_Uploads == null)
                {
                    _Uploads = Uploads.Load(UploadsFilepath) ?? new Uploads();
                }
                return _Uploads;
            }
        }private static Uploads _Uploads;

        public static bool AddMedia(int id, Media media)
        {
            if (id > -1)
            {
                Uploads.Add(id, media);
                return Uploads.Save(UploadsFilepath);
            }
            else
            {
                //TODO implement adding photos to newly created incident not yet uploaded
                return false;
            }
        }

        #endregion

        #region Media

        /// <summary>
        /// Download Media and file JSON to disk
        /// </summary>
        /// <returns>true, if successful</returns>
        public static bool DownloadMedia()
        {
            foreach(Incident incident in Incidents)
            {
                foreach(Media media in incident.MediaItems.Where(m => m.MediaType == MediaType.Photo))
                {
                   if (string.IsNullOrEmpty(media.ThumbnailLink) == false)
                   {
                       string url = string.Format("{0}/media/uploads/{1}", ServerAddress, media.ThumbnailLink);
                       string filePath = Path.Combine(DataDirectory, media.ThumbnailLink);
                       DownloadImage(url, filePath);
                   }
                   if (string.IsNullOrEmpty(media.Link) == false)
                   {
                       string url = string.Format("{0}/media/uploads/{1}", ServerAddress, media.Link);
                       string filePath = Path.Combine(DataDirectory, media.Link);
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
                string imagePath = Path.Combine(UploadDirectory, imageName);
                fileInfo.CopyTo(imagePath, true);
                string thumbnailPath = Path.Combine(UploadDirectory, thumbnailName);
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
                string dataPath = Path.Combine(DataDirectory, fileName);
                if (File.Exists(dataPath))
                {
                    return new Bitmap(dataPath);
                }
                string uploadPath = Path.Combine(UploadDirectory, fileName);
                if (File.Exists(uploadPath))
                {
                    return new Bitmap(uploadPath);
                }
            }
            return null;
        }

        public static bool HasImage(string fileName)
        {
            return File.Exists(Path.Combine(DataDirectory, fileName)) || File.Exists(Path.Combine(UploadDirectory, fileName));
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
            WebRequest request = WebRequest.Create(url);
            request.Timeout = 5000; 
            request.Credentials = CredentialCache.DefaultCredentials;
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (Stream dataStream = response.GetResponseStream())
            {
                using (XmlReader reader = XmlReader.Create(dataStream))
                {
                    if (reader.ReadToDescendant("payload"))
                    {
                        return reader.ReadInnerXml();
                    }
                }
            }
            return null;
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
                    string imagePath = Path.Combine(DataDirectory, media.Link);
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
                    string thumbnailPath = Path.Combine(DataDirectory, media.ThumbnailLink);
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
