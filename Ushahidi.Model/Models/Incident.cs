using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Serialization;
using Ushahidi.Common.Extensions;

namespace Ushahidi.Model.Models
{
    [Serializable]
    [XmlRoot(Identifier)]
    public class Incident : Common.MVC.Model
    {
        public const string Identifier = "incident";

        [XmlElement("id")]
        public override int ID { get; set; }

        [XmlElement("upload")]
        public override bool Upload { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("date")]
        public string DateString { get; set; }

        [XmlIgnore]
        public DateTime Date
        {
            get { return DateString.ToDateTime("yyyy-MM-dd HH:mm:ss", "yyyy-MM-dd hh:mm:ss"); }
            set { DateString = value.ToString("yyyy-MM-dd HH:mm:ss"); }
        }

        [XmlElement("mode")]
        public int Mode { get; set; }

        [XmlElement("active")]
        public bool Active { get; set; }

        [XmlElement("verified")]
        public bool Verified { get; set; }

        [XmlElement("location")]
        public Locale Locale { get; set; }

        [XmlIgnore]
        public string LocaleName
        {
            get { return Locale != null ? Locale.Name : string.Empty; }
        }

        [XmlIgnore]
        public string LocaleLatitude
        {
            get { return Locale != null ? Locale.Latitude : string.Empty; }
        }

        [XmlIgnore]
        public string LocaleLongitude
        {
            get { return Locale != null ? Locale.Longitude : string.Empty; }
        }

        [XmlArray("categories")]
        [XmlArrayItem("category", typeof(Category))]
        public Category[] Categories
        {
            get { return _Categories.ToArray(); }
            set
            {
                _Categories.Clear();
                if (value != null)
                {
                    _Categories.AddRange(value);
                }
            }
        }private readonly List<Category> _Categories = new List<Category>();

        [XmlIgnore]
        public string CategoryTitle
        {
            get { return Categories != null && Categories.Length > 0 ? string.Join(",", Categories.Select(c => c.Title).ToArray()) : string.Empty; }
        }

        [XmlIgnore]
        public string LocaleAndDate
        {
            get { return string.Join(" - ", new[] {LocaleName, Date.ToShortDateString()}); }
        }

        public bool HasCategory(int categoryID)
        {
            return Categories.Any(c => c.ID == categoryID);
        }

        [XmlArray("mediaItems")]
        [XmlArrayItem("media", typeof(Media))]
        public Media[] MediaItems
        {
            get { return _MediaItems.ToArray(); }
            set
            {
                _MediaItems.Clear();
                if (value != null)
                {
                    _MediaItems.AddRange(value);
                }
            }
        }private readonly List<Media> _MediaItems = new List<Media>();

        [XmlIgnore]
        public IEnumerable<Media> Photos
        {
            get { return _MediaItems.Where(m => m.IsPhoto); }
        }

        [XmlIgnore]
        public IEnumerable<Media> NewsLinks
        {
            get { return _MediaItems.Where(m => m.IsNews); }
        }

        [XmlIgnore]
        public IEnumerable<Media> AudioLinks
        {
            get { return _MediaItems.Where(m => m.IsAudio); }
        }

        [XmlIgnore]
        public IEnumerable<Media> VideoLinks
        {
            get { return _MediaItems.Where(m => m.IsVideo); }
        }

        public void AddPhoto(string imagePath)
        {
            Media media = new Media
            {
                ID = (-1),
                Title = null,
                Type = ((int) MediaType.Photo),
                Link = Path.GetFileName(imagePath),
                ThumbnailLink = Path.GetFileName(imagePath),
                Upload = true
            };
            _MediaItems.Add(media);
        }

        public void AddPhoto(Media media)
        {
            _MediaItems.Add(media);
        }

        [XmlIgnore]
        public Image Thumbnail
        {
            get
            {
                if (_Thumbnail == null)
                {
                    Media media = _MediaItems.FirstOrDefault(m => m.MediaType == MediaType.Photo);
                    _Thumbnail = media != null ? DataManager.LoadImage(media.ThumbnailLink) : DataManager.LoadMap(ID);
                }
                return _Thumbnail;
            }
        }private Image _Thumbnail;

        public override string ToString()
        {
            return Title;
        }

        public bool Save()
        {
            return Save(this, FilePath);
        }

        public bool Save(string filePath)
        {
            return Save(this, filePath);
        }

        public static Incident Load(string filePath)
        {
            return Load<Incident>(filePath);
        }

        public static Incident Parse(string xml)
        {
            return Parse<Incident>(xml);
        }

        public bool Equals(Incident incident)
        {
            return Title == incident.Title &&
                   Description == incident.Description &&
                   DateString == incident.DateString &&
                   LocaleName == incident.LocaleName &&
                   CategoryTitle == incident.CategoryTitle &&
                   LocaleLatitude == incident.LocaleLatitude &&
                   LocaleLongitude == incident.LocaleLongitude;
        }
    }
}
