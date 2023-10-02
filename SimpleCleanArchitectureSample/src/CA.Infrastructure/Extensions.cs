using CA.Application.Services;
using CA.Infrastructure.EF;
using CA.Infrastructure.Services;
using CA.Shared.Abstractions.Commands;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CA.Shared.Queries;
using CA.Infrastructure.Logging;

namespace CA.Infrastructure
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSQLDB(configuration);
            services.AddQueries();
            services.AddSingleton<IWeatherService, DumbWeatherService>();

            services.TryDecorate(typeof(ICommandHandler<>), typeof(LoggingCommandHandlerDecorator<>));

            return services;
        }
    }
}
