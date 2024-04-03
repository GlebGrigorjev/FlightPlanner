using System.ComponentModel.DataAnnotations;

namespace FlightPlannerCore.Models
{
    public class Flight : Entity
    {

        [Required]
        public Airport From { get; set; }

        [Required]
        public Airport To { get; set; }

        [Required]
        public string Carrier { get; set; }

        [Required]
        public string DepartureTime { get; set; }

        [Required]
        public string ArrivalTime { get; set; }
        public new int? Id { get; set; }

    }
}
