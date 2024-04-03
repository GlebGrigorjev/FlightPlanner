using FlightPlannerCore.Services;
using FlightPlannerUseCases.Models;
using MediatR;

namespace FlightPlannerUseCases.AdminUseCases.Flights.DeleteFlight
{
    public class DeleteFlightCommandHandler : IRequestHandler<DeleteFlightCommand, ServiceResult>
    {
        private readonly IFlightService _flightService;

        public DeleteFlightCommandHandler(IFlightService flightService)
        {
            _flightService = flightService;
        }

        public Task<ServiceResult> Handle(DeleteFlightCommand request, CancellationToken cancellationToken)
        {
            var flight = _flightService.GetById(request.Id);
            _flightService.Delete(flight);

            return Task.FromResult(new ServiceResult());
        }
    }
}
