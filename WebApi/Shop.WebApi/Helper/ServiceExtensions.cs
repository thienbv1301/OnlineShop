using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data.Models;
using Shop.Service.Dto;
using Shop.Service.MyMapper;
using Shop.Service.MyMapper.AutoMapper;

namespace Shop.WebApi.Helper
{
    public static class ServiceExtensions
    {
        public static void AutoMapperConfigure(this IServiceCollection services)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<AutoMapperProfile>();
            });

            services.AddSingleton<IMyMapper<Product, ProductDto>, ProductMapper>();
            services.AddSingleton<IMyMapper<Image, ImageDto>, ImageMapper>();
        }
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDataContext>(options =>
             options.UseSqlServer(configuration.GetConnectionString("ApplicationDatabase"), b => b.MigrationsAssembly("Shop.WebApi")));
        }
    }
}
