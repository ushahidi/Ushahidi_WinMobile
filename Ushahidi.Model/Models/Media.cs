using System;
using System.Drawing;
using System.Xml.Serialization;

namespace Ushahidi.Model.Models
{
    /// <summary>
    /// <media>
    ///     <id>1</id>
    ///     <title/>
    ///     <type>1</type>
    ///     <link>3_1_1231886194.jpg</link>
    ///     <thumb>3_1_1231886194_t.jpg</thumb>
    ///</media>
    /// </summary>
    [XmlRoot("media")]
    public class Media : Model, IDisposable
    {
        [XmlElement("id")]
        public int ID { get; set; }

        [XmlElement("title", IsNullable = true)]
        public string Title { get; set; }

        [XmlElement("type")]
        public int Type { get; set; }

        [XmlElement("link")]
        public string OriginalFileName { get; set; }

        [XmlElement("thumb", IsNullable = true)]
        public string ThumbnailFileName { get; set; }

        [XmlIgnore]
        public MediaType MediaType
        {
            get { return (MediaType)Type; }
        }

        public override string ToString()
        {
            return string.Format("{0}", OriginalFileName).Trim();
        }

        [XmlIgnore]
        public Image Original
        {
            get
            {
                if (_Original == null)
                {
                    _Original = DataManager.LoadImage(OriginalFileName);
                }
                return _Original;
            }
        }private Image _Original;

        [XmlIgnore]
        public Image Thumbnail
        {
            get
            {
                if (_Thumbnail == null)
                {
                    _Thumbnail = DataManager.LoadImage(ThumbnailFileName);
                }
                return _Thumbnail;
            }
        }private Image _Thumbnail;

        public void Dispose()
        {
            if (_Thumbnail != null)
            {
                _Thumbnail.Dispose();
                _Thumbnail = null;
            }
            if (_Original != null)
            {
                _Original.Dispose();
                _Original = null;
            }
        }

        public static Media Parse(string xml)
        {
            return Parse<Media>(xml);
        }

    }
}
