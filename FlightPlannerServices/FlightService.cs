using FlightPlannerCore.Models;
using FlightPlannerCore.Services;
using FlightPlannerData;
using Microsoft.EntityFrameworkCore;

namespace FlightPlannerServices
{
    public class FlightService : EntityService<Flight>, IFlightService
    {
        public FlightService(IFlightPlannerDBContext dbContext) : base(dbContext)
        {
        }

        public Flight? GetFullFlightById(int id)
        {
            return _dbContext.Flights.Include(flight => flight.From)
                 .Include(flight => flight.To)
                 .SingleOrDefault(flight => flight.Id == id);
        }

        public List<Flight> GetAllFlightDetails()
        {
            return _dbContext.Flights
                .Include(flight => flight.From)
                .Include(flight => flight.To).ToList();
        }

        public List<Flight> GetFlightsByDetails(SearchFlightsRequest req)
        {
            return _dbContext.Flights.Where(time =>
                time.DepartureTime.Contains(req.DepartureDate) &&
                time.From.AirportCode == req.From &&
                time.To.AirportCode == req.To)
                .ToList();
        }

        public bool GetFlightsByFlightDetails(Flight request)
        {
            return _dbContext.Flights.Any(f =>
                    f.Carrier == request.Carrier &&
                    f.DepartureTime == request.DepartureTime &&
                    f.ArrivalTime == request.ArrivalTime &&
                    f.From.Country == request.From.Country &&
                    f.From.City == request.From.City &&
                    f.From.AirportCode == request.From.AirportCode &&
                    f.To.Country == request.To.Country &&
                    f.To.City == request.To.City &&
                    f.To.AirportCode == request.To.AirportCode);
        }
    }
}
