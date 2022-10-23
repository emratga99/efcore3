using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using efcore3.Models;
using efcore3.Data;

namespace efcore3.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;

        private readonly ProductStoreContext _context;

        public BaseRepository(ProductStoreContext context)
        {
            _dbSet = context.Set<T>();
            _context = context;
        }
        public T Create(T model)
        {
            return _dbSet.Add(model).Entity;

        }

        public bool Delete(T model)
        {
            _dbSet.Remove(model);

            return true;
        }

        public T? GetById(Expression<Func<T, bool>>? predicate)
        {
            return predicate == null ? _dbSet.FirstOrDefault() : _dbSet.FirstOrDefault(predicate);

        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? predicate)
        {
            return predicate == null ? _dbSet : _dbSet.Where(predicate);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public T Update(T model)
        {
            return _dbSet.Update(model).Entity;
        }

        public IEntityDatabaseTransaction DatabaseTransaction()
        {
            return new EntityDatabaseTransaction(_context);
        }
    }
}