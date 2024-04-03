using AutoMapper;
using FlightPlannerCore.Services;
using FlightPlannerUseCases.Models;
using MediatR;
using System.Net;

namespace FlightPlannerUseCases.CustomerUseCases.Flights.GetFlight
{
    public class GetFlightCommandHandler : IRequestHandler<GetFlightQuery, ServiceResult>
    {
        private readonly IFlightService _flightService;
        private readonly IMapper _mapper;
        public GetFlightCommandHandler(IFlightService flightService,
            IMapper mapper)
        {
            _flightService = flightService;
            _mapper = mapper;
        }

        public async Task<ServiceResult> Handle(GetFlightQuery request, CancellationToken cancellationToken)
        {
            var flight = _flightService.GetFullFlightById(request.Id);

            var response = new ServiceResult();

            if (flight == null)
            {
                response.Status = HttpStatusCode.NotFound;
                return response;
            }

            response.ResultObject = _mapper.Map<AddFlightResponse>(flight);
            response.Status = HttpStatusCode.OK;

            return response;
        }
    }
}
