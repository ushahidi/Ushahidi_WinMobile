using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Ushahidi.Common.Logging;

namespace Ushahidi.Model
{
    /// <summary>
    /// Serializer class for serialize and deserialize object to and from xml
    /// </summary>
    public static class Serializer
    {
        /// <summary>
        /// UTF8 Encoding
        /// </summary>
        private static readonly UTF8Encoding UTF8 = new UTF8Encoding();

        /// <summary>
        /// Deserialize XML into object
        /// </summary>
        /// <typeparam name="TModel">TModel</typeparam>
        /// <param name="xml">xml</param>
        /// <returns>TModel</returns>
        public static TModel Deserialize<TModel>(string xml)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(TModel));
                using (MemoryStream memoryStream = new MemoryStream(StringToUTF8ByteArray(xml)))
                {
                    using (new XmlTextWriter(memoryStream, Encoding.UTF8))
                    {
                        return (TModel)serializer.Deserialize(memoryStream);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Exception("Serializer.Deserialize", "{0} {1}", ex.Message, xml);
                return default(TModel);
            }
        }

        /// <summary>
        /// Serialize object to XML
        /// </summary>
        /// <typeparam name="TModel">TModel</typeparam>
        /// <param name="model">model</param>
        /// <returns>XML as string</returns>
        public static string Serialize<TModel>(TModel model)
        {
            try
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    XmlSerializer serializer = new XmlSerializer(typeof (TModel));
                    using (XmlTextWriter xmlTextWriter = new XmlTextWriter(stream, Encoding.UTF8))
                    {
                        serializer.Serialize(xmlTextWriter, model);
                        using (MemoryStream writeStream = (MemoryStream)xmlTextWriter.BaseStream)
                        {
                            return UTF8ByteArrayToString(writeStream.ToArray());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Exception("Serializer.Serialize", "{0} {1}", typeof(TModel), ex.Message);
                return null;
            }
        } 

        /// <summary>
        /// Convert UTF8 byte array to string
        /// </summary>
        private static String UTF8ByteArrayToString(Byte[] characters)
        {
            return UTF8.GetString(characters, 0, characters.Length);
        }

        /// <summary>
        /// Convert string to UTF8 byte array
        /// </summary>
        private static Byte[] StringToUTF8ByteArray(String xml)
        {
            return UTF8.GetBytes(xml);
        } 
    }
}
