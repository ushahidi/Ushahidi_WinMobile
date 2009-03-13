namespace Ushahidi.View.Models
{
    public class IncidentMapModel : BaseModel
    {
        /// <summary>
        /// Incident types
        /// </summary>
        public string[] Types = { "All Incidents", "Property Loss", "Fires", "Deaths", "Riots" };
    }
}
