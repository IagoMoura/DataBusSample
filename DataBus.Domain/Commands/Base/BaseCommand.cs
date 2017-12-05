using DataBus.Domain.Interfaces.Repositories;
using DataBus.Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBus.Domain.Commands.Base
{
    public abstract class BaseCommand
    {
        public IUnitOfWork UnitOfWork { get; set; }

        public bool Continue { get; set; }
        public bool Success { get; set; }
        public bool Fail { get; set; }

        public BaseCommand(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
