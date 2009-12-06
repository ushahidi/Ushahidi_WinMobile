using System;
using System.Net;
using Ushahidi.Common.Logging;
using Ushahidi.Map.Token.Staging;

namespace Ushahidi.Map
{
    /// <summary>
    /// Token Service
    /// </summary>
    public class TokenService
    {
        /// <summary>
        /// Token String
        /// </summary>
        private static string TokenString { get; set; }

        /// <summary>
        /// Token DateTime
        /// </summary>
        private static DateTime TokenDateTime { get; set; }

        /// <summary>
        /// Token Life
        /// </summary>
        private const int TokenMinutes = 120; 

        /// <summary>
        /// Get Token
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        /// <returns>security token</returns>
        public static string GetToken(string username, string password)
        {
            if (string.IsNullOrEmpty(TokenString) ||
                TokenDateTime == DateTime.MinValue ||
                DateTime.Now.Subtract(TokenDateTime).TotalMinutes > TokenMinutes)
            {
                Log.Info("TokenService.GetToken({0}, {1})", username, password);
                try
                {
                    CommonService commonService = new CommonService
                    {
                        Credentials = new NetworkCredential(username, password)
                    };
                    TokenSpecification tokenSpecification = new TokenSpecification
                    {
                        ClientIPAddress = "127.0.0.1",
                        TokenValidityDurationMinutes = TokenMinutes
                    };
                    TokenDateTime = DateTime.Now;
                    TokenString = commonService.GetClientToken(tokenSpecification);
                }
                catch (Exception ex)
                {
                    if (ex is WebException)
                    {
                        WebException webException = ex as WebException;
                        Log.Exception("TokenService.GetToken", "Status:{0} Message:{1}", webException.Status, webException.Message);
                    }
                    else
                    {
                        Log.Exception("TokenService.GetToken", "Exception: {0}", ex);    
                    }
                    TokenDateTime = DateTime.MinValue;
                    TokenString = null;
                }    
            }
            Log.Info("TokenService.GetToken({0}, {1}) = {2}", username, password, TokenString);
            return TokenString;
        }
    }
}
