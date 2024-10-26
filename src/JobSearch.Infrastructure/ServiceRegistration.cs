using JobSearch.Application.Interfaces;
using JobSearch.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JobSearch.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {

            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");

            builder.Build();
            //var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            //var configurationn = new ConfigurationBuilder()
            //    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            //    .AddJsonFile(
            //        $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",
            //        optional: true)
            //    .Build();
            //Log.Logger = new LoggerConfiguration()
            //                .Enrich.FromLogContext()
            //                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(configurationn["ElasticConfiguration:Uri"]))
            //                {
            //                    AutoRegisterTemplate = true,
            //                    IndexFormat = $"{Assembly.GetExecutingAssembly().GetName().Name.ToLower()}-{DateTime.UtcNow:yyyy-MM}"
            //                })
            //                .Enrich.WithProperty("Environment", environment)
            //                .ReadFrom.Configuration(configurationn)
            //                .CreateLogger();

            //services.Logging.ClearProviders();

            //services.Logging.AddSerilog();

            //services.Host.UseSerilog((context, configuration) =>
            //              configuration.ReadFrom.Configuration(context.Configuration));

            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ISeniorityService, SeniorityService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IJobTypeService, JobTypeService>();
            services.AddScoped<IOpportunityTypeService, OpportunityTypeService>();
            services.AddScoped<ICurrencyService, CurrencyService>();
            services.AddScoped<IOperatorService, OperatorService>();
            services.AddScoped<IOperatorCodeService, OperatorCodeService>();
            services.AddScoped<IPhoneService, PhoneService>();
            services.AddScoped<ISalaryService, SalaryService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IVacancyService, VacancyService>();
            services.AddScoped<IFavoriteService, FavoriteService>();
            services.AddScoped<IMessageProducerService, MessageProducerService>();

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration["Database:Connection"]));
        }
    }
}
