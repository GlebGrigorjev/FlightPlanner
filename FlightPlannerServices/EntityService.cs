using FlightPlannerCore.Models;
using FlightPlannerCore.Services;
using FlightPlannerData;

namespace FlightPlannerServices
{
    public class EntityService<T> : DBService, IEntityService<T> where T : Entity
    {
        public EntityService(IFlightPlannerDBContext dbContext) : base(dbContext)
        {
        }

        public void Create(T entity)
        {
            Create<T>(entity);
        }

        public void Delete(T entity)
        {
            Delete<T>(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return GetAll<T>();
        }

        public T? GetById(int id)
        {
            return GetById<T>(id);
        }

        public void Update(T entity)
        {
            Update<T>(entity);
        }

        public void DeleteAll()
        {
            DeleteAll<T>();
        }
    }
}