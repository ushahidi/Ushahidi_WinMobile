using System;
using System.Xml.Serialization;

namespace Ushahidi.Model.Models
{
    [Serializable]
    [XmlType(Identifier)]
    public class Locale : Common.MVC.Model
    {
        public const string Identifier = "location";

        [XmlElement("id")]
        public override int ID { get; set; }

        [XmlElement("upload")]
        public override bool Upload { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("country_id")]
        public string CountryID { get; set;}
        
        [XmlElement("latitude")]
        public string Latitude { get; set; }

        [XmlElement("longitude")]
        public string Longitude { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
