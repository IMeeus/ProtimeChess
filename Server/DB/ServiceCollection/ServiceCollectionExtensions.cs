﻿using Events.Db.Interfaces;
using Events.Db.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Events.Db.ServiceCollection
{
    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterEventsDatabase(this IServiceCollection services)
        {
            services.AddDbContext<EventDbContext>();
            services.AddTransient<IGameEventRespository, GameEventRepository>();

            return services;
        }
    }
}