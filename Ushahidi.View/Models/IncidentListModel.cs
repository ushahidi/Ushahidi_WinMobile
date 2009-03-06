using Ushahidi.View.Resources;

namespace Ushahidi.View.Models
{
    public class IncidentListModel : BaseModel
    {
        public IncidentListModel()
        {
            Incidents[0] = new Incident("Uhuru fires still strong", "", "Uhuru, Kenya") {Image = ResourcesManager.LoadImageResource("ushahidi_fire.png")};
            Incidents[1] = new Incident("Eastleigh Plane crash", "", "Nairobi, Kenya") { Image = ResourcesManager.LoadImageResource("ushahidi_plane.png") };
            Incidents[2] = new Incident("Kenyatta Pwr Failure", "", "Nairobi, Kenya") { Image = ResourcesManager.LoadImageResource("ushahidi_globe.png") };
            Incidents[3] = new Incident("Nairobi Protests", "", "Nairobi, Kenya") { Image = ResourcesManager.LoadImageResource("ushahidi_globe.png") };
            Incidents[4] = new Incident("Uhuru fires still strong", "", "Uhuru, Kenya") { Image = ResourcesManager.LoadImageResource("ushahidi_fire.png") };
            Incidents[5] = new Incident("Eastleigh Plane crash", "", "Nairobi, Kenya") { Image = ResourcesManager.LoadImageResource("ushahidi_plane.png") };
            Incidents[6] = new Incident("Kenyatta Pwr Failure", "", "Nairobi, Kenya") { Image = ResourcesManager.LoadImageResource("ushahidi_globe.png") };
            Incidents[7] = new Incident("Nairobi Protests", "", "Nairobi, Kenya") { Image = ResourcesManager.LoadImageResource("ushahidi_globe.png") };
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
