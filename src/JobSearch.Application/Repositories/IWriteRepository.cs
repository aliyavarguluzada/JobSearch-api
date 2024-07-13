using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSearch.Application.Repositories
{
    internal interface IWriteRepository<TEntity>
    {
        void Add(TEntity objModel);
        void AddRange(IEnumerable<TEntity> objModel);
    }
}
