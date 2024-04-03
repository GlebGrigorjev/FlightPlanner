using FlightPlannerCore.Models;
using FlightPlannerData;
using Microsoft.EntityFrameworkCore;

namespace FlightPlanner
{
    public class FlightPlannerDBContext : DbContext, IFlightPlannerDBContext
    {
        public FlightPlannerDBContext(DbContextOptions<FlightPlannerDBContext> options) : base(options)
        {

        }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Airport> Airports { get; set; }
    }
}
