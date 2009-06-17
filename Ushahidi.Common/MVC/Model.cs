using System;
using System.IO;
using System.Text;
using System.Xml;
using Ushahidi.Common.Logging;
using System.Xml.Serialization;

namespace Ushahidi.Common.MVC
{
    /// <summary>
    /// Model
    /// </summary>
    public abstract class Model : IModel
    {
        [XmlElement("id")]
        public int ID { get; set; }

        [XmlElement("upload")]
        public bool Upload
        {
            get { return _Upload; }
            set
            {
                //if (_Upload && value == false)
                //{
                //    FileInfo fileInfo = new FileInfo(FilePath);
                //    fileInfo.MoveTo(string.Format("{0}.uploaded", FilePath));
                //}
                _Upload = value;
            }
        }private bool _Upload = false;

        [XmlIgnore]
        public string FilePath { get; set; }

        /// <summary>
        /// Load XML into object
        /// </summary>
        /// <typeparam name="TModel">TModel</typeparam>
        /// <param name="filePath">filepath</param>
        /// <returns>TModel</returns>
        public static TModel Load<TModel>(string filePath) where TModel : Model
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
                    Log.Info("Model.Load", "Exception: {0} {1}", typeof(TModel), ex.Message);
                }
            }
            return default(TModel);
        }

        public static TModel Parse<TModel>(string xml) where TModel : Model
        {
            Log.Info("Model.Parse", xml);
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(TModel));
                using (MemoryStream memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
                {
                    using (new XmlTextWriter(memoryStream, Encoding.UTF8))
                    {
                        object model = serializer.Deserialize(memoryStream);
                        return (TModel)model;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Info("Model.Parse", "Exception: {0} {1}", typeof(TModel), ex.Message);
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
                        XmlSerializer serializer = new XmlSerializer(typeof(TModel));
                        using (XmlTextWriter xmlTextWriter = new XmlTextWriter(stream, Encoding.UTF8))
                        {
                            serializer.Serialize(xmlTextWriter, model);
                            using (MemoryStream writeStream = (MemoryStream)xmlTextWriter.BaseStream)
                            {
                                Byte[] data = writeStream.ToArray();
                                string xmlString = Encoding.UTF8.GetString(data, 0, data.Length);
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

        /// <summary>
        /// Delete Model
        /// </summary>
        /// <returns>true, if successful</returns>
        public bool Delete()
        {
            if (File.Exists(FilePath))
            {
                File.Delete(FilePath);
                return true;
            }
            return false;
        }

        public virtual void Dispose() { }
    }
}
