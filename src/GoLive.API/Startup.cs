using GoLive.Core.Interfaces;
using GoLive.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Swashbuckle.AspNetCore.Swagger;
using Newtonsoft.Json;

namespace GoLive.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("CorsPolicy",
                builder => builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials()));

            services.AddScoped<IAppDbContext, AppDbContext>();

            var settings = new JsonSerializerSettings
            {
                ContractResolver = new SignalRContractResolver()
            };

            var serializer = JsonSerializer.Create(settings);

            services.Add(new ServiceDescriptor(typeof(JsonSerializer),
                                               provider => serializer,
                                               ServiceLifetime.Transient));
            services.AddSignalR();
            
            services.AddDbContext<AppDbContext>(options =>
            {
                options
                .UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"], b => b.MigrationsAssembly("GoLive.Infrastructure"));
            });

            services.AddSwaggerGen(options =>
            {
                options.DescribeAllEnumsAsStrings();
                options.SwaggerDoc("v1", new Info
                {
                    Title = "GoLive",
                    Version = "v1",
                    Description = "GoLive REST API",
                });
                options.CustomSchemaIds(x => x.FullName);
            });

            services.ConfigureSwaggerGen(options => { });

            services.AddMediatR(typeof(Startup));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);            
        }
        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("CorsPolicy");

            if (env.IsDevelopment())
            {
                app.UseSwagger();

                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "GoLive API");
                    options.RoutePrefix = string.Empty;
                });

                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSignalR(routes => routes.MapHub<AppHub>("/hub"));

            app.UseHttpsRedirection();
            app.UseMvc();

        }
    }
}
