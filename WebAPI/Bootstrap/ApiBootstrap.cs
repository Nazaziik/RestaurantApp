using Domain.Interfaces;
using Infrastructure.Data;
using Infrastructure.Data.Repository;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Bootstrap
{
    public static class ApiBootstrap
    {
        public static IServiceCollection AddDicionaryService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDishRepository, DishRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            services.AddDbContext<StoreContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}