using JobSearch.Application.Features.Category.Command;
using JobSearch.Application.Features.City.Command;
using JobSearch.Application.Features.Company.Command;
using JobSearch.Application.Features.Currency.Command;
using JobSearch.Application.Features.JobType.Command;
using JobSearch.Application.Features.Operator.Command;
using JobSearch.Application.Features.OperatorCode;
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
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateCurrencyCommandHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateOperatorCommandHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateOperatorCodeCommandHandler).Assembly));
        }
    }
}
