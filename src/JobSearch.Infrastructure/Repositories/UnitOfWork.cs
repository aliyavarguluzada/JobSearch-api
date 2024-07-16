using Microsoft.EntityFrameworkCore.Storage;

namespace JobSearch.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IDbContextTransaction _currentTransaction;

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
            FavoritesRead = new FavoriteReadRepository(_context);
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

        public IFavoriteReadRepository FavoritesRead { get; private set; }

        public async Task CompleteAsync() => await _context.SaveChangesAsync();
        public async Task SaveAsync() => await _context.SaveChangesAsync();
        public async Task DisposeAsync() => await _context.DisposeAsync();
        public void Dispose() => _context.Dispose();

        public async Task BeginTransactionAsync()
        {
            if (_currentTransaction == null)
            {
                _currentTransaction = await _context.Database.BeginTransactionAsync();
            }
        }

        public async Task CommitTransactionAsync()
        {
            try
            {
                await CompleteAsync();
                _currentTransaction?.Commit();
            }
            catch
            {
                await RollbackTransactionAsync();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public async Task RollbackTransactionAsync()
        {
            try
            {
                await _currentTransaction?.RollbackAsync();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }
    }
}
