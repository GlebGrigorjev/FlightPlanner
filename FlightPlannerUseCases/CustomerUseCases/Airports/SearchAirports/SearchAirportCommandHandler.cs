using FlightPlannerCore.Services;
using FlightPlannerUseCases.Models;
using MediatR;
using System.Net;

namespace FlightPlannerUseCases.CustomerUseCases.Airports.SearchAirports
{
    public class SearchAirportCommandHandler : IRequestHandler<SearchAirportCommand, ServiceResult>
    {
        private readonly IAirportService _airportService;

        public SearchAirportCommandHandler(IAirportService airportService)
        {
            _airportService = airportService;
        }
        public async Task<ServiceResult> Handle(SearchAirportCommand request, CancellationToken cancellationToken)
        {
            var airports = _airportService.GetAirport(request.Airport);

            var response = new ServiceResult();

            if (airports.Count == 0)
            {
                response.Status = HttpStatusCode.NotFound;
                return response;
            }

            response.ResultObject = airports;
            response.Status = HttpStatusCode.OK;

            return response;
        }
    }
}
