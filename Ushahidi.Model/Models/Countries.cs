using System.Xml.Serialization;

namespace Ushahidi.Model.Models
{
    [XmlRoot("payload")]
    public class Countries : Models
    { 
        [XmlArray("countries")]
        [XmlArrayItem("country", typeof (Country))] 
        public Country[] Items;

        public static Countries Load(string filePath)
        {
            return Load<Countries>(filePath);
        }
    }
}
