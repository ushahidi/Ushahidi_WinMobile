using System.Xml.Serialization;

namespace Ushahidi.Model.Models
{
    [XmlRoot("payload")]
    public class Response : Model
    {
        [XmlElement("success")]
        public bool Success { get; set; }

        public static Response Parse(string xml)
        {
            return Parse<Response>(xml);
        }
    }
}
