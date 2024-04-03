using FlightPlannerCore.Models;
using FlightPlannerUseCases.Models;
using MediatR;

namespace FlightPlannerUseCases.CustomerUseCases.Flights.SearchFlight
{
    public class SearchFlightCommand(SearchFlightsRequest req)
        : IRequest<ServiceResult>
    {
        public SearchFlightsRequest Request { get; set; } = req;
    }
}
