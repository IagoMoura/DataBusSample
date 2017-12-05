using DataBus.Domain.DomainModels;
using DataBus.Domain.Interfaces.Repositories.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataBus.Infra.Data.InMemory.Repositories.Base
{
    public class DatabaseContext
        : IDatabaseContext
    {
        public List<Product> Products { get; set; }

        public DatabaseContext()
        {
            Products = new List<Product>();
        }

        public IList GetCollection<T>()
        {
            var genericType = typeof(T);

            if (genericType == typeof(Product))
                return Products;
            else
                return null;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
