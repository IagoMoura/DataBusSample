using DataBus.Domain.Commands.Base;
using DataBus.Domain.Commands.Products;
using DataBus.Domain.DataBus;
using DataBus.Domain.Interfaces;
using DataBus.Domain.Interfaces.Repositories;
using DataBus.Domain.Interfaces.Repositories.Base;
using DataBus.Domain.Interfaces.Services;
using DataBus.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataBus.Infra.CrossCutting.IoC
{
    public static class Bootstrapper
    {
        #region Fields
        private static IServiceCollection _inMemoryServices;
        private static ServiceProvider _inMemoryServiceProvider;

        private static IServiceCollection _sqlServerMemoryServices;
        private static ServiceProvider _sqlServerServiceProvider;

        private static IServiceCollection _services;
        private static ServiceProvider _serviceProvider;
        #endregion

        #region Private Methods
        private static void ConfigureInMemoryServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IDatabaseContext, Data.InMemory.Repositories.Base.DatabaseContext>();
            serviceCollection.AddSingleton<IUnitOfWork, Data.InMemory.Repositories.Base.UnitOfWork>();
            serviceCollection.AddSingleton<IProductRepository, Data.InMemory.Repositories.ProductRepository>();
        }
        private static void ConfigureSqlServerMemoryServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IDatabaseContext, Data.SqlServer.Repositories.Base.DatabaseContext>();
            serviceCollection.AddSingleton<IUnitOfWork, Data.SqlServer.Repositories.Base.UnitOfWork>();
            serviceCollection.AddSingleton<IProductRepository, Data.SqlServer.Repositories.ProductRepository>();
        }

        private static void RegisterSqlServerCommands()
        {
            DataBusManager.Registrations.Add(new Domain.DataBus.Models.Registration
            {
                Command = typeof(AddProductCommand),
                CommandReceiver = typeof(IProductRepository),
                Name = $"SqlServer{nameof(AddProductCommand)}",
                Order = 0
            });
            DataBusManager.Registrations.Add(new Domain.DataBus.Models.Registration
            {
                Command = typeof(UpdateProductCommand),
                CommandReceiver = typeof(IProductRepository),
                Name = $"SqlServer{nameof(UpdateProductCommand)}",
                Order = 0
            });
            DataBusManager.Registrations.Add(new Domain.DataBus.Models.Registration
            {
                Command = typeof(DeleteProductCommand),
                CommandReceiver = typeof(IProductRepository),
                Name = $"SqlServer{nameof(DeleteProductCommand)}",
                Order = 0
            });
            DataBusManager.Registrations.Add(new Domain.DataBus.Models.Registration
            {
                Command = typeof(GetAllProductsCommand),
                CommandReceiver = typeof(IProductRepository),
                Name = $"SqlServer{nameof(GetAllProductsCommand)}",
                Order = 0
            });
        }
        private static void RegisterInMemoryCommands()
        {
            DataBusManager.Registrations.Add(new Domain.DataBus.Models.Registration
            {
                Command = typeof(AddProductCommand),
                CommandReceiver = typeof(IProductRepository),
                Name = $"InMemory{nameof(AddProductCommand)}",
                Order = 0
            });
            DataBusManager.Registrations.Add(new Domain.DataBus.Models.Registration
            {
                Command = typeof(UpdateProductCommand),
                CommandReceiver = typeof(IProductRepository),
                Name = $"InMemory{nameof(UpdateProductCommand)}",
                Order = 0
            });
            DataBusManager.Registrations.Add(new Domain.DataBus.Models.Registration
            {
                Command = typeof(DeleteProductCommand),
                CommandReceiver = typeof(IProductRepository),
                Name = $"InMemory{nameof(DeleteProductCommand)}",
                Order = 0
            });
            DataBusManager.Registrations.Add(new Domain.DataBus.Models.Registration
            {
                Command = typeof(GetAllProductsCommand),
                CommandReceiver = typeof(IProductRepository),
                Name = $"InMemory{nameof(GetAllProductsCommand)}",
                Order = 0
            });
        }
        private static void RegisterCommands()
        {
            RegisterInMemoryCommands();
            RegisterSqlServerCommands();
        }
        #endregion

        #region Private Methods
        private static void DataBusManager_ExecuteCommandEvent(Domain.DataBus.Models.Registration registration, Domain.Commands.Base.BaseCommand command)
        {
            var inMemoryCommandReceiver = (ICommandReceiver)_inMemoryServiceProvider.GetService(registration.CommandReceiver);
            var sqlServerCommandReceiver = (ICommandReceiver)_sqlServerServiceProvider.GetService(registration.CommandReceiver);

            inMemoryCommandReceiver.Execute(command);
            sqlServerCommandReceiver.Execute(command);
        }
        #endregion

        #region Public Methods
        public static void ConfigureServices(this IServiceCollection serviceCollection)
        {
            _inMemoryServices = new ServiceCollection();
            _inMemoryServices.ConfigureInMemoryServices();
            _inMemoryServiceProvider = _inMemoryServices.BuildServiceProvider();

            _sqlServerMemoryServices = new ServiceCollection();
            _sqlServerMemoryServices.ConfigureSqlServerMemoryServices();
            _sqlServerServiceProvider = _sqlServerMemoryServices.BuildServiceProvider();

            _services = serviceCollection;

            _services.AddSingleton<IProductService, ProductService>();
            _services.AddSingleton<IUnitOfWork>((q) => {

                var unitOfWork = _inMemoryServiceProvider.GetService<IUnitOfWork>();

                if (unitOfWork == null)
                    unitOfWork = _sqlServerServiceProvider.GetService<IUnitOfWork>();

                return unitOfWork;
            });

            _serviceProvider = _services.BuildServiceProvider();


            RegisterCommands();

            Domain.DataBus.DataBusManager.ExecuteCommandEvent += DataBusManager_ExecuteCommandEvent;
        }
        
        public static T GetInstance<T>()
        {
            return _serviceProvider.GetService<T>();
        }
        #endregion
    }
}
