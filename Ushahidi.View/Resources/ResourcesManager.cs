using System.Drawing;
using System.IO;
using System.Reflection;

namespace Ushahidi.View.Resources
{
    /// <summary>
    /// Manager for retrieving resource data
    /// </summary>
    public static class ResourcesManager
    {
        /// <summary>
        /// Load image resource by name
        /// </summary>
        /// <param name="resourceName">resource name</param>
        /// <returns>Image</returns>
        public static Image LoadImageResource(string resourceName)
        {
            foreach (string resource in Assembly.GetExecutingAssembly().GetManifestResourceNames())
            {
                if (!resource.EndsWith(resourceName)) continue;
                using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
                {
                    if (stream != null)
                    {
                        return new Bitmap(stream);
                    }
                    break;
                }
            }
            return null;
        }
    }
}
