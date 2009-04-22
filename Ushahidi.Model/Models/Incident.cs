using System;
using System.Linq;
using System.Collections.Generic;
using System.Xml.Serialization;
using Ushahidi.Common.Extensions;

namespace Ushahidi.Model.Models
{
    [XmlRoot("incident")]
    public class Incident : Model
    {
        [XmlElement("id")]
        public int ID { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("description", IsNullable = true)]
        public string Description { get; set; }

        [XmlElement("date")]
        public string DateString { get; set; }

        [XmlIgnore]
        public DateTime Date
        {
            get { return DateString.ToDateTime("yyyy-MM-dd hh:mm:ss"); }
            set { DateString = value.ToString("yyyy-MM-dd hh:mm:ss"); }
        }

        [XmlElement("mode")]
        public int Mode { get; set; }

        [XmlElement("active")]
        public bool Active { get; set; }

        [XmlElement("verified")]
        public bool Verified { get; set; }

        [XmlElement("location", Type = typeof(Locale))]
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
        [XmlArrayItem("category")]
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
            get { return Categories != null && Categories.Length > 0 ? Categories[0].Title : string.Empty; }
        }

        public bool HasCategory(int categoryID)
        {
            return Categories.Any(c => c.ID == categoryID);
        }

        [XmlArray("mediaItems", IsNullable = true)]
        [XmlArrayItem("media", Type = typeof(Media))]
        public Media[] MediaItems
        {
            get { return _Media.ToArray(); }
            set
            {
                _Media.Clear();
                if (value != null)
                {
                    _Media.AddRange(value);
                }
            }
        }private readonly List<Media> _Media = new List<Media>();

        [XmlIgnore]
        public bool IsNew { get; set; }

        public void AddMedia(Media media)
        {
            _Media.Add(media);
        }

        public override string ToString()
        {
            return Title;
        }

        public static Incident Load(string filePath)
        {
            return Load<Incident>(filePath);
        }

        public bool Save(string filePath)
        {
            return Save(this, filePath);
        }

        public static Incident Parse(string xml)
        {
            return Parse<Incident>(xml);
        }
    }
}
