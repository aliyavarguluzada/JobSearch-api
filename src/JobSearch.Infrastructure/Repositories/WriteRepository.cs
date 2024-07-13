using JobSearch.Application.Repositories;
using JobSearch.Domain.Entities;
using JobSearch.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace JobSearch.Infrastructure.Repositories
{
    public class WriteRepository<TEntity> : IWriteRepository<TEntity> where TEntity : BaseEntity
    {
        readonly private ApplicationDbContext _context;
        public WriteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public DbSet<TEntity> Table => _context.Set<TEntity>();

        public async Task<bool> AddAsync(TEntity model)
        {
            EntityEntry<TEntity> entityEntry = await Table.AddAsync(model);

            return entityEntry.State == EntityState.Added;
        }
        public async Task<bool> AddRangeAsync(List<TEntity> datas)
        {
            await Table.AddRangeAsync(datas);
            return true;
        }
        public bool Remove(TEntity model)
        {
            EntityEntry<TEntity> entityEntry = Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }
        public bool RemoveRange(List<TEntity> datas)
        {
            Table.RemoveRange(datas);
            return true;
        }
        public async Task<bool> RemoveAsync(int id)
        {
            TEntity model = await Table.FirstOrDefaultAsync(data => data.Id == id);
            return Remove(model);
        }
        public bool Update(TEntity model)
        {
            EntityEntry entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }
        public async Task<int> SaveAsync()
            => await _context.SaveChangesAsync();

        public async Task Complete() => await _context.SaveChangesAsync();



    }
}
