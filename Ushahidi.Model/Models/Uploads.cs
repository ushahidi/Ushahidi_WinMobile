using System.Linq;
using System.Xml.Serialization;

namespace Ushahidi.Model.Models
{
    [XmlRoot("uploads")]
    [XmlInclude(typeof(Upload))]
    public class Uploads : Models<Upload>
    {
        public static Uploads Load(string filePath)
        {
            return Load<Uploads>(filePath);
        }

        public void Add(int id, Media media)
        {
            Upload upload = this.FirstOrDefault(u => u.ID == id);
            if (upload == null)
            {
                upload = new Upload {ID = id};
                Add(upload);
            }
            upload.Add(media);
        }

        public bool Save(string filePath)
        {
            return Save(this, filePath);
        }
    }
}
