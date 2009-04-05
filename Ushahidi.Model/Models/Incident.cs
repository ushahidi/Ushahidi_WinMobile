using System;
using System.Collections.Generic;
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

        [XmlElement("locationid")]
        public int LocationID { get; set; }

        [XmlElement("locationname")]
        public string LocationName { get; set; }

        [XmlElement("categoryid")]
        public int CategoryID { get; set; }

        [XmlElement("categorytitle")]
        public string CategoryTitle { get; set; }

        [XmlElement("incidentdate")]
        public DateTime Date { get; set; }

        [XmlElement("latitude")]
        public double Latitude { get; set; }

        [XmlElement("longitude")]
        public double Longitude { get; set; }

        [XmlArray("media", IsNullable = true)]
        [XmlArrayItem("mediaitem")] 
        public Media[] MediaItems
        {
            get { return _Media.ToArray(); }
            set
            {
                _Media.Clear();
                _Media.AddRange(value);
            }
        }private readonly List<Media> _Media = new List<Media>();

        public void AddMedia(Media media)
        {
            _Media.Add(media);
        }

        public override string ToString()
        {
            return Title;
        }

        [XmlIgnore]
        public bool IsNew { get; set; }

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
