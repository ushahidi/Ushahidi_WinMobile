using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ushahidi.Common.Extensions;

namespace Ushahidi.Common.Net
{
    public class PostData
    {
        public PostData(Encoding encoding)
        {
            Encoding = encoding;
        }

        public static readonly string Boundary = "AaB03x";
        public Encoding Encoding { get; private set; }
        private readonly List<ParamData> Params = new List<ParamData>();
        private readonly List<FileData> Files = new List<FileData>();

        public void Add(string name, string value)
        {
            if (string.IsNullOrEmpty(value) == false)
            {
                Params.Add(new ParamData { Name = name, Value = value });
            }
        }

        public void Add(string name, IEnumerable<string> values)
        {
            if (values != null && values.Count() > 0)
            {
                Params.Add(new ParamData { Name = name, Value = values.ToCSV() });
             }
        }

        public void Add(string name, IEnumerable<int> values)
        {
            if (values != null && values.Count() > 0)
            {
                Params.Add(new ParamData { Name = name, Value = values.ToCSV() });
            }
        }

        public void Add(string name, int value)
        {
            Params.Add(new ParamData { Name = name, Value = value.ToString() });
        }

        public void Add(string name, string filename, Image image)
        {
            if (string.IsNullOrEmpty(filename) == false && image != null)
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    image.Save(stream, ImageFormat.Jpeg);
                    Files.Add(new FileData { Name = name, FileName = filename, FileBytes = stream.ToArray() });
                }
            }
        }

        public byte[] ToBytes()
        {
            using (Stream stream = new MemoryStream())
            {
                string post = "";
                foreach (ParamData paramData in Params)
                {
                    StringBuilder data = new StringBuilder();
                    data.Append("--");
                    data.Append(Boundary);
                    data.Append("\r\n");
                    data.Append("Content-Disposition: form-data; name=\"");
                    data.Append(paramData.Name);
                    data.Append("\"");
                    data.Append("\r\n");
                    data.Append("\r\n");
                    data.Append(paramData.Value);
                    data.Append("\r\n");
                    post += data.ToString();
                    stream.Write(Encoding.GetBytes(data.ToString()), 0, data.Length);
                }
                foreach (FileData fileData in Files)
                {
                    StringBuilder data = new StringBuilder();
                    data.Append("--");
                    data.Append(Boundary);
                    data.Append("\r\n");
                    data.Append("Content-Disposition: form-data; name=\"");
                    data.Append(fileData.Name);
                    data.Append("\"");
                    data.Append("; filename=\"");
                    data.Append(fileData.FileName);
                    data.Append("\"");
                    data.Append("\r\n");
                    data.Append("Content-Type: application/octet-stream");
                    data.Append("\r\n");
                    data.Append("\r\n");
                    post += data.ToString();
                    stream.Write(Encoding.GetBytes(data.ToString()), 0, data.Length);
                    stream.Write(fileData.FileBytes, 0, fileData.FileBytes.Length);    
                }
                string footer = string.Format("--{0}--", Boundary);
                post += footer;
                Console.WriteLine(post);
                stream.Write(Encoding.GetBytes(footer), 0, footer.Length);
                stream.Position = 0;
                byte[] formData = new byte[stream.Length];
                stream.Read(formData, 0, formData.Length);
                return formData;
            }
        }

        struct FileData
        {
            public string Name { get; set; }
            public string FileName { get; set; }
            public byte[] FileBytes { get; set; }
        }

        struct ParamData
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }
    }
}
