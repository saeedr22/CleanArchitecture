using CA.Application.Services;
using CA.Domain.Repositories;
using CA.Infrastructure.EF.Contexts;
using CA.Infrastructure.EF.Options;
using CA.Infrastructure.EF.Repositories;
using CA.Infrastructure.EF.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using CA.Shared.Options;


namespace CA.Infrastructure.EF
{
    internal static class Extensions
    {
        public static IServiceCollection AddSQLDB(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITravelerCheckListRepository, TravelerCheckListRepository>();
            services.AddScoped<ITravelerCheckListReadService, TravelerCheckListReadService>();

            var options = configuration.GetOptions<DataBaseOptions>("DataBaseConnectionString");
            services.AddDbContext<ReadDbContext>(ctx =>
            ctx.UseSqlServer(options.ConnectionString));
            services.AddDbContext<WriteDbContext>(ctx =>
                ctx.UseSqlServer(options.ConnectionString));

            return services;
        }
    }
}
