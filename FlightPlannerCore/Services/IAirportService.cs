using FlightPlannerCore.Models;

namespace FlightPlannerCore.Services
{
    public interface IAirportService : IEntityService<Airport>
    {
        List<Airport> GetAirport(string request);
    }
}
