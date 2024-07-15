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

namespace JobSearch.Application.Repositories
{

    public interface IUnitOfWork : IDisposable
    {
        ICompanyWriteRepository CompaniesWrite { get; }
        ICategoryWriteRepository CategoriesWrite { get; }
        ISeniorityWriteRepository SenioritiesWrite { get; }
        IJobTypeWriteRepository JobTypesWrite { get; }
        ICityWriteRepository CitiesWrite { get; }
        IOpportunityTypeWriteRepository OpportunityTypesWrite { get; }
        ICurrencyWriteRepository CurrenciesWrite { get; }
        IOperatorWriteRepository OperatorsWrite { get; }
        IOperatorCodeWriteRepository OperatorCodesWrite { get; }
        IPhoneWriteRepository PhonesWrite { get; }
        ISalaryWriteRepository SalariesWrite { get; }
        IAddressWriteRepository AddressesWrite { get; }
        IVacancyWriteRepository VacanciesWrite { get; }
        IVacancyReadRepository VacanciesRead { get; }
        IFavoriteWriteRepository FavoritesWrite { get; }
        IFavoriteReadRepository FavoritesRead { get; }

        Task DisposeAsync();
    }

}
