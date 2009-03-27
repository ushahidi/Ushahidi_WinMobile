using System.Xml.Serialization;

namespace Ushahidi.Model.Models
{
    [XmlRoot("payload")]
    public class Locales : Models
    {
        [XmlArray("locations")]
        [XmlArrayItem("location", typeof(Locale))]
        public Locale[] Items;

        public static Locales Load(string filePath)
        {
            return Load<Locales>(filePath);
        }
    }
}
