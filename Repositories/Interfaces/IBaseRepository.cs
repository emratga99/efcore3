using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace efcore3.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);

        T? GetById(Expression<Func<T, bool>> predicate);

        T Create(T model);

        T Update(T model);

        bool Delete(T model);

        int SaveChanges();
        IEntityDatabaseTransaction DatabaseTransaction();
    }
}