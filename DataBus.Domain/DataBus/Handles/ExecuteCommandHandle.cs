using DataBus.Domain.Commands.Base;
using DataBus.Domain.DataBus.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBus.Domain.DataBus.Handles
{
    public delegate void ExecuteCommandHandle(Registration registration, BaseCommand command);
}
