using DataBus.Domain.Commands.Base;
using DataBus.Domain.DomainModels;
using DataBus.Domain.Interfaces.Repositories;
using DataBus.Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBus.Domain.Commands.Products
{
    public class GetAllProductsCommand
        : BaseCommand
    {
        public List<Product> Products { get; set; }

        public GetAllProductsCommand(IUnitOfWork unitOfWork, List<Product> products)
            : base(unitOfWork)
        {
            Products = products;
        }
    }
}
