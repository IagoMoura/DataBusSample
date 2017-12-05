using DataBus.Domain.Interfaces.Repositories;
using DataBus.Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBus.Domain.Services.Base
{
    public class BaseService
    {
        public IUnitOfWork UnitOfWork { get; set; }

        public BaseService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
