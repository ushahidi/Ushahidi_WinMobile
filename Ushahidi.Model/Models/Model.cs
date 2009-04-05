using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Ushahidi.Common.Logging;

namespace Ushahidi.Model.Models
{
    /// <summary>
    /// Abstract Model
    /// </summary>
    public abstract class Model
    {
        /// <summary>
        /// Load XML into object
        /// </summary>
        /// <typeparam name="TModel">TModel</typeparam>
        /// <param name="filePath">filepath</param>
        /// <returns>TModel</returns>
        protected static TModel Load<TModel>(string filePath) where TModel : Model
        {
            if (File.Exists(filePath))
            {
                try
                {
                    using (StreamReader reader = File.OpenText(filePath))
                    {
                        return Parse<TModel>(reader.ReadToEnd());
                    }
                }
                catch (Exception ex)
                {
                    Log.Info("Model.Load", "Exception: {0}", ex.Message);
                }
            }
            return default(TModel);
        }

        protected static TModel Parse<TModel>(string xml) where TModel : Model
        {
            try
            {
                UTF8Encoding encoding = new UTF8Encoding();
                XmlSerializer serializer = new XmlSerializer(typeof (TModel));
                using (MemoryStream memoryStream = new MemoryStream(encoding.GetBytes(xml)))
                {
                    using (new XmlTextWriter(memoryStream, Encoding.UTF8))
                    {
                        return (TModel) serializer.Deserialize(memoryStream);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Info("Model.Load", "Exception: {0}", ex.Message);
            }
            return default(TModel);
        }

        protected static bool Save<TModel>(TModel model, string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    using (MemoryStream stream = new MemoryStream())
                    {
                        UTF8Encoding encoding = new UTF8Encoding();
                        XmlSerializer serializer = new XmlSerializer(typeof (TModel));
                        using (XmlTextWriter xmlTextWriter = new XmlTextWriter(stream, Encoding.UTF8))
                        {
                            serializer.Serialize(xmlTextWriter, model);
                            using (MemoryStream writeStream = (MemoryStream) xmlTextWriter.BaseStream)
                            {
                                Byte[] data = writeStream.ToArray();
                                string xmlString = encoding.GetString(data, 0, data.Length);
                                writer.WriteLine(xmlString);
                            }
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.Exception("Model.Save", "Exception {0} {1}", typeof(TModel), ex.Message);
            }
            return false;
        }
    }
}
