using FlightPlannerCore.Models;

namespace FlightPlannerCore.Services
{
    public interface IEntityService<T> where T : Entity
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Create(T entity);
        void Delete(T entity);
        void Update(T entity);
        void DeleteAll();
    }
}
