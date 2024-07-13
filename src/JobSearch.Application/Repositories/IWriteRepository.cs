using JobSearch.Domain.Entities;

namespace JobSearch.Application.Repositories
{
    public interface IWriteRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<bool> AddAsync(TEntity model);
        Task<bool> AddRangeAsync(List<TEntity> datas);
        bool Remove(TEntity model);
        bool RemoveRange(List<TEntity> datas);
        Task<bool> RemoveAsync(int id);
        bool Update(TEntity model);

        Task<int> SaveAsync();
    }
}
