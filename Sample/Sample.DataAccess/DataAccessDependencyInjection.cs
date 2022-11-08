using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sample.Shared.Common;
using Sample.DataAccess.Persistence;
namespace Sample.DataAccess
{
    public static class DataAccessDependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabase(configuration);

            return services;
        }

        private static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var databaseConfig = configuration.GetSection("Database").Get<DatabaseConfiguration>();

            services.AddDbContext<DatabaseContext>(options =>
                      options.UseSqlServer(databaseConfig.ConnectionString,
                          opt => opt.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName)));
        }
    }
}
