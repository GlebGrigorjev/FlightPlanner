using FlightPlannerUseCases.Models;
using MediatR;

namespace FlightPlannerUseCases.CustomerUseCases.Airports.SearchAirports
{
    public class SearchAirportCommand(string airport) : IRequest<ServiceResult>
    {
        public string Airport { get; set; } = airport;
    }
}
