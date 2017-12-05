using DataBus.Domain.Commands.Base;
using DataBus.Domain.DomainModels;
using DataBus.Domain.Interfaces.Repositories;
using DataBus.Domain.Interfaces.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBus.Domain.Commands.Products
{
    public class UpdateProductCommand
        : BaseCommand
    {
        public Product Product { get; set; }

        public UpdateProductCommand(IUnitOfWork unitOfWork, Product product)
            : base(unitOfWork)
        {
            Product = product;
        }
    }
}
