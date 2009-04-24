using System.Xml.Serialization;
using Ushahidi.Common.Extensions;

namespace Ushahidi.Model.Models
{
    [XmlRoot("category")]
    public class Category : Model
    {
        public Category(){}
        public Category(int id, string title, string description)
        {
            ID = id;
            Title = title.ToTitleCase();
            Description = description;
        }

        [XmlElement("id")]
        public int ID { get; set; }

        [XmlElement("title")]
        public string Title
        {
            get { return _Title; }
            set { _Title = value.ToTitleCase(); }
        }private string _Title;

        [XmlElement("description", IsNullable = true)]
        public string Description { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
