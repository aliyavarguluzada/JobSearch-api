using JobSearch.Application.Features.Category.Command;
using JobSearch.Application.Features.City;
using JobSearch.Application.Features.Company.Command;
using JobSearch.Application.Features.JobType.Command;
using JobSearch.Application.Features.OpportunityType.Command;
using JobSearch.Application.Features.Seniority.Command;
using Microsoft.Extensions.DependencyInjection;

namespace JobSearch.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateCompanyCommandHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateCategoryCommandHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateSeniorityCommandHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateCityCommandHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateJobTypeCommandHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateOpportunityTypeCommandHandler).Assembly));
        }
    }
}
