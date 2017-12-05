using DataBus.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using DataBus.Domain.DomainModels;
using DataBus.Domain.DataBus;
using DataBus.Domain.Commands.Products;
using DataBus.Domain.Services.Base;
using DataBus.Domain.Interfaces.Repositories;
using DataBus.Domain.Interfaces.Repositories.Base;

namespace DataBus.Domain.Services
{
    public class ProductService
        : BaseService,
        IProductService
    {
        public ProductService(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        public Product Add(Product product)
        {
            // Execute Business validation

            var command = new AddProductCommand(UnitOfWork, product);
            DataBusManager.ExecuteCommand(command);

            if (command.Success)
            {
                // Success execution
            }
            else if (command.Fail)
            {
                // Fail Execution
            }

            return command.Product;
        }
        public Product Update(Product product)
        {
            // Execute Business validation

            var command = new UpdateProductCommand(UnitOfWork, product);
            DataBusManager.ExecuteCommand(command);

            if (command.Success)
            {
                // Success execution
            }
            else if (command.Fail)
            {
                // Fail Execution
            }

            return command.Product;
        }
        public Product Delete(Product product)
        {
            // Execute Business validation

            var command = new DeleteProductCommand(UnitOfWork, product);
            DataBusManager.ExecuteCommand(command);

            if (command.Success)
            {
                // Success execution
            }
            else if (command.Fail)
            {
                // Fail Execution
            }

            return command.Product;
        }
        public List<Product> GetAll()
        {
            // Execute Business validation

            var products = new List<Product>();
            
            var command = new GetAllProductsCommand(UnitOfWork, products);
            DataBusManager.ExecuteCommand(command);

            if (command.Success)
            {
                // Success execution
            }
            else if (command.Fail)
            {
                // Fail Execution
            }

            return command.Products;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
