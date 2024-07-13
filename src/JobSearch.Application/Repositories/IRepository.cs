using JobSearch.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace JobSearch.Application.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        DbSet<TEntity> Table { get; }
        Task Complete();

    }
}
