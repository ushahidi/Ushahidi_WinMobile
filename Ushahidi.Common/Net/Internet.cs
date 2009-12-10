using System;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using Ushahidi.Common.Logging;

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
            get
            {
                if (_TestURL == null)
                {
                    _TestURL = "http://www.google.com";
                }
                return _TestURL;
            }
            set { _TestURL = value; }
        }

        private static string _TestURL;

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
                ServicePointManager.CertificatePolicy = AcceptAllCertificatePolicy();
                request.KeepAlive = false;
                using(HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    return response.StatusCode == HttpStatusCode.OK;    
                }
            }
            catch (Exception ex)
            {
                Log.Exception("Internet.HasInternetConnection", "Exception: {0}", ex);
                return false;
            }
        }

        public static AcceptAllCertificatePolicy AcceptAllCertificatePolicy()
        {
            return new AcceptAllCertificatePolicy();
        }
        
    }

    public class AcceptAllCertificatePolicy : ICertificatePolicy
    {
        public bool CheckValidationResult(ServicePoint point, X509Certificate certificate, WebRequest request, int certProb)
        {
            return true;
        }
    }
}
