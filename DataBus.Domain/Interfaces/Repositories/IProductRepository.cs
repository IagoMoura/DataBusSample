using DataBus.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBus.Domain.Interfaces.Repositories
{
    public interface IProductRepository
        : Base.IBaseRepository<Product>
    {
        
    }
}
