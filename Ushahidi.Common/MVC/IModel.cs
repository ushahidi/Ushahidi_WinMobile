using System;
using System.Xml.Serialization;

namespace Ushahidi.Common.MVC
{
    /// <summary>
    /// Model interface
    /// </summary>
    public interface IModel : IDisposable
    {
        /// <summary>
        /// Save model
        /// </summary>
        /// <returns>true, if save successful</returns>
        bool Save();

        bool Save(string filePath);

        int ID { get; set; }

        [XmlElement("upload")]
        bool Upload { get; set; }

        [XmlIgnore]
        string FilePath { get; set; }
    }
}
