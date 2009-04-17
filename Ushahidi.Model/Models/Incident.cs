using System;
using System.Collections.Generic;
using System.Drawing;
using System.Xml.Serialization;

namespace Ushahidi.Model.Models
{
    [XmlRoot("incident")]
    public class Incident : Model
    {
        [XmlElement("incidentid")]
        public int ID { get; set; }

        [XmlElement("incidenttitle")]
        public string Title { get; set; }

        [XmlElement("incidentdescription")]
        public string Description { get; set; }

        [XmlElement("incidentdate")]
        public DateTime Date { get; set; }

        [XmlElement("incidentmode")]
        public int Mode { get; set; }

        [XmlElement("incidentactive")]
        public bool Active { get; set; }

        [XmlElement("incidentverified")]
        public bool Verified { get; set; }

        [XmlElement("locationid")]
        public int LocationID { get; set; }

        [XmlElement("locationname")]
        public string LocationName { get; set; }

        [XmlElement("locationlatitude")]
        public double Latitude { get; set; }

        [XmlElement("locationlongitude")]
        public double Longitude { get; set; }

        [XmlElement("category")]
        public Category Category { get; set; }

        [XmlArray("media", IsNullable = true)]
        [XmlArrayItem("media")] 
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
