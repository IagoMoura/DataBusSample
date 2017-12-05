using DataBus.Domain.Commands.Base;
using DataBus.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBus.Domain.DataBus.Models
{
    public class Registration
    {
        public string Name { get; set; }
        public double Order { get; set; }
        public Type Command { get; set; }
        public Type CommandReceiver { get; set; }
    }
}
