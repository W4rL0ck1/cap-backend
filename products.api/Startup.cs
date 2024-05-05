using System.Text.Json.Serialization;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using products.api.Configurations;

namespace products.api
{
    public class Startup
    {
        //private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            //_env = env;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);

            services.Configure<IISServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
                options.MaxRequestBodySize = int.MaxValue;
                options.MaxRequestBodyBufferSize = int.MaxValue;
            });

            //services.Configure<FormOptions>(options => { options.MultipartBodyLengthLimit = int.MaxValue; });

            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "cap-backend-v1", Version = "v1" });
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
            });

            services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(ConnectionHelper.GetConnectionString(Configuration)));
            ExecuteMigrations(services);

            services.RegisterServices(Configuration);
        }

        private static IServiceScope ExecuteMigrations(IServiceCollection services)
        {
            var scope = services.BuildServiceProvider().CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            dbContext.Database.Migrate();
            return scope;
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDeveloperExceptionPage();

            app.UseSwagger();

            if (bool.Parse(Configuration.GetSection("GroupDeployment:SwaggerEnable").Value)){
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "cap-backend v1"));
                app.UseSwaggerUI(c => c.RoutePrefix = String.Empty);
            }
                

            app.UseCors(x => x
                .SetIsOriginAllowed(_ => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials());

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
