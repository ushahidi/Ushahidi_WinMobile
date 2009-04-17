using System.Xml.Serialization;

namespace Ushahidi.Model.Models
{
    [XmlRoot("category")]
    public class Category : Model
    {
        [XmlElement("categoryid")]
        public int ID { get; set; }

        [XmlElement("categorytitle")]
        public string Title { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
