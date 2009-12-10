using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Xml.Serialization;
using Ushahidi.Common.Extensions;
using Ushahidi.Common.Logging;
using Ushahidi.Common.Net;

namespace Ushahidi.Model.Models
{
    [Serializable]
    [XmlType(Identifier)]
    public class Media : Common.MVC.Model
    {
        public const string Identifier = "media";
        
        [XmlElement("type")]
        public int Type { get; set; }

        [XmlElement("link")]
        public string Link { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("thumb")]
        public string ThumbnailLink { get; set; }

        [XmlIgnore]
        public MediaType MediaType
        {
            get { return (MediaType)Type; }
        }

        [XmlIgnore]
        public bool IsPhoto
        {
            get { return MediaType == MediaType.Photo; }
        }

        [XmlIgnore]
        public bool IsNews
        {
            get { return MediaType == MediaType.News; }
        }

        [XmlIgnore]
        public bool IsAudio
        {
            get { return MediaType == MediaType.Audio; }
        }

        [XmlIgnore]
        public bool IsVideo
        {
            get { return MediaType == MediaType.Video; }
        }

        public override string ToString()
        {
            return string.Format("{0}", Link).Trim();
        }

        public static Media Parse(string xml)
        {
            return Parse<Media>(xml);
        }

        public static Media New(string imageName, string thumbnailName)
        {
            return new Media
            {
              ID = (-1),
              Type = ((int) MediaType.Photo),
              Link = imageName,
              ThumbnailLink = thumbnailName,
              Upload = true
            };
        }

        /// <summary>
        /// Import Photo Into Media Directory
        /// </summary>
        /// <param name="filePath">image path</param>
        /// <param name="directory">destination directory</param>
        /// <param name="size">image size</param>
        /// <returns>Media</returns>
        public static Media Import(string filePath, string directory, Size size)
        {
            Log.Info("Media.Import", "filePath:{0} size:{1}x{2}", filePath, size.Width, size.Height);
            string dateString = DateTime.Now.ToString("yyyy_MM_dd_hh_mm_ss");
            string imageName = string.Format("{0}.jpg", dateString);
            string thumbnailName = string.Format("{0}_t.jpg", dateString);
            string imagePath = Path.Combine(directory, imageName);
            if(filePath.Resize(imagePath, size))
            {
                Log.Info("Media.Import");    
            }
            using (Bitmap thumbnail = CreateThumbnail(imagePath, 100))
            {
                string thumbnailPath = Path.Combine(directory, thumbnailName);
                thumbnail.Save(thumbnailPath, ImageFormat.Jpeg);
            }
            return New(imageName, thumbnailName);
        }

        /// <summary>
        /// Download image from server
        /// </summary>
        /// <param name="sourceURL">source url</param>
        /// <param name="destinationFilePath">destination filepath</param>
        /// <returns>true, if successful</returns>
        public static bool Download(string sourceURL, string destinationFilePath)
        {
            try
            {
                Log.Info("DataManager.DownloadImage", "Source: {0} Destination: {1}", sourceURL, destinationFilePath);
                FileInfo fileInfo = new FileInfo(destinationFilePath);
                if (fileInfo.Exists == false || fileInfo.Length == 0)
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sourceURL);
                    ServicePointManager.CertificatePolicy = Internet.AcceptAllCertificatePolicy();
                    request.Credentials = CredentialCache.DefaultCredentials;
                    request.AllowAutoRedirect = true;
                    request.ReadWriteTimeout = 5000;
                    request.Method = "GET";
                    request.Timeout = 5000;
                    request.KeepAlive = false;
                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    {
                        using (Stream stream = response.GetResponseStream())
                        {
                            using (Image image = new Bitmap(stream))
                            {
                                image.Save(destinationFilePath, ImageFormat.Jpeg);
                            }
                        }
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                Log.Exception("DataManager.DownloadImage", "Exception: {0}", ex.Message);
            }
            return false;
        }

        protected static Bitmap CreateThumbnail(string filePath, int widthOrHeight)
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
                                 ? new Rectangle(0, 0, widthOrHeight, widthOrHeight * original.Height / original.Width)
                                 : new Rectangle(0, 0, widthOrHeight * original.Width / original.Height, widthOrHeight);

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
                Log.Exception("Media.CreateThumbnail", "Exception: {0}", ex.Message);
            }
            return null;
        }
    }
}
