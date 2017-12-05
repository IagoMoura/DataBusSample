using DataBus.Domain.DomainModels;
using DataBus.Domain.Interfaces.Repositories;
using DataBus.Infra.Data.InMemory.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using DataBus.Domain.Interfaces.Repositories.Base;
using DataBus.Domain.Interfaces;
using DataBus.Domain.Commands.Base;

namespace DataBus.Infra.Data.InMemory.Repositories
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

        }
    }
}
