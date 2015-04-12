using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Data;
using System.Linq.Expressions;
using Xpense.Data.DataContext;
using System.Threading.Tasks;

namespace Xpense.Data.Infrastructure
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {
        private XpenseEntities _context;
        protected RepositoryBase(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
        }

        protected IDatabaseFactory DatabaseFactory
        {
            get;
            private set;
        }

        protected XpenseEntities DataContext
        {
            get { return _context ?? (_context = DatabaseFactory.Get()); }
        }

        public ICollection<T> GetAll()
        {
            return DataContext.Set<T>().ToList();
        }

        public async Task<ICollection<T>> GetAllAsync()
        {
            return await DataContext.Set<T>().ToListAsync();
        }

        public T Get(object id)
        {
            return DataContext.Set<T>().Find(id);
        }

        public async Task<T> GetAsync(object id)
        {
            return await DataContext.Set<T>().FindAsync(id);
        }

        public T Find(Expression<Func<T, bool>> match)
        {
            return DataContext.Set<T>().SingleOrDefault(match);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> match)
        {
            return await DataContext.Set<T>().SingleOrDefaultAsync(match);
        }

        public ICollection<T> FindAll(Expression<Func<T, bool>> match)
        {
            return DataContext.Set<T>().Where(match).ToList();
        }

        public async Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match)
        {
            return await DataContext.Set<T>().Where(match).ToListAsync();
        }

        public T Add(T t)
        {
            DataContext.Set<T>().Add(t);
            DataContext.SaveChanges();
            return t;
        }

        public async Task<T> AddAsync(T t)
        {
            DataContext.Set<T>().Add(t);
            await DataContext.SaveChangesAsync();
            return t;
        }

        public T Update(T updated, object key)
        {
            if (updated == null)
                return null;

            T existing = DataContext.Set<T>().Find(key);
            if (existing != null)
            {
                DataContext.Entry(existing).CurrentValues.SetValues(updated);
                DataContext.SaveChanges();
            }
            return existing;
        }

        public async Task<T> UpdateAsync(T updated, object key)
        {
            if (updated == null)
                return null;

            T existing = await DataContext.Set<T>().FindAsync(key);
            if (existing != null)
            {
                DataContext.Entry(existing).CurrentValues.SetValues(updated);
                await DataContext.SaveChangesAsync();
            }
            return existing;
        }

        public void Delete(T t)
        {
            DataContext.Set<T>().Remove(t);
            DataContext.SaveChanges();
        }

        public async Task<int> DeleteAsync(T t)
        {
            DataContext.Set<T>().Remove(t);
            return await DataContext.SaveChangesAsync();
        }

        public int Count()
        {
            return DataContext.Set<T>().Count();
        }

        public async Task<int> CountAsync()
        {
            return await DataContext.Set<T>().CountAsync();
        }

        public IQueryable<T> Table
        {
            get { return DataContext.Set<T>(); }
        }

        public IQueryable<T> TableNoTracking
        {
            get { return DataContext.Set<T>().AsNoTracking(); }
        }
    }
}
