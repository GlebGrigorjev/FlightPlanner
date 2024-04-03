using FlightPlanner.Extensions;
using FlightPlannerCore.Models;
using FlightPlannerUseCases.AdminUseCases.Flights.GetFlight;
using FlightPlannerUseCases.CustomerUseCases.Airports.SearchAirports;
using FlightPlannerUseCases.CustomerUseCases.Flights.SearchFlight;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FlightPlanner.Controllers
{
    [Route("api")]
    [ApiController]
    public class CustomerFlightApi : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerFlightApi(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("airports")]
        public async Task<IActionResult> SearchAirports(string search)
        {
            return (await _mediator.Send(new SearchAirportCommand(search)))
                .ToActionResult();
        }

        [HttpPost]
        [Route("flights/search")]
        public async Task<IActionResult> SearchFlights(SearchFlightsRequest req)
        {
            return (await _mediator.Send(new SearchFlightCommand(req)))
                .ToActionResult();
        }

        [HttpGet]
        [Route("flights/{id}")]
        public async Task<IActionResult> GetFlight(int id)
        {
            return (await _mediator.Send(new GetFlightQuery(id)))
                .ToActionResult();
        }
    }
}
