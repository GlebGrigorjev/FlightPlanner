using AutoMapper;
using FlightPlannerCore.Models;
using FlightPlannerCore.Services;
using FlightPlannerUseCases.Models;
using FluentValidation;

namespace FlightPlannerUseCases.Validations
{
    public class AddFlightRequestValidator : AbstractValidator<AddFlightRequest>
    {
        private readonly IFlightService _flightService;
        private readonly IMapper _mapper;

        public AddFlightRequestValidator(IFlightService flightService,
            IMapper mapper = null)
        {
            _flightService = flightService;
            _mapper = mapper;

            RuleFor(request => request.Carrier).NotEmpty();
            RuleFor(request => request.ArrivalTime).NotEmpty();
            RuleFor(request => request.DepartureTime).NotEmpty();

            RuleFor(request => request.To).SetValidator(new AirportViewModelValidator());
            RuleFor(request => request.From).SetValidator(new AirportViewModelValidator());

            RuleFor(request => request.To.Airport.ToLower().Trim()).NotEqual(request => request.From.Airport.ToLower().Trim());
            RuleFor(request => request.DepartureTime).LessThan(request => request.ArrivalTime);

            RuleFor(request => request)
                .Must(IsFlightUnique).WithErrorCode("409");
        }

        private bool IsFlightUnique(AddFlightRequest request)
        {
            var wtf = _mapper.Map<Flight>(request);

            return !_flightService.GetFlightsByFlightDetails(wtf);
        }
    }
}
