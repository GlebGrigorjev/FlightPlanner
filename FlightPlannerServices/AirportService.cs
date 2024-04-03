using FlightPlannerCore.Models;
using FlightPlannerCore.Services;
using FlightPlannerData;

namespace FlightPlannerServices
{
    public class AirportService : EntityService<Airport>, IAirportService
    {
        public AirportService(IFlightPlannerDBContext dbContext) : base(dbContext)
        {
        }

        public List<Airport> GetAirport(string request)
        {
            string trimmedRequest = request.Trim().ToUpper();

            return _dbContext.Airports.Where(airport =>
                 airport.AirportCode.Contains(trimmedRequest) ||
                 airport.Country.Contains(trimmedRequest) ||
                 airport.City.Contains(trimmedRequest)).ToList();
        }
    }
}
