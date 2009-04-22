using System.Xml.Serialization;

namespace Ushahidi.Model.Models
{
    [XmlRoot("location")]
    public class Locale : Model
    {
        [XmlElement("id")]
        public int ID { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("country_id", IsNullable = true)]
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
