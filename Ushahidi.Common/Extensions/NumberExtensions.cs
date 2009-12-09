using System;

namespace Ushahidi.Common.Extensions
{
    public static class NumberExtensions
    {
        public static bool AlmostEquals(this double double1, double double2)
        {
            return Math.Abs(double1 - double2) < double.Epsilon;
        }

        public static bool AlmostEquals(this double double1, double double2, double precision)
        {
            return Math.Abs(double1 - double2) <= precision;
        }
    }
}
