using System;
using System.Xml.Serialization;
using Ushahidi.Common.Extensions;

namespace Ushahidi.Model.Models
{
    [Serializable]
    [XmlType(Identifier)]
    public class Category : Common.MVC.Model
    {
        public const string Identifier = "category";
        
        [XmlElement("id")]
        public override int ID { get; set; }

        [XmlElement("upload")]
        public override bool Upload { get; set; }

        [XmlElement("title")]
        public string Title
        {
            get { return _Title; }
            set { _Title = value.ToTitleCase(); }
        }private string _Title;

        [XmlElement("description")]
        public string Description { get; set; }

        public override string ToString()
        {
            return Title;
        }
        public static Category Parse(string xml)
        {
            return Parse<Category>(xml);
        }

        public static Category Load(string filePath)
        {
            return Load<Category>(filePath);
        }
    }
}
