using JobSearch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace JobSearch.Application.Repositories
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        DbSet<TEntity> Table { get; }
        Task Complete();


    }
}
