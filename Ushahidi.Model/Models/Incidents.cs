using System.Xml.Serialization;

namespace Ushahidi.Model.Models
{
    [XmlRoot("payload")]
    public class Incidents : Models
    {
        [XmlArray("incidents")]
        [XmlArrayItem("incident", typeof(Incident))]
        public Incident[] Items;

        public static Incidents Load(string filePath)
        {
            return Load<Incidents>(filePath);
        }
    }
}
