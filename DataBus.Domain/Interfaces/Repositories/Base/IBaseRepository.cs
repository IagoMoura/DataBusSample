using System;
using System.Collections.Generic;
using System.Text;

namespace DataBus.Domain.Interfaces.Repositories.Base
{
    public interface IBaseRepository<T>
        : IDisposable
    {
        T Add(T model);
        T Update(T model);
        T Delete(T model);
        List<T> GetAll();
    }
}
