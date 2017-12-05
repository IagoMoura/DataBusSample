using DataBus.Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBus.Infra.Data.InMemory.Repositories.Base
{
    public abstract class BaseRepository<T>
        : IBaseRepository<T>
    {
        protected DatabaseContext DatabaseContext { get; set; }

        public BaseRepository(IDatabaseContext databaseContext)
        {
            DatabaseContext = (DatabaseContext)databaseContext;
        }

        public T Add(T model)
        {
            DatabaseContext.GetCollection<T>()?.Add(model);

            return model;
        }
        public T Update(T model)
        {
            Delete(model);
            Add(model);

            return model;
        }
        public T Delete(T model)
        {
            DatabaseContext.GetCollection<T>()?.Remove(model);

            return model;
        }

        public List<T> GetAll()
        {
            return (List<T>)DatabaseContext.GetCollection<T>();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
