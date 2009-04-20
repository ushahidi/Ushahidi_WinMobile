using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Ushahidi.Common.Extensions;

namespace Ushahidi.Model.Models
{
    /// <summary>
    /// <incident>
    ///     <incidentid>1</incidentid>
    ///     <incidenttitle>Test</incidenttitle>
    ///     <incidentdescription>Test by E.</incidentdescription>
    ///     <incidentdate>2009-01-13 01:00:00</incidentdate>
    ///     <incidentmode>1</incidentmode>
    ///     <incidentactive>1</incidentactive>
    ///     <incidentverified>0</incidentverified>
    ///     <locationid>1</locationid>
    ///     <locationname>puwokerto</locationname>
    ///     <locationlatitude>-7.431518</locationlatitude>
    ///     <locationlongitude>109.247398</locationlongitude>
    ///     <category>
    ///         <categoryid>7</categoryid>
    ///         <categorytitle>CIVILIANS</categorytitle>
    ///         <categoryid>8</categoryid>
    ///         <categorytitle>LOOTING</categorytitle>
    ///     </category>
    /// </incident>
    /// </summary>
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
        public string DateString { get; set; }

        public DateTime Date
        {
            get { return DateString.ToDateTime(); }
            set { DateString = value.ToString("yyyy-MM-dd hh:mm:ss"); }
        }

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

        //[XmlArray("media", IsNullable = true)]
        //[XmlArrayItem("media")]
        [XmlElement("media")]
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
