using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FlightPlannerCore.Models
{
    public class Airport : Entity
    {
        [Required]
        public string Country { get; set; }

        [Required]
        public string City { get; set; }

        [JsonPropertyName("airport")]
        [Required]
        public string AirportCode { get; set; }
    }
}
