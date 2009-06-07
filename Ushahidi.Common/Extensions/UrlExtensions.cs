using System;

namespace Ushahidi.Common.Extensions
{
    public static class UrlExtensions
    {
        public static string ToDomainOnlyPath(this string urlString)
        {
            Uri uri = new Uri(urlString);
            return uri.Host.Replace(".", "_").Replace("-", "_");
        }
    }
}
