using System;
using System.Drawing;

namespace Ushahidi.View.Models
{
    public class Incident
    {
        public Incident() { }
        public Incident(string title, string description, string locale)
        {
            Title = title;
            Description = description;
            Locale = locale;
        }

        /// <summary>
        /// Incident title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Incident description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Incident location
        /// </summary>
        public string Locale { get; set; }

        /// <summary>
        /// Incident date
        /// </summary>
        public DateTime Date { get; set; }

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

        /// <summary>
        /// Incident image
        /// </summary>
        public Image Image { get; set; }
    }
}
