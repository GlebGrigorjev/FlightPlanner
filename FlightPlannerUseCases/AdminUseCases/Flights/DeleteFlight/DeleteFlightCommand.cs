using FlightPlannerUseCases.Models;
using MediatR;

namespace FlightPlannerUseCases.AdminUseCases.Flights.DeleteFlight
{
    public class DeleteFlightCommand(int id) : IRequest<ServiceResult>
    {
        public int Id { get; set; } = id;
    }
}
