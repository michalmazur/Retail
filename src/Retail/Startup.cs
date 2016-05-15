using AutoMapper;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.PlatformAbstractions;
using Newtonsoft.Json.Serialization;
using Retail.Models;
using Retail.ViewModels;
using System;

namespace Retail
{
    public class Startup
    {
        public static IConfigurationRoot Configuration;

        public Startup(IApplicationEnvironment appEnv)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(appEnv.ApplicationBasePath)
                .AddEnvironmentVariables()
                .AddJsonFile("config.json");

            Configuration = builder.Build();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddJsonOptions(opt => {
                    opt.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                });

            services.AddLogging();

            services.AddIdentity<RetailUser, IdentityRole>(config =>
            {
                config.User.RequireUniqueEmail = true;

                // allow weak passwords in development
                config.Password.RequiredLength = 4;
                config.Password.RequireNonLetterOrDigit = false;
                config.Password.RequireDigit = false;
                config.Password.RequireUppercase = false;

                config.Cookies.ApplicationCookie.ExpireTimeSpan = new TimeSpan(28, 0, 0, 0);
            })
            .AddEntityFrameworkStores<RetailContext>();

            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<RetailContext>();

            services.AddTransient<RetailContextSeedData>();

            services.AddScoped<IRetailRepository, RetailRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory, RetailContextSeedData seeder, IHostingEnvironment hostingEnv)
        {
            loggerFactory.AddDebug(LogLevel.Debug);

            Mapper.Initialize(config =>
            {
                config.CreateMap<Store, StoreViewModel>().ReverseMap();
                config.CreateMap<ProductViewModel, Product>()
                .ForMember(d => d.UnitId, o => o.MapFrom(s => s.UnitId));
                config.CreateMap<Product, ProductViewModel>();
                config.CreateMap<Product, ProductViewModelBase>().ReverseMap();
                config.CreateMap<Price, PriceViewModel>()
                .ForMember(d => d.Price, o => o.MapFrom(s => s.Cost))
                .ForMember(d => d.UpdatedDate, o => o.MapFrom(s => s.UpdatedDate));
                config.CreateMap<PriceViewModel, Price>()
                .ForMember(d => d.Cost, o => o.MapFrom(s => s.Price))
                .ForMember(d => d.UpdatedDate, o => o.MapFrom(s => s.UpdatedDate))
                .ForMember(d => d.ProductId, o => o.MapFrom(s => s.ProductId))
                .ForMember(d => d.StoreId, o => o.MapFrom(s => s.StoreId));
                config.CreateMap<Unit, UnitViewModel>().ReverseMap();
            });

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseIdentity();
            app.UseDeveloperExceptionPage();
            app.UseMvc();

            // Migrate and seed the database
            RetailContext context = app.ApplicationServices.GetService<RetailContext>();

            if (hostingEnv.IsEnvironment("integration"))
            {
                context.RunMigrations(recreateDatabase: true);
            }
            else
            {
                context.RunMigrations();
            }
            
            await seeder.EnsureSeedDataAsync();
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
