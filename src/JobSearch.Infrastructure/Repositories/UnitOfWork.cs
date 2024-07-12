﻿using JobSearch.Application.Repositories;
using JobSearch.Application.Repositories.Category;
using JobSearch.Application.Repositories.Company;
using JobSearch.Application.Repositories.Seniority;
using JobSearch.Infrastructure.Data;

namespace JobSearch.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Companies = new CompanyRepository(_context);
            Categories = new CategoryRepository(_context);
            Seniorities = new SeniorityRepository(_context);

        }

        public ICompanyRepository Companies { get; private set; }

        public ICategoryRepository Categories { get; private set; }

        public ISeniorityRepository Seniorities { get; private set; }

        public async Task Complete() => await _context.SaveChangesAsync();

        public async Task DisposeAsync() => await _context.DisposeAsync();
        public void Dispose() => _context.Dispose();


    }
}
