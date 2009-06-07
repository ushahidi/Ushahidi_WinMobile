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


        public static T ItemAtIndex<T>(this object[] parameters, int index)
        {
            if (parameters != null && parameters.Length > index && parameters[index] != null)
            {
                return (T)parameters[index];
            }
            return default(T);
        }

        public static bool Exists(this object[] parameters, int index)
        {
            return parameters != null && parameters.Length > index && parameters[index] != null;
        }
    }
}
