using Ushahidi.Common.MVC;

namespace Ushahidi.Model.Models
{
    /// <summary>
    /// Collection of Countries
    /// </summary>
    public class Countries : Models<Country>
    {
        /// <summary>
        /// Load Countries
        /// </summary>
        /// <param name="directory">directory</param>
        /// <returns>Collection of Countries</returns>
        public static Countries Load(string directory)
        {
            return Load<Countries>(directory);
        }

        /// <summary>
        /// Download Countries
        /// </summary>
        /// <param name="url">download url</param>
        /// <param name="directory">destination directory</param>
        /// <returns>Collection of Countries</returns>
        public static Countries Download(string url, string directory)
        {
            return Download<Countries>(url, directory, "country");
        }
    }
}
