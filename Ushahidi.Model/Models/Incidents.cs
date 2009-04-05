using System;
using System.Xml;
using System.Xml.Serialization;
using Ushahidi.Common.Logging;

namespace Ushahidi.Model.Models
{
    [XmlRoot("incidents")]
    [XmlInclude(typeof(Incident))]
    public class Incidents : Models<Incident>
    {
        /// <summary>
        /// Load Incidents from xml file
        /// </summary>
        /// <param name="filePath">xml file path</param>
        /// <returns>Incidents</returns>
        public static Incidents Load(string filePath)
        {
            //return Load<Incidents>(filePath);
            //The <incident0>, <incident1>,... wrapper prevents XmlSerialization, so we need to manually parse the XML
            //TODO Remove the following code once XML Serialization is working
            Incidents incidents = new Incidents();
            Incident incident = null;
            using(XmlReader reader = XmlReader.Create(filePath))
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.LocalName == "incident")
                    {
                        incident = Incident.Parse(reader.ReadOuterXml());
                        if (incident != null)
                        {
                            incidents.Add(incident);
                        }
                    }
                    if (reader.NodeType == XmlNodeType.Element && reader.LocalName == "media")
                    {
                        Media media = new Media();
                        using (XmlReader inner = reader.ReadSubtree())
                        {
                            while (inner.Read())
                            {
                                if (reader.NodeType == XmlNodeType.Element && reader.LocalName.StartsWith("mediaitem"))
                                {
                                    media = new Media();
                                    if (incident != null)
                                    {
                                        incident.AddMedia(media);
                                    }
                                }
                                else if (reader.NodeType == XmlNodeType.Element && reader.LocalName == "id")
                                {
                                    media.ID = Convert.ToInt32(inner.ReadString());
                                }
                                else if (reader.NodeType == XmlNodeType.Element && reader.LocalName == "type")
                                {
                                    media.Type = Convert.ToInt32(inner.ReadString());
                                }
                                else if (reader.NodeType == XmlNodeType.Element && reader.LocalName == "title")
                                {
                                    media.Title = inner.ReadString();
                                }
                                else if (reader.NodeType == XmlNodeType.Element && reader.LocalName == "link")
                                {
                                    media.OriginalFileName = inner.ReadString();
                                }
                                else if (reader.NodeType == XmlNodeType.Element && reader.LocalName == "thumb")
                                {
                                    media.ThumbnailFileName = inner.ReadString();
                                }
                            }
                        }
                    }
                }
            }
            return incidents;
        }
    }
}
