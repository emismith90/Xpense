using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Xpense.Data.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        ICollection<T> GetAll();
        Task<ICollection<T>> GetAllAsync();

        T Get(object id);
        Task<T> GetAsync(object id);

        T Find(Expression<Func<T, bool>> match);
        Task<T> FindAsync(Expression<Func<T, bool>> match);
        
        ICollection<T> FindAll(Expression<Func<T, bool>> match);
        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match);

        T Add(T t);
        Task<T> AddAsync(T t);

        T Update(T updated, object key);
        Task<T> UpdateAsync(T updated, object key);
        
        void Delete(T t);
        Task<int> DeleteAsync(T t);
        
        int Count();
        Task<int> CountAsync();

        IQueryable<T> Table { get; }
        IQueryable<T> TableNoTracking { get; }
    }
}
