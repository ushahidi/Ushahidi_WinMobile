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
    }
}
