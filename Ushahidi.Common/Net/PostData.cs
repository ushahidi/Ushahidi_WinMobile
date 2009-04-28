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

        public Encoding Encoding { get; private  set;}
        public static readonly string boundary = "AaB03x";
        
        private readonly Dictionary<string, string> _PostData = new Dictionary<string, string>();
        private readonly Dictionary<string, string> _FileNames = new Dictionary<string, string>();
        private readonly Dictionary<string, byte[]> _Files = new Dictionary<string, byte[]>();

        public void Add(string key, string value)
        {
            if (string.IsNullOrEmpty(value) == false)
            {
                _PostData.Add(key, value);
            }
        }

        public void Add(string key, IEnumerable<string> values)
        {
            if (values != null && values.Count() > 0)
            {
                _PostData.Add(key, values.ToCSV());
            }
        }

        public void Add(string key, IEnumerable<int> values)
        {
            if (values != null && values.Count() > 0)
            {
                _PostData.Add(key, values.ToCSV());
            }
        }

        public void Add(string key, int value)
        {
            _PostData.Add(key, value.ToString());
        }

        public void Add(string key, string filename, byte[] data)
        {
            if (string.IsNullOrEmpty(filename) == false && data != null)
            {
                _Files.Add(key, data);
                _FileNames.Add(key, filename);
            }
        }

        public void Add(string key, string filename, Image image)
        {
            if (string.IsNullOrEmpty(filename) == false && image != null)
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    image.Save(stream, ImageFormat.Jpeg);
                    _Files.Add(key, stream.ToArray());
                    _FileNames.Add(key, filename);
                }
            }
        }

        public byte[] ToUrlEncodedData()
        {
            StringBuilder data = new StringBuilder();
            string blankOrAmpersand = string.Empty;
            foreach(string key in _PostData.Keys)
            {
                string value = HttpUtility.UrlEncode(_PostData[key]);
                data.AppendFormat("{0}{1}={2}", blankOrAmpersand, key, value);
                blankOrAmpersand = "&";
            }
            return Encoding.GetBytes(data.ToString());
        }

        public byte[] ToOctetStreamData()
        {
            StringBuilder data = new StringBuilder();
            foreach (string key in _PostData.Keys)
            {            
                data.AppendLine(string.Format("Content-Disposition: form-data; name=\"{0}\"", key));
                data.AppendLine();
                data.AppendLine(_PostData[key]);
            }
            foreach (string key in _Files.Keys)
            {
                data.AppendLine(string.Format("Content-Disposition: file; name=\"{0}\"; filename=\"{1}\"", key, _FileNames[key]));
                data.AppendLine("Content-Type: application/octet-stream");
                data.AppendLine();
                data.AppendLine(_Files[key].ToString());
            }
            data.AppendLine("--" + boundary + "--");
            return Encoding.GetBytes(data.ToString());
        }

        public new string ToString()
        {
            StringBuilder data = new StringBuilder();
            string blankOrAmpersand = string.Empty;
            foreach (string key in _PostData.Keys)
            {
                string value = HttpUtility.UrlEncode(_PostData[key]);
                data.AppendFormat("{0}{1}={2}", blankOrAmpersand, key, value);
                blankOrAmpersand = "&";
            }
            return data.ToString();
        }
    }
}
