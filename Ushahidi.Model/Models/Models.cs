using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Ushahidi.Common.Logging;

namespace Ushahidi.Model.Models
{
    /// <summary>
    /// Abstract Models
    /// </summary>
    /// <typeparam name="TModel">Model</typeparam>
    public abstract class Models<TModel> : BindingList<TModel> where TModel : Model
    {
        /// <summary>
        /// Load
        /// </summary>
        /// <typeparam name="TModels">Models</typeparam>
        /// <param name="filePath">xml file path</param>
        /// <returns>TModels</returns>
        protected static TModels Load<TModels>(string filePath) where TModels : Models<TModel>
        {
            if (File.Exists(filePath))
            {
                try
                {
                    using (StreamReader reader = File.OpenText(filePath))
                    {
                        UTF8Encoding encoding = new UTF8Encoding();
                        XmlSerializer serializer = new XmlSerializer(typeof (TModels), new[] {typeof (TModel)});
                        using (MemoryStream memoryStream = new MemoryStream(encoding.GetBytes(reader.ReadToEnd())))
                        {
                            using (new XmlTextWriter(memoryStream, Encoding.UTF8))
                            {
                                return (TModels) serializer.Deserialize(memoryStream);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.Info("Models.Load", "Exception {0} {1}", typeof(TModels), ex.Message);
                }
            }
            return default(TModels);
        }

        /// <summary>
        /// Save
        /// </summary>
        /// <typeparam name="TModels">Models</typeparam>
        /// <param name="models">models</param>
        /// <param name="filePath">xml file path</param>
        /// <returns>true, if successful</returns>
        protected static bool Save<TModels>(TModels models, string filePath) where TModels : Models<TModel>
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    using (MemoryStream stream = new MemoryStream())
                    {
                        UTF8Encoding encoding = new UTF8Encoding();
                        XmlSerializer serializer = new XmlSerializer(typeof(TModels), new[] { typeof(TModel) });
                        using (XmlTextWriter xmlTextWriter = new XmlTextWriter(stream, Encoding.UTF8))
                        {
                            serializer.Serialize(xmlTextWriter, models);
                            using (MemoryStream writeStream = (MemoryStream)xmlTextWriter.BaseStream)
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
                Log.Exception("Models.Save", "Exception {0} {1}", typeof(TModels), ex.Message);
            }
            return false;
        }
    }
}
