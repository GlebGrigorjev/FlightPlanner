using AutoMapper;
using FlightPlannerCore.Models;
using FlightPlannerUseCases.Models;

namespace FlightPlannerUseCases.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Airport, AirportViewModel>()
            .ForMember(viewModel => viewModel.Airport, options => options
            .MapFrom(source => source.AirportCode));

            CreateMap<AirportViewModel, Airport>()
            .ForMember(destination => destination.AirportCode, options => options
            .MapFrom(source => source.Airport));

            CreateMap<AddFlightRequest, Flight>()
                .ForMember(destination => destination.Id,
                options => options.Ignore());
            CreateMap<Flight, AddFlightRequest>();

            CreateMap<AddFlightResponse, Flight>();
            CreateMap<Flight, AddFlightResponse>();
        }
    }
}
