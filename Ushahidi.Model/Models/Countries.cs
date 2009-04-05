using System.Xml.Serialization;

namespace Ushahidi.Model.Models
{
    [XmlRoot("countries")]
    [XmlInclude(typeof(Country))]
    public class Countries : Models<Country>
    {
        public static Countries Load(string filePath)
        {
            return Load<Countries>(filePath);
        }
    }
}
