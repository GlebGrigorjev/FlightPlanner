using FlightPlannerUseCases.Models;
using MediatR;

namespace FlightPlannerUseCases.CustomerUseCases.Flights.GetFlight
{
    public class GetFlightQuery(int id) : IRequest<ServiceResult>
    {
        public int Id { get; set; } = id;
    }
}
