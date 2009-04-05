using System.Xml.Serialization;

namespace Ushahidi.Model.Models
{
    [XmlRoot("category")]
    public class Category : Model
    {
        [XmlElement("id")]
        public int ID { get; set; }

        [XmlElement("category_title")]
        public string Title { get; set; }

        [XmlElement("category_description")]
        public string Description { get; set; }

        [XmlElement("category_color")]
        public string Color { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", Title, Description).TrimEnd();
        }
    }
}
