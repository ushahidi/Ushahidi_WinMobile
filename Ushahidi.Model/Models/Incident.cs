using System.Xml.Serialization;

namespace Ushahidi.Model.Models
{
    [XmlRoot("incident")]
    public class Incident
    {
        [XmlElement("incidentid")]
        public int ID { get; set; }

        [XmlElement("incidenttitle")]
        public string Title { get; set; }

        [XmlElement("incidentdescription")]
        public string Description { get; set; }

        [XmlElement("locationid")]
        public int LocationID { get; set; }

        [XmlElement("locationname")]
        public string LocationName { get; set; }

        [XmlElement("categoryid")]
        public int CategoryID { get; set; }

        [XmlElement("categorytitle")]
        public string CategoryTitle { get; set; }

        //public string[] media { get; set; }
    }
}
