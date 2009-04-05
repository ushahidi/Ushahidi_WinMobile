using System.Xml.Serialization;

namespace Ushahidi.Model.Models
{
    [XmlRoot("categories")]
    [XmlInclude(typeof(Category))]
    public class Categories : Models<Category>
    {
        public static Categories Load(string filePath)
        {
            return Load<Categories>(filePath);
        }
    }
}
