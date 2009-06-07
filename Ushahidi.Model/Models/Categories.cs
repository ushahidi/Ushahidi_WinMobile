using System.Xml.Serialization;
using Ushahidi.Common.MVC;

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
