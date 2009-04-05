using System.Xml.Serialization;

namespace Ushahidi.Model.Models
{
    [XmlRoot("country")]
    public class Country : Model
    {
        [XmlElement("id")]
        public int ID { get; set; }

        [XmlElement("iso")]
        public string ISO { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("capital")]
        public string Capital { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
