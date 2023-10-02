using CA.Domain.Factories;
using CA.Domain.Policies;
using Microsoft.Extensions.DependencyInjection;
using CA.Shared.Commands;

namespace CA.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddCommands();
            services.AddSingleton<ITravelerCheckListFactory, TravelerCheckListFactory>();

            services.Scan(b => b.FromAssemblies(typeof(ITravelerItemsPolicy).Assembly)
                .AddClasses(c => c.AssignableTo<ITravelerItemsPolicy>())
                .AsImplementedInterfaces()
                .WithSingletonLifetime());

            return services;
        }
    }
}
