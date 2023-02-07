using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using SalesAPI.Application;
using SalesAPI.Domain.CommandHandlers;
using SalesAPI.Domain.Commands;
using SalesAPI.Domain.Core;
using SalesAPI.Domain.EventHandlers;
using SalesAPI.Domain.Events;
using SalesAPI.Domain.Interfaces;
using SalesAPI.Infra.CrossCutting.Bus;
using SalesAPI.Infra.Data;

namespace SalesAPI.Infra.CrossCutting.IoC
{
    public static class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application
            services.AddScoped<ISalesAppService, SalesAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<SalesRegisteredEvent>, SalesEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterSalesCommand, ValidationResult>, SalesCommandHandler>();


            // Infra - Data
            services.AddScoped<ISalesRepository, SalesRepository>();

            // Infra - Data EventSourcing
            //services.AddScoped<IEventStoreRepository, EventStoreSqlRepository>();
            //services.AddScoped<IEventStore, SqlEventStore>();
        }
    }
}