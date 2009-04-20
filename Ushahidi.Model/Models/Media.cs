using System;
using System.Drawing;
using System.Xml.Serialization;

namespace Ushahidi.Model.Models
{
    /// <summary>
    /// <media>
    ///     <mediaid>1</mediaid>
    ///     <mediatitle/>
    ///     <mediatype>1</mediatype>
    ///     <medialink>3_1_1231886194.jpg</medialink>
    ///     <mediathumb>3_1_1231886194_t.jpg</mediathumb>
    ///</media>
    /// </summary>
    [XmlRoot("media")]
    public class Media : Model, IDisposable
    {
        [XmlElement("mediaid")]
        public int ID { get; set; }

        [XmlElement("mediatitle", IsNullable = true)]
        public string Title { get; set; }

        [XmlElement("mediatype")]
        public int Type { get; set; }

        [XmlElement("medialink")]
        public string OriginalFileName { get; set; }

        [XmlElement("mediathumb")]
        public string ThumbnailFileName { get; set; }

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
