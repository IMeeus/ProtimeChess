using DDD.Chess.App.Interfaces;
using Events.Db.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Events.Db.ServiceCollection
{
    [ExcludeFromCodeCoverage]
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterEventsDatabase(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<EventDbContext>(options => options.UseSqlServer(connectionString));
            services.AddTransient<IGameEventRepository, GameEventRepository>();

            return services;
        }
    }
}