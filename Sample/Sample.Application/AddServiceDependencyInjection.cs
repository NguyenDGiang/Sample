using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Sample.Application.MappingProfiles;
using Sample.Application.Services.Categories;
using Sample.Application.Services.Products;
using Sample.Application.Services.UploadFiles;
using Sample.Application.Services.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application
{
    public static class AddServiceDependencyInjection
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IUploadFileService, UploadFileService>();
            services.AddTransient<ICategoryService, CategoryService>();
            return services;
        }
    }
}
