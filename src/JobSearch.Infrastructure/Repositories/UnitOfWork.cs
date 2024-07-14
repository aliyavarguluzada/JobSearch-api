using JobSearch.Application.Repositories;
using JobSearch.Application.Repositories.Address;
using JobSearch.Application.Repositories.Category;
using JobSearch.Application.Repositories.City;
using JobSearch.Application.Repositories.Company;
using JobSearch.Application.Repositories.Currency;
using JobSearch.Application.Repositories.JobType;
using JobSearch.Application.Repositories.Operator;
using JobSearch.Application.Repositories.OperatorCode;
using JobSearch.Application.Repositories.OpportunityType;
using JobSearch.Application.Repositories.Phone;
using JobSearch.Application.Repositories.Salary;
using JobSearch.Application.Repositories.Seniority;
using JobSearch.Application.Repositories.Vacancy;
using JobSearch.Infrastructure.Data;
using JobSearch.Infrastructure.Repositories.Address;
using JobSearch.Infrastructure.Repositories.Category;
using JobSearch.Infrastructure.Repositories.City;
using JobSearch.Infrastructure.Repositories.Company;
using JobSearch.Infrastructure.Repositories.Currency;
using JobSearch.Infrastructure.Repositories.JobType;
using JobSearch.Infrastructure.Repositories.Operator;
using JobSearch.Infrastructure.Repositories.OperatorCode;
using JobSearch.Infrastructure.Repositories.OpportunityType;
using JobSearch.Infrastructure.Repositories.Phone;
using JobSearch.Infrastructure.Repositories.Salary;
using JobSearch.Infrastructure.Repositories.Seniority;
using JobSearch.Infrastructure.Repositories.Vacancy;

namespace JobSearch.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Companies = new CompanyWriteRepository(_context);
            Categories = new CategoryWriteRepository(_context);
            Seniorities = new SeniorityWriteRepository(_context);
            Cities = new CityWriteRepository(_context);
            JobTypes = new JobTypeWriteRepository(_context);
            OpportunityTypes = new OpportunityTypeWriteRepository(_context);
            Currencies = new CurrencyWriteRepository(_context);
            Operators = new OperatorWriteRepository(_context);
            OperatorCodes = new OperatorCodeWriteRepository(_context);
            Phones = new PhoneWriteRepository(_context);
            Salaries = new SalaryWriteRepository(_context);
            Addresses = new AddressWriteRepository(_context);
            Vacancies = new VacancyWriteRepository(_context);
        }

        public ICompanyWriteRepository Companies { get; private set; }
        public ICategoryWriteRepository Categories { get; private set; }
        public ISeniorityWriteRepository Seniorities { get; private set; }
        public ICityWriteRepository Cities { get; private set; }
        public IJobTypeWriteRepository JobTypes { get; private set; }
        public IOpportunityTypeWriteRepository OpportunityTypes { get; private set; }
        public ICurrencyWriteRepository Currencies { get; private set; }
        public IOperatorWriteRepository Operators { get; private set; }
        public IOperatorCodeWriteRepository OperatorCodes { get; private set; }
        public IPhoneWriteRepository Phones { get; private set; }
        public ISalaryWriteRepository Salaries { get; private set; }
        public IAddressWriteRepository Addresses { get; private set; }
        public IVacancyWriteRepository Vacancies { get; private set; }
       
        public async Task Complete() => await _context.SaveChangesAsync();
        public async Task SaveAsync() => await _context.SaveChangesAsync();
        public async Task DisposeAsync() => await _context.DisposeAsync();
        public void Dispose() => _context.Dispose();


    }
}
