using System.Xml.Serialization;

namespace Ushahidi.Model.Models
{
    [XmlRoot("category")]
    public class Category : Model
    {
        [XmlElement("id")]
        public int ID { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("description", IsNullable = true)]
        public string Description { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
