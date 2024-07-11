using JobSearch.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JobSearch.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //ConfigurationManager configurationManager = new();
            //configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../WorkWaveApp.API"));
            //configurationManager.AddJsonFile("appsettings.json")
            //                    .AddEnvironmentVariables();

            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");

            builder.Build();


            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration["Database:Connection"]));
        }
    }
}
