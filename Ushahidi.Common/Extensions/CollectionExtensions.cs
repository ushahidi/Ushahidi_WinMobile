using System;
using System.Collections.Generic;
using System.Linq;

namespace Ushahidi.Common.Extensions
{
    public static class CollectionExtensions
    {
        public static string ToCSV(this IEnumerable<string> items)
        {
            return String.Join(",", items.ToArray());
        }

        public static string ToCSV(this IEnumerable<int> items)
        {
            return String.Join(",", items.Select(i => i.ToString()).ToArray());
        }
    }
}
