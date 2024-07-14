﻿using JobSearch.Application.Interfaces;
using JobSearch.Infrastructure.Data;
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

            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration["Database:Connection"]));
        }
    }
}
