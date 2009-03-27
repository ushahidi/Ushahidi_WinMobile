using System.Xml;

namespace Ushahidi.Model.Models
{
    /// <summary>
    /// Abstract Models
    /// </summary>
    public abstract class Models
    {
        /// <summary>
        /// Generic Load
        /// </summary>
        /// <typeparam name="TModels">Models Type</typeparam>
        /// <param name="filePath">xml file path</param>
        /// <returns>TModels</returns>
        protected static TModels Load<TModels>(string filePath) where TModels : Models
        {
            using (XmlReader reader = XmlReader.Create(filePath))
            {
                if (reader.ReadToDescendant("payload"))
                {
                    return Serializer.Deserialize<TModels>(reader.ReadOuterXml());
                }
            }
            return default(TModels);
        }

        public bool Save(string filePath)
        {

            return true;
        }
    }
}
