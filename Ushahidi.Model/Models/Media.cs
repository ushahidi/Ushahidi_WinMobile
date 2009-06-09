using System;
using System.Xml.Serialization;

namespace Ushahidi.Model.Models
{
    /// <summary>
    /// <media>
    ///     <id>1</id>
    ///     <title>photograph</title>
    ///     <type>1</type>
    ///     <link>3_1_1231886194.jpg</link>
    ///     <thumb>3_1_1231886194_t.jpg</thumb>
    ///</media>
    /// </summary>
    [Serializable]
    [XmlType(Identifier)]
    public class Media : Common.MVC.Model
    {
        public const string Identifier = "media";
        
        [XmlElement("id")]
        public override int ID { get; set; }

        [XmlElement("upload")]
        public override bool Upload { get; set; }

        [XmlElement("type")]
        public int Type { get; set; }

        [XmlElement("link")]
        public string Link { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("thumb")]
        public string ThumbnailLink { get; set; }

        [XmlIgnore]
        public MediaType MediaType
        {
            get { return (MediaType)Type; }
        }

        [XmlIgnore]
        public bool IsPhoto
        {
            get { return MediaType == MediaType.Photo; }
        }

        [XmlIgnore]
        public bool IsNews
        {
            get { return MediaType == MediaType.News; }
        }

        [XmlIgnore]
        public bool IsAudio
        {
            get { return MediaType == MediaType.Audio; }
        }

        [XmlIgnore]
        public bool IsVideo
        {
            get { return MediaType == MediaType.Video; }
        }

        public override string ToString()
        {
            return string.Format("{0}", Link).Trim();
        }

        public static Media Parse(string xml)
        {
            return Parse<Media>(xml);
        }

        public static Media New(string imageName, string thumbnailName)
        {
            return new Media
            {
              ID = (-1),
              Type = ((int) MediaType.Photo),
              Link = imageName,
              ThumbnailLink = thumbnailName,
              Upload = true
            };
        }
    }
}
