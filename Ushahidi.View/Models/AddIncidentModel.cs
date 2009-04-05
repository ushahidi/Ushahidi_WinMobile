using System;
using System.Drawing;
using Ushahidi.Common.Extensions;
using Ushahidi.Model;
using Ushahidi.Model.Models;

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
        /// Incident description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Incident date
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Incident type
        /// </summary>
        public Category Category { get; set; }

        /// <summary>
        /// Incident type
        /// </summary>
        public Locale Locale { get; set; }

        /// <summary>
        /// Latitude
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Longitude
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Incident images
        /// </summary>
        public Image[] Images { get; set; }

        /// <summary>
        /// Categories
        /// </summary>
        public Categories Categories
        {
            get { return DataManager.Categories; }
        }

        /// <summary>
        /// Locales
        /// </summary>
        public Locales Locales
        {
            get { return DataManager.Locales; }
        }

        /// <summary>
        /// Save model
        /// </summary>
        /// <returns></returns>
        public override bool Save()
        {
            if (Title.HasText() && Description.HasText() && Locale != null && Category != null && Date != DateTime.MinValue)
            {
                Incident incident = new Incident
                {
                    ID = (-1),
                    Date = Date,
                    Title = Title,
                    Description = Description,
                    CategoryTitle = Category.Title,
                    CategoryID = Category.ID,
                    LocationName = Locale.Name,
                    LocationID = Locale.ID,
                    Longitude = Longitude,
                    Latitude = Latitude
                };
                return DataManager.AddIncident(incident);
            }
            return false;
        }
    }
}
