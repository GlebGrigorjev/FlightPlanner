using System.Text.Json.Serialization;

namespace FlightPlannerCore.Models
{
    public abstract class Entity
    {
        [JsonIgnore]
        public int Id { get; set; }
    }
}
