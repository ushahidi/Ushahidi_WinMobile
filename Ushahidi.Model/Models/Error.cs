using System.Xml.Serialization;

namespace Ushahidi.Model.Models
{
    [XmlRoot("error")]
    public class Error
    {
        /// <summary>
        /// Error Code
        /// </summary>
        [XmlElement("code")]
        public int Code { get; set; }

        /// <summary>
        /// Error Message
        /// </summary>
        [XmlElement("message")]
        public string Message { get; set; }
    }
}
