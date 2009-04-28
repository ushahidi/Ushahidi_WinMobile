using System.Xml.Serialization;

namespace Ushahidi.Model.Models
{
    public class Payload
    {
        [XmlElement("success")]
        public bool Success { get; set; }
    }
}
