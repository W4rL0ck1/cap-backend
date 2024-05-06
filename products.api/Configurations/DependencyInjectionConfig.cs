using Cig.Cdu.Infrastructure.Repositories;
using HashService;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using products.infrastructure.Repositories;
using Products.Application;
using Products.Application.Interfaces;
using Products.Application.Services;

namespace products.api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            const string applicationAssemblyName = "products.application";
            var assembly = AppDomain.CurrentDomain.Load(applicationAssemblyName);

            // FluentValidation
            // services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(assembly));
            // services.ConfigureSecurityOptions(configuration);
            services.ConfigureServices(configuration);
            services.AddScoped(typeof(Repository<>));

            // services.AddSingleton<IEncryptionService, EncryptionService>();

            services.AddSingleton<ISecurityService, SecurityService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IJwtService, JwtService>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserService, UserService>();

            // Add DbContext to the service container
            services.AddDbContext<AppDbContext>(
                options =>
                    options.UseNpgsql(
                        configuration.GetConnectionString("DefaultConnection"),
                        x => x.MigrationsAssembly("products.infrastructure")));

            //services.AddEntityFrameworkNpgsql().AddDbContext<AppDbContext>();       

            const string nmApiProperty = "NM_API";

            return services;
        }

        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {

        }
    }
}