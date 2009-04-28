﻿using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Media> MediaItems { get; set; }

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
                    Categories = new[] {Category},
                    MediaItems = MediaItems.ToArray(),
                    Locale = Locale
                };
                return DataManager.AddIncident(incident);
            }
            return false;
        }
    }
}
