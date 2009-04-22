using System.Xml.Serialization;

namespace Ushahidi.Model.Models
{
    [XmlRoot("incidents")]
    [XmlInclude(typeof(Incident))]
    public class Incidents : Models<Incident>
    {
        /// <summary>
        /// Load Incidents from xml file
        /// </summary>
        /// <param name="filePath">xml file path</param>
        /// <returns>Incidents</returns>
        public static Incidents Load(string filePath)
        {
            return Load<Incidents>(filePath);
        }
    }
}
