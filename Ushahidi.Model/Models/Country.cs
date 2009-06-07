using System.Xml.Serialization;

namespace Ushahidi.Model.Models
{
    [XmlRoot(Identifier)]
    public class Country : Common.MVC.Model
    {
        public const string Identifier = "country";

        [XmlElement("id")]
        public override int ID { get; set; }

        [XmlElement("upload")]
        public override bool Upload { get; set; }

        [XmlIgnore]
        public override string FilePath { get; set; }

        [XmlElement("iso")]
        public string ISO { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("capital", IsNullable = true)]
        public string Capital { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
