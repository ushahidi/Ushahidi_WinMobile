using System.Xml.Serialization;

namespace Ushahidi.Model.Models
{
    /// <summary>
    /// <response><payload>
    /// <success>false</success>
    /// </payload>
    /// <error>
    /// <code>003</code>
    /// <message>Form Post Failed.</message>
    /// </error></response>
    /// </summary>
    [XmlRoot("response")]
    public class Response : Model
    {
        [XmlElement("payload", IsNullable = true)]
        public Payload Payload { get; set; }

        [XmlElement("error", IsNullable = true)]
        public Error Error { get; set; }
        
        [XmlIgnore]
        public bool Success
        {
            get { return Payload != null ? Payload.Success : false; }
        }

        [XmlIgnore]
        public string Message
        {
            get { return Error != null ? Error.Message : null; }
        }

        public static Response Parse(string xml)
        {
            return Parse<Response>(xml);
        }
    }
}
