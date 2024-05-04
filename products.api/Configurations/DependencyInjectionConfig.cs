using Infrastructure;
using Microsoft.EntityFrameworkCore;

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
            // services.AddScoped(typeof(Repository<>));

            // services.AddSingleton<IEncryptionService, EncryptionService>();

            // services.AddTransient<IAdManager, AdManager>();
            // services.AddTransient<ILoginHttpClientService, LoginHttpClientService>();
            // services.AddTransient<IGedHttpClientService, GedHttpClientService>();
            // services.AddTransient<IEmailHttpClientService, EmailHttpClientService>();
            // services.AddTransient<IIndiceGedService, IndiceGedService>();
            // services.AddTransient<IJobHttpClientService, JobHttpClientService>();
            // services.AddTransient<ILoginService, LoginService>();
            // services.AddTransient<ISapIntegrationService, SapIntegrationService>();
            // services.AddTransient<ICompetenciaManagerService, CompetenciaManagerService>();

            //services.AddSingleton<EnvironmentService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

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

        public static void ConfigureServices(this IServiceCollection services, IConfiguration Configuration)
        {
            // services.Configure<ApiLogin>(Configuration.GetSection("ApiLogin"));
            // services.Configure<ActiveDirectory>(Configuration.GetSection("ActiveDirectory"));
            // services.Configure<ApiGed>(Configuration.GetSection("ApiGed"));
            // services.Configure<ApiEmailService>(Configuration.GetSection("ApiEmailService"));
            // services.Configure<ApiJob>(Configuration.GetSection("ApiJob"));
            // services.Configure<Jwt>(Configuration.GetSection("Jwt"));
            // services.Configure<Token>(Configuration.GetSection("Token"));
            // services.Configure<ApiRead>(Configuration.GetSection("ApiRead"));
            // services.Configure<GroupDeployment>(Configuration.GetSection(nameof(GroupDeployment)));
            // services.Configure<ApiScarf>(Configuration.GetSection(nameof(ApiScarf)));
            // services.Configure<ExternalWwwRootConfiguration>(Configuration.GetSection(nameof(ExternalWwwRootConfiguration)));
            // services.Configure<SAPCredentials>(Configuration.GetSection(nameof(SAPCredentials)));
        }
    }
}