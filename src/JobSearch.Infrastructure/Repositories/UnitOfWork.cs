using JobSearch.Application.Repositories;
using JobSearch.Application.Repositories.Address;
using JobSearch.Application.Repositories.Category;
using JobSearch.Application.Repositories.City;
using JobSearch.Application.Repositories.Company;
using JobSearch.Application.Repositories.Currency;
using JobSearch.Application.Repositories.Favorite;
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
using JobSearch.Infrastructure.Repositories.Favorite;
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
            CompaniesWrite = new CompanyWriteRepository(_context);
            CategoriesWrite = new CategoryWriteRepository(_context);
            SenioritiesWrite = new SeniorityWriteRepository(_context);
            CitiesWrite = new CityWriteRepository(_context);
            JobTypesWrite = new JobTypeWriteRepository(_context);
            OpportunityTypesWrite = new OpportunityTypeWriteRepository(_context);
            CurrenciesWrite = new CurrencyWriteRepository(_context);
            OperatorsWrite = new OperatorWriteRepository(_context);
            OperatorCodesWrite = new OperatorCodeWriteRepository(_context);
            PhonesWrite = new PhoneWriteRepository(_context);
            SalariesWrite = new SalaryWriteRepository(_context);
            AddressesWrite = new AddressWriteRepository(_context);
            VacanciesWrite = new VacancyWriteRepository(_context);
            VacanciesRead = new VacancyReadRepository(_context);
            FavoritesWrite = new FavoriteWriteRepistory(_context);
        }

        public ICompanyWriteRepository CompaniesWrite { get; private set; }
        public ICategoryWriteRepository CategoriesWrite { get; private set; }
        public ISeniorityWriteRepository SenioritiesWrite { get; private set; }
        public ICityWriteRepository CitiesWrite { get; private set; }
        public IJobTypeWriteRepository JobTypesWrite { get; private set; }
        public IOpportunityTypeWriteRepository OpportunityTypesWrite { get; private set; }
        public ICurrencyWriteRepository CurrenciesWrite { get; private set; }
        public IOperatorWriteRepository OperatorsWrite { get; private set; }
        public IOperatorCodeWriteRepository OperatorCodesWrite { get; private set; }
        public IPhoneWriteRepository PhonesWrite { get; private set; }
        public ISalaryWriteRepository SalariesWrite { get; private set; }
        public IAddressWriteRepository AddressesWrite { get; private set; }
        public IVacancyWriteRepository VacanciesWrite { get; private set; }

        public IVacancyReadRepository VacanciesRead { get; private set; }

        public IFavoriteWriteRepository FavoritesWrite { get; private set; }

        public async Task Complete() => await _context.SaveChangesAsync();
        public async Task SaveAsync() => await _context.SaveChangesAsync();
        public async Task DisposeAsync() => await _context.DisposeAsync();
        public void Dispose() => _context.Dispose();


    }
}
