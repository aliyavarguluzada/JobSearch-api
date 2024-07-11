using JobSearch.Application.Repositories.Category;
using JobSearch.Application.Repositories.Company;

namespace JobSearch.Application.Repositories
{

    public interface IUnitOfWork : IDisposable
    {
        ICompanyRepository Companies { get; }
        ICategoryRepository Categories { get; }

        int Complete();
    }

}
