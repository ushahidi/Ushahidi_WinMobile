using System.Xml.Serialization;

namespace Ushahidi.Model.Models
{
    [XmlType("location")]
    public class Locale : Common.MVC.Model
    {
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
