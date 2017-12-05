using DataBus.Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBus.Infra.Data.InMemory.Repositories.Base
{
    public class UnitOfWork
        : IUnitOfWork
    {
        #region Fields
        private readonly IDatabaseContext _databaseContext;
        #endregion

        #region Constructors
        public UnitOfWork(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public object TransactionObject
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
