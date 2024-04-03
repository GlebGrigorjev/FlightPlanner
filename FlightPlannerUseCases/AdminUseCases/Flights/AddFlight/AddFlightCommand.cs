using FlightPlannerUseCases.Models;
using MediatR;

namespace FlightPlannerUseCases.AdminUseCases.Flights.AddFlight
{
    public class AddFlightCommand : IRequest<ServiceResult>
    {
        public AddFlightRequest AddFlightRequest { get; set; }
    }
}
