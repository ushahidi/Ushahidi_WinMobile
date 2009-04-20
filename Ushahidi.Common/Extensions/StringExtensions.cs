using System;
using System.Globalization;

namespace Ushahidi.Common.Extensions
{
    /// <summary>
    /// String extensions
    /// </summary>
    public static class StringExtensions
    {
        public static bool HasText(this string text)
        {
            return string.IsNullOrEmpty(text) == false;
        }

        private static readonly CultureInfo Culture = CultureInfo.InvariantCulture;
        private static readonly string[] DateTimeFormats = {"yyyy-MM-dd hh:mm:ss", //2009-01-13 01:00:00
                                                            "yyyy-MM-ddTHH:mm:ss.fffffff", //2008-04-28T17:37:33.4737536
                                                            "yyyy-MM-ddTHH:mm:ss.ffffff", //2008-04-28T17:37:33.473753
                                                            "yyyy-MM-ddTHH:mm:ss", //2008-04-28T17:37:33
                                                            "yyyy:MM:dd HH:mm:ss", //2008:03:09 09:09:56
                                                            "yyyy:M:d h:m:ss tt" //2008:8:9 4:7:36 AM
                                                           };
        public static DateTime ToDatetime(this string text)
        {
            if (string.IsNullOrEmpty(text) == false)
            {
                try
                {
                    return DateTime.ParseExact(text, DateTimeFormats, Culture, DateTimeStyles.AllowWhiteSpaces);
                }
                catch
                {
                    try
                    {
                        return DateTime.Parse(text);
                    }
                    catch 
                    {
                        return DateTime.MinValue;
                    }
                }
            }
            return DateTime.MinValue;
        }
    }
}
