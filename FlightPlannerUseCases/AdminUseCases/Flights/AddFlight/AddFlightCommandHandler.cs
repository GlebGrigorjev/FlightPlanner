using AutoMapper;
using FlightPlannerCore.Models;
using FlightPlannerCore.Services;
using FlightPlannerUseCases.Models;
using FluentValidation;
using MediatR;
using System.Net;

namespace FlightPlannerUseCases.AdminUseCases.Flights.AddFlight
{
    public class AddFlightCommandHandler : IRequestHandler<AddFlightCommand, ServiceResult>
    {
        private readonly IFlightService _flightService;
        private readonly IMapper _mapper;
        private readonly IValidator<AddFlightRequest> _validator;

        public AddFlightCommandHandler(IMapper mapper,
            IValidator<AddFlightRequest> validator,
            IFlightService flightService)
        {
            _mapper = mapper;
            _validator = validator;
            _flightService = flightService;
        }

        public async Task<ServiceResult> Handle(AddFlightCommand request, CancellationToken cancellationToken)
        {
            var validatorResult = await _validator.ValidateAsync(request.AddFlightRequest, cancellationToken);

            if (!validatorResult.IsValid)
            {

                if (validatorResult.Errors[0].ErrorCode == "409")
                    return new ServiceResult
                    {
                        ResultObject = validatorResult.Errors,
                        Status = HttpStatusCode.Conflict,
                    };

                return new ServiceResult
                {
                    ResultObject = validatorResult.Errors,
                    Status = HttpStatusCode.BadRequest,
                };
            }

            var flight = _mapper.Map<Flight>(request.AddFlightRequest);

            _flightService.Create(flight);

            return new ServiceResult
            {
                ResultObject = _mapper.Map<AddFlightResponse>(flight),
                Status = HttpStatusCode.Created
            };
        }
    }
}
