using System.Xml.Serialization;

namespace Ushahidi.Model.Models
{
    [XmlRoot("location")]
    public class Locale : Model
    {
        [XmlElement("id")]
        public int ID { get; set; }

        [XmlElement("location_name")]
        public string Name { get; set; }

        [XmlElement("country_id")]
        public string CountryID { get; set;}
        
        [XmlElement("latitude", IsNullable=true)]
        public string Latitude { get; set; }

        [XmlElement("longitude", IsNullable=true)]
        public string Longitude { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
