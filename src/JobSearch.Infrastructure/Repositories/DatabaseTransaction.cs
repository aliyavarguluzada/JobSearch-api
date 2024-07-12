using JobSearch.Application.Repositories;
using JobSearch.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace JobSearch.Infrastructure.Repositories
{
    public class DatabaseTransaction : IDatabaseTransaction
    {
        private readonly ApplicationDbContext _context;
        private IDbContextTransaction _dbContextTransaction;
        JobSearch.Infrastructure.Repositories.DatabaseTransaction _transaction;
        public DatabaseTransaction(ApplicationDbContext context)
        {
            _context = context;
            //_transaction = _context.Database.BeginTransactionAsync();
        }

        

        public void Commit()
        {
            //tra
            
        }

        public void Dispose()
        {
            _transaction.Dispose();
        }

        public void Rollback()
        {
            //_context.;
        }


    }
}
