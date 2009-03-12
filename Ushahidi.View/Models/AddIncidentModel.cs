using System;
using System.Drawing;

namespace Ushahidi.View.Models
{
    /// <summary>
    /// Add incident model
    /// </summary>
    public class AddIncidentModel : BaseModel
    {
        /// <summary>
        /// Incident title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Incident date
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Incident type
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Incident type
        /// </summary>
        public string Locale { get; set; }

        /// <summary>
        /// Incident description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Incident images
        /// </summary>
        public Image[] Images { get; set; }

    }
}
