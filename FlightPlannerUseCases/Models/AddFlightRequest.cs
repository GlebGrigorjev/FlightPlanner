namespace FlightPlannerUseCases.Models
{
    public class AddFlightRequest
    {
        public AirportViewModel From { get; set; }

        public AirportViewModel To { get; set; }

        public string Carrier { get; set; }

        public string DepartureTime { get; set; }

        public string ArrivalTime { get; set; }
        public new int? Id { get; set; }
    }
}
