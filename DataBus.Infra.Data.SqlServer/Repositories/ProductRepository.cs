using DataBus.Domain.DomainModels;
using DataBus.Domain.Interfaces.Repositories;
using DataBus.Infra.Data.SqlServer.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using DataBus.Domain.Interfaces.Repositories.Base;
using DataBus.Domain.Interfaces;
using DataBus.Domain.Commands.Base;
using DataBus.Domain.Commands.Products;

namespace DataBus.Infra.Data.SqlServer.Repositories
{
    public class ProductRepository
        : BaseRepository<Product>,
        ICommandReceiver,
        IProductRepository
    {
        public ProductRepository(IDatabaseContext databaseContext) 
            : base(databaseContext)
        {
        }

        public void Execute(BaseCommand command)
        {
            if (command.GetType() == typeof(GetAllProductsCommand))
            {
                var getAllProductsCommand = (GetAllProductsCommand)command;

                getAllProductsCommand.Products.Add(new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Produto SqlServer"
                });
            }
        }
    }
}
