using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sample.Shared.Common;
using Sample.DataAccess.Persistence;
using Sample.DataAccess.Repositories;
using Sample.DataAccess.Repositories.Users;
using Sample.DataAccess.Repositories.Products;
using Sample.DataAccess.Repositories.UploadFiles;
using Sample.DataAccess.Repositories.Categories;
using Sample.DataAccess.Repositories.Attributes;
using Sample.DataAccess.Repositories.AttributeProducts;
using Sample.DataAccess.Repositories.ProductVariants;
using Sample.DataAccess.Repositories.RefreshTokens;

namespace Sample.DataAccess
{
    public static class DataAccessDependencyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabase(configuration);
            services.AddTransient(typeof(IRepository<,>), typeof(Repository<,>));
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IUploadFileRepository, UploadFileRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IAttributeRepository, AttributeRepository>();
            services.AddTransient<IAttributeProductRepository, AttributeProductRepository>();
            services.AddTransient<IProductVariantRepository, ProductVariantRepository>();
            services.AddTransient<IRefreshTokenRepository, RefreshTokenRepository>();
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
