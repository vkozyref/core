using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CoreApp.DataAccess.Repository
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetAsync(Expression<Func<T, bool>> predicate);
        Task<IList<T>> GetManyAsync(Expression<Func<T, bool>> predicate);
        void Delete(T item);
        void Update(T item);
        void Update(Expression<Func<T, bool>> predicate, Action<T> transform);
        void Create(T item);
    }
}
