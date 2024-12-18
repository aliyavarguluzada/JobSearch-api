﻿using JobSearch.Domain.Entities;
using System.Linq.Expressions;

namespace JobSearch.Application.Repositories
{
    public interface IReadRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetAll(bool tracking = true);
        IQueryable<TEntity> GetWhere(Expression<Func<TEntity, bool>> method, bool tracking = true);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> method, bool tracking = true);
        Task<TEntity> GetByIdAsync(int id, bool tracking = true);
    }
}
