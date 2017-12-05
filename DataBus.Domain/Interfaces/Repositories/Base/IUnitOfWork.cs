using System;
using System.Collections.Generic;
using System.Text;

namespace DataBus.Domain.Interfaces.Repositories.Base
{
    public interface IUnitOfWork
        : IDisposable
    {
        object TransactionObject { get; }

        void BeginTransaction();
        void Commit();
    }
}
