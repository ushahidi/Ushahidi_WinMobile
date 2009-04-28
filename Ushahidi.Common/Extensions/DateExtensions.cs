using System;
using System.Globalization;

namespace Ushahidi.Common.Extensions
{
    public static class DateExtensions
    {
        public static DateTime ToDateTime(this string dateAsString)
        {
            return string.IsNullOrEmpty(dateAsString) ? DateTime.MinValue : DateTime.Parse(dateAsString);
        }

        public static DateTime ToDateTime(this string dateAsString, string format)
        {
            return string.IsNullOrEmpty(dateAsString) ? DateTime.MinValue : DateTime.ParseExact(dateAsString, format, CultureInfo.InvariantCulture);
        }

        public static DateTime ToDateTime(this string dateAsString, params string [] formats)
        {
            return string.IsNullOrEmpty(dateAsString) ? DateTime.MinValue : DateTime.ParseExact(dateAsString, formats, CultureInfo.InvariantCulture, DateTimeStyles.None);
        }
    }
}
