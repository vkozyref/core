using CoreApp.DataAccess.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CoreApp.DataAccess.Repository
{
    internal class Repository<T> : IRepository<T> where T : class
    {
        private readonly UniversityContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(UniversityContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public void Create(T item)
        {
            _context.Entry(item).State = EntityState.Added;
        }

        public void Delete(T item)
        {
            _context.Entry(item).State = EntityState.Deleted;
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate)
        {
            var result = await _dbSet.SingleOrDefaultAsync(predicate);
            return result;
        }

        public async Task<IList<T>> GetManyAsync(Expression<Func<T, bool>> predicate)
        {
            var result = await _dbSet.Where(predicate).ToListAsync();
            return result;
        }

        public void Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
        }

        public void Update(Expression<Func<T, bool>> predicate, Action<T> transform)
        {
            var entity = _dbSet.SingleOrDefault(predicate);
            transform(entity);
        }
    }
}
