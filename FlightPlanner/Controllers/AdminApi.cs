using FlightPlanner.Extensions;
using FlightPlannerUseCases.AdminUseCases.Flights.AddFlight;
using FlightPlannerUseCases.AdminUseCases.Flights.DeleteFlight;
using FlightPlannerUseCases.AdminUseCases.Flights.GetFlight;
using FlightPlannerUseCases.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlightPlanner.Controllers
{
    [Authorize]
    [Route("admin-api")]
    [ApiController]
    public class AdminApi : ControllerBase
    {
        private readonly IMediator _mediator;
        private static SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

        public AdminApi(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("flights/{id}")]
        public async Task<IActionResult> GetFlight(int id)
        {
            return (await _mediator.Send(new GetFlightQuery(id)))
                .ToActionResult();
        }

        [HttpDelete]
        [Route("flights/{id}")]
        public async Task<IActionResult> DeleteFlight(int id)
        {
            return (await _mediator.Send(new DeleteFlightCommand(id)))
                .ToActionResult();
        }

        [HttpPut]
        [Route("flights")]
        public async Task<IActionResult> AddFlight(AddFlightRequest request)
        {
            _semaphore.Wait();
            try
            {
                return (await _mediator.Send(new AddFlightCommand { AddFlightRequest = request }))
                .ToActionResult();
            }
            finally
            {
                _semaphore.Release();
            }
        }
    }
}
