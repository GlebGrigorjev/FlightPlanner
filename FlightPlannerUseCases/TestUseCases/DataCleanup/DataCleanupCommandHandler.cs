using FlightPlannerCore.Models;
using FlightPlannerCore.Services;
using FlightPlannerUseCases.Models;
using MediatR;

namespace FlightPlannerUseCases.TestUseCases.DataCleanup
{
    public class DataCleanupCommandHandler : IRequestHandler<DataCleanupCommand, ServiceResult>
    {
        private readonly IDBService _dbService;

        public DataCleanupCommandHandler(IDBService dbService)
        {
            _dbService = dbService;
        }

        public Task<ServiceResult> Handle(DataCleanupCommand request, CancellationToken cancellationToken)
        {
            _dbService.DeleteAll<Flight>();
            _dbService.DeleteAll<Airport>();

            return Task.FromResult(new ServiceResult());
        }
    }
}
