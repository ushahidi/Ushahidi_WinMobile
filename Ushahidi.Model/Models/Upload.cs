using System.Collections.Generic;
using System.Xml.Serialization;

namespace Ushahidi.Model.Models
{
    [XmlRoot("upload")]
    public class Upload : Model
    {
        [XmlElement("id")]
        public int ID { get; set; }

        [XmlArray("mediaItems", IsNullable = true)]
        [XmlArrayItem("media", Type = typeof(Media))]
        public Media[] MediaItems
        {
            get { return _MediaItems.ToArray(); }
            set
            {
                _MediaItems.Clear();
                if (value != null)
                {
                    _MediaItems.AddRange(value);
                }
            }
        }private readonly List<Media> _MediaItems = new List<Media>();

        public void Add(Media media)
        {
            _MediaItems.Add(media);
        }
    }
}
