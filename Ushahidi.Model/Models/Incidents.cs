using Ushahidi.Common.MVC;

namespace Ushahidi.Model.Models
{
    /// <summary>
    /// Collection of Incidentss
    /// </summary>
    public class Incidents : Models<Incident>
    {
        /// <summary>
        /// Load Incidents
        /// </summary>
        /// <param name="directory">directory</param>
        /// <returns>Collection of Incidents</returns>
        public static Incidents Load(string directory)
        {
            return Load<Incidents>(directory);
        }

        /// <summary>
        /// Download Incidents
        /// </summary>
        /// <param name="url">download url</param>
        /// <param name="directory">destination directory</param>
        /// <returns>Collection of Incidents</returns>
        public static Incidents Download(string url, string directory)
        {
            return Download<Incidents>(url, directory, "incident");
        }

        /// <summary>
        /// Sort Incidents By Date
        /// </summary>
        public void Sort()
        {
            Sort((a, b) => a.Date.CompareTo(b.Date));
        }
    }
}
