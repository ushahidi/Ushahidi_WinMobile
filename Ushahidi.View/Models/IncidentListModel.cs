using System;
using Ushahidi.View.Resources;

namespace Ushahidi.View.Models
{
    public class IncidentListModel : BaseModel
    {
        public IncidentListModel()
        {
            Incidents[0] = new Incident("Uhuru fires still strong", "", "Uhuru, Kenya")
            {
               Image = ResourcesManager.LoadImageResource("ushahidi_fire.png"),
               ContributorCount = 2,
               Date = DateTime.Now,
               LinkCount = 1,
               ResponseCount = 1, 
               Verified = true
            };
            Incidents[1] = new Incident("Eastleigh Plane crash", "", "Nairobi, Kenya")
            {
               Image = ResourcesManager.LoadImageResource("ushahidi_plane.png"),
               ContributorCount = 2,
               Date = DateTime.Now,
               LinkCount = 7,
               ResponseCount = 4,
               Verified = false
            };
            Incidents[2] = new Incident("Kenyatta Pwr Failure", "", "Nairobi, Kenya")
            {
               Image = ResourcesManager.LoadImageResource("ushahidi_globe.png"),
               ContributorCount = 1,
               Date = DateTime.Now,
               LinkCount = 0,
               ResponseCount = 2,
               Verified = true
            };
            Incidents[3] = new Incident("Nairobi Protests", "", "Nairobi, Kenya")
            {
               Image = ResourcesManager.LoadImageResource("ushahidi_fire.png"),
               ContributorCount = 2,
               Date = DateTime.Now,
               LinkCount = 1,
               ResponseCount = 1, 
               Verified = true
            };
            Incidents[4] = new Incident("Uhuru fires still strong", "", "Uhuru, Kenya")
            {
                Image = ResourcesManager.LoadImageResource("ushahidi_fire.png"),
                ContributorCount = 2,
                Date = DateTime.Now,
                LinkCount = 1,
                ResponseCount = 1, 
                Verified = true
            };
            Incidents[5] = new Incident("Eastleigh Plane crash", "", "Nairobi, Kenya")
            {
               Image = ResourcesManager.LoadImageResource("ushahidi_plane.png"),
               ContributorCount = 2,
               Date = DateTime.Now,
               LinkCount = 1,
               ResponseCount = 1,
               Verified = true
            };
            Incidents[6] = new Incident("Kenyatta Pwr Failure", "", "Nairobi, Kenya")
            {
               Image = ResourcesManager.LoadImageResource("ushahidi_globe.png"),
               ContributorCount = 2,
               Date = DateTime.Now,
               LinkCount = 1,
               ResponseCount = 1,
               Verified = true
            };
            Incidents[7] = new Incident("Nairobi Protests", "", "Nairobi, Kenya")
            {
               Image = ResourcesManager.LoadImageResource("ushahidi_globe.png"),
               ContributorCount = 2,
               Date = DateTime.Now,
               LinkCount = 1,
               ResponseCount = 1,
               Verified = true
            };
        }

        /// <summary>
        /// Incident types
        /// </summary>
        public string[] Types = {"All Incidents", "Property Loss", "Fires", "Deaths", "Riots"};

        /// <summary>
        /// Incidents
        /// </summary>
        public Incident [] Incidents = new Incident[8];
    }
}
