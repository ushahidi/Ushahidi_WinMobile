using Ushahidi.Common.MVC;

namespace Ushahidi.Model.Models
{
    /// <summary>
    /// Collection of Categories
    /// </summary>
    public class Categories : Models<Category>
    {
        /// <summary>
        /// Load Categories
        /// </summary>
        /// <param name="directory">directory</param>
        /// <returns>Collection of Categories</returns>
        public static Categories Load(string directory)
        {
            return Load<Categories>(directory);
        }

        /// <summary>
        /// Download Categories
        /// </summary>
        /// <param name="url">download url</param>
        /// <param name="directory">destination directory</param>
        /// <returns>Collection of Categories</returns>
        public static Categories Download(string url, string directory)
        {
            return Download<Categories>(url, directory, "category");
        }
    }
}
