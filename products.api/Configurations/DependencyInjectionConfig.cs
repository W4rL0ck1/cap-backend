using Cig.Cdu.Infrastructure.Repositories;
using FluentValidation;
using HashService;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using products.application.DTO;
using products.application.Interfaces.Generic;
using products.application.Services;
using products.application.Services.Generic;
using products.application.Validators;
using products.infrastructure.Repositories;
using Products.Application;
using Products.Application.DTO;
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
            services.AddTransient<IValidator<AuthParamsDTO>, AuthParamsDTOValidators>();
            services.AddTransient<IValidator<NewUserDTO>, NewUserDTOValidator>();



            // services.ConfigureSecurityOptions(configuration);
            services.ConfigureServices(configuration);
            services.AddScoped(typeof(Repository<>));

            // services.AddSingleton<IEncryptionService, EncryptionService>();

            services.AddSingleton<ISecurityService, SecurityService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<IJwtService, JwtService>();
            services.AddSingleton<IBaseResult, BaseResult>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductsService, ProductsServices>();


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