using Ushahidi.Common.MVC;

namespace Ushahidi.Model.Models
{
    /// <summary>
    /// Collection of Locales
    /// </summary>
    public class Locales : Models<Locale>
    {
        /// <summary>
        /// Load Locales
        /// </summary>
        /// <param name="directory">directory</param>
        /// <returns>Collection of Locales</returns>
        public static Locales Load(string directory)
        {
            return Load<Locales>(directory);
        }

        /// <summary>
        /// Download Countries
        /// </summary>
        /// <param name="url">download url</param>
        /// <param name="directory">destination directory</param>
        /// <returns>Collection of Locales</returns>
        public static Locales Download(string url, string directory)
        {
            return Download<Locales>(url, directory, "location");
        }
    }
}
