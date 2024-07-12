using JobSearch.Application.Repositories.Category;
using JobSearch.Application.Repositories.Company;
using JobSearch.Application.Repositories.Seniority;

namespace JobSearch.Application.Repositories
{

    public interface IUnitOfWork : IDisposable
    {
        ICompanyRepository Companies { get; }
        ICategoryRepository Categories { get; }
        ISeniorityRepository Seniorities { get; }
        Task DisposeAsync();
        Task Complete();
    }

}
