using System;
using System.Collections.Generic;
using System.Text;

namespace DataBus.Domain.DomainModels
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
