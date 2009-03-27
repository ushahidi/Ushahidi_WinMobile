using System.Xml.Serialization;

namespace Ushahidi.Model.Models
{
    [XmlRoot("payload")]
    public class Categories : Models
    {
        [XmlArray("categories")]
        [XmlArrayItem("category", typeof(Category))]
        public Category[] Items;

        public static Categories Load(string filePath)
        {
            return Load<Categories>(filePath);
        }
    }
}
