using FlightPlannerCore.Models;

namespace FlightPlannerCore.Services
{
    public interface IFlightService : IEntityService<Flight>
    {
        Flight? GetFullFlightById(int id);
        List<Flight> GetAllFlightDetails();
        List<Flight> GetFlightsByDetails(SearchFlightsRequest req);
        public bool GetFlightsByFlightDetails(Flight request);
    }
}
