using System.Xml.Serialization;

namespace Ushahidi.Model.Models
{
    [XmlRoot("locations")]
    [XmlInclude(typeof(Locale))]
    public class Locales : Models<Locale>
    {
        public static Locales Load(string filePath)
        {
            return Load<Locales>(filePath);
        }
    }
}
