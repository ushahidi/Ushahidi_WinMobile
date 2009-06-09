using System;
using System.Xml.Serialization;

namespace Ushahidi.Common.MVC
{
    /// <summary>
    /// Model interface
    /// </summary>
    public interface IModel : IDisposable
    {
        int ID { get; set; }

        [XmlElement("upload")]
        bool Upload { get; set; }

        [XmlIgnore]
        string FilePath { get; set; }
    }
}
