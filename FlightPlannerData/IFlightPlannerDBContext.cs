using FlightPlannerCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace FlightPlannerData
{
    public interface IFlightPlannerDBContext
    {
        DbSet<T> Set<T>() where T : class;
        EntityEntry<T> Entry<T>(T entity) where T : class;
        DbSet<Airport> Airports { get; set; }
        DbSet<Flight> Flights { get; set; }
        int SaveChanges();
    }
}
