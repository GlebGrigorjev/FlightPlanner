﻿using FlightPlannerCore.Models;
using FlightPlannerCore.Services;
using FlightPlannerData;
using Microsoft.EntityFrameworkCore;

namespace FlightPlannerServices
{
    public class DBService : IDBService
    {
        protected readonly IFlightPlannerDBContext _dbContext;

        public DBService(IFlightPlannerDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create<T>(T entity) where T : Entity
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Delete<T>(T entity) where T : Entity
        {
            if (entity == null)
            {

            }
            else
            {
                _dbContext.Set<T>().Remove(entity);
            }
            _dbContext.SaveChanges();
        }

        public void DeleteAll<T>() where T : Entity
        {
            _dbContext.Set<T>().RemoveRange(_dbContext.Set<T>());
            _dbContext.SaveChanges();
        }

        public IEnumerable<T> GetAll<T>() where T : Entity
        {
            return _dbContext.Set<T>().ToList();
        }

        public T? GetById<T>(int id) where T : Entity
        {
            return _dbContext.Set<T>().SingleOrDefault(entity => entity.Id == id);
        }

        public void Update<T>(T entity) where T : Entity
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
