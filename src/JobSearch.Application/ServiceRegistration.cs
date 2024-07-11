using JobSearch.Application.CQRS.Category.Command;
using JobSearch.Application.CQRS.Company.Command;
using Microsoft.Extensions.DependencyInjection;

namespace JobSearch.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateCompanyCommandHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateCategoryCommandHandler).Assembly));
        }
    }
}
