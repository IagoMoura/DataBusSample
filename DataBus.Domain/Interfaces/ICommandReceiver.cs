using DataBus.Domain.Commands.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBus.Domain.Interfaces
{
    public interface ICommandReceiver
    {
        void Execute(BaseCommand command);
    }
}
