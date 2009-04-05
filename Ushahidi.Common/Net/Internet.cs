using System.Net;

namespace Ushahidi.Common.Net
{
    /// <summary>
    /// Internet Utility
    /// </summary>
    public static class Internet
    {
        /// <summary>
        /// Test URL
        /// </summary>
        public static string TestURL
        {
            set { _TestURL = value; }
            get
            {
                if (_TestURL == null)
                {
                    _TestURL = "http://www.google.com";
                }
                return _TestURL;
            }
        }private static string _TestURL;

        /// <summary>
        /// Has network connection?
        /// </summary>
        /// <returns></returns>
        public static bool HasNetworkConnection()
        {
            try
            {
                string hostName= Dns.GetHostName();
                IPHostEntry hostEntry = Dns.GetHostEntry(hostName);
                return hostEntry.AddressList[0] != IPAddress.Parse("127.0.0.1");
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Has internet connection?
        /// </summary>
        /// <returns>true, if connected to internet</returns>
        public static bool HasInternetConnection()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(TestURL);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                return response.StatusCode == HttpStatusCode.OK;
            }
            catch
            {
                return false;
            }
        }
    }
}
