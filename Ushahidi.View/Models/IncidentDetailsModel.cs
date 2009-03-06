using System;
using System.Drawing;

namespace Ushahidi.View.Models
{
    /// <summary>
    /// Incident details model
    /// </summary>
    public class IncidentDetailsModel : BaseModel
    {
        /// <summary>
        /// Incident title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Incident location
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Incident date
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Incident description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Incident imagess
        /// </summary>
        public Image [] Images = new Image[0];

        /// <summary>
        /// Incident verified?
        /// </summary>
        public bool Verified { get; set; }

        /// <summary>
        /// Incident link count
        /// </summary>
        public int LinkCount { get; set; }

        /// <summary>
        /// Incident response count
        /// </summary>
        public int ResponseCount { get; set; }

        /// <summary>
        /// Incident contributor count
        /// </summary>
        public int ContributorCount { get; set; }
    }
}
