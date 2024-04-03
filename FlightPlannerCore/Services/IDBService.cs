﻿using FlightPlannerCore.Models;

namespace FlightPlannerCore.Services
{
    public interface IDBService
    {
        IEnumerable<T> GetAll<T>() where T : Entity;
        T GetById<T>(int id) where T : Entity;
        void Create<T>(T entity) where T : Entity;
        void Delete<T>(T entity) where T : Entity;
        void Update<T>(T entity) where T : Entity;
        void DeleteAll<T>() where T : Entity;
    }
}
