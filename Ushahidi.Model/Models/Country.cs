using System.Xml.Serialization;

namespace Ushahidi.Model.Models
{
    [XmlRoot("country")]
    public class Country : Common.MVC.Model
    {
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
