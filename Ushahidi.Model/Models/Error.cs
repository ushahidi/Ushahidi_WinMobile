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

        [XmlIgnore]
        public CodeType CodeType
        {
            get { return (CodeType) Code;}
        }
    }

    public enum CodeType
    {
        NoError = 0,
        MissingParameter = 1,
        InvalidParameter = 2,
        FormPostFailed = 3,
        TaskNotFound = 999
    }
}
