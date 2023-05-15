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
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            return services;
        }

        public async static Task<IServiceScope> AddMigrations(this IServiceScope scope)
        {
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<StoreContext>();
            var logger = services.GetRequiredService<ILogger<Program>>();

            await context.Database.EnsureCreatedAsync();

            try
            {
                //await context.Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "An error occured during migration");
            }

            return scope;
        }
    }
}