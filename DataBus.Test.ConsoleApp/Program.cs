using DataBus.Domain.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using DataBus.Infra.CrossCutting.IoC;

namespace DataBus.Test.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var _services = new ServiceCollection();
            var _serviceProvider = _services.BuildServiceProvider();

            _services.ConfigureServices();

            var productService = Infra.CrossCutting.IoC.Bootstrapper.GetInstance<IProductService>();
            var novoProduto = productService.Add(new Domain.DomainModels.Product());
    }
    }
}
