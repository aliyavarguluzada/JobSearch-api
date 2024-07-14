﻿using JobSearch.Application.Repositories.Category;
using JobSearch.Application.Repositories.City;
using JobSearch.Application.Repositories.Company;
using JobSearch.Application.Repositories.Currency;
using JobSearch.Application.Repositories.JobType;
using JobSearch.Application.Repositories.Operator;
using JobSearch.Application.Repositories.OperatorCode;
using JobSearch.Application.Repositories.OpportunityType;
using JobSearch.Application.Repositories.Phone;
using JobSearch.Application.Repositories.Seniority;

namespace JobSearch.Application.Repositories
{

    public interface IUnitOfWork : IDisposable
    {
        ICompanyWriteRepository Companies { get; }
        ICategoryWriteRepository Categories { get; }
        ISeniorityWriteRepository Seniorities { get; }
        IJobTypeWriteRepository JobTypes { get; }
        ICityWriteRepository Cities { get; }
        IOpportunityTypeWriteRepository OpportunityTypes { get; }
        ICurrencyWriteRepository Currencies { get; }
        IOperatorWriteRepository Operators { get; }
        IOperatorCodeWriteRepository OperatorCodes { get; }
        IPhoneWriteRepository Phones { get; }
        Task DisposeAsync();
    }

}
