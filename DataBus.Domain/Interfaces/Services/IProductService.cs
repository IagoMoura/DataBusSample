using DataBus.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBus.Domain.Interfaces.Services
{
    public interface IProductService
        : IDisposable
    {
        Product Add(Product product);
        Product Update(Product product);
        Product Delete(Product product);
        List<Product> GetAll();
    }
}
