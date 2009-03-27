using System.Xml.Serialization;

namespace Ushahidi.Model.Models
{
    [XmlRoot("category")]
    public class Category
    {
        [XmlElement("id")]
        public int ID { get; set; }

        [XmlElement("category_title")]
        public string Title { get; set; }

        [XmlElement("category_description")]
        public string Description { get; set; }

        [XmlElement("category_color")]
        public string Color { get; set; }
    }
}
