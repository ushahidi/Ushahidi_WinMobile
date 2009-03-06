using System;

namespace Ushahidi.Common.Extensions
{
    public static class DateExtensions
    {
        public static DateTime ToDateTime(this string dateAsString)
        {
            return string.IsNullOrEmpty(dateAsString) ? DateTime.MinValue : DateTime.Parse(dateAsString);
        }
    }
}
