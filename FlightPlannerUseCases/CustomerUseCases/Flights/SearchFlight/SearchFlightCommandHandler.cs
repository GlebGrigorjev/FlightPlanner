using FlightPlannerCore.Models;
using FlightPlannerCore.Services;
using FlightPlannerUseCases.Models;
using MediatR;
using System.Net;

namespace FlightPlannerUseCases.CustomerUseCases.Flights.SearchFlight
{
    public class SearchFlightCommandHandler : IRequestHandler<SearchFlightCommand, ServiceResult>
    {
        private readonly IFlightService _flightService;

        public SearchFlightCommandHandler(IFlightService flightService)
        {
            _flightService = flightService;
        }

        public async Task<ServiceResult> Handle(SearchFlightCommand request, CancellationToken cancellationToken)
        {
            var response = new ServiceResult();

            if (request.Request.From == request.Request.To ||
                request.Request.From == null ||
                request.Request.To == null)
            {
                response.Status = HttpStatusCode.BadRequest;
                return response;
            }

            var resultingFlight = _flightService.GetFlightsByDetails(request.Request);

            if (resultingFlight.Count > 0)
            {

                PageResult pageResult = new PageResult();

                pageResult.Items.AddRange(resultingFlight);
                pageResult.TotalItems = resultingFlight.Count();

                response.ResultObject = pageResult;
                response.Status = HttpStatusCode.OK;

                return response;
            }

            response.ResultObject = new PageResult();
            response.Status = HttpStatusCode.OK;

            return response;
        }
    }
}
