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
        private static string TokenString { get; set; }
        private static DateTime TokenDateTime { get; set; }
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
                    Log.Exception("TokenService.GetToken", "Exception: {0}", ex);
                    TokenDateTime = DateTime.MinValue;
                    TokenString = null;
                }    
            }
            Log.Info("TokenService.GetToken({0}, {1}) = {2}", username, password, TokenString);
            return TokenString;
        }
    }
}
