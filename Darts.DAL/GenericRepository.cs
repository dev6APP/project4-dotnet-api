using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BackEnd.DAL
{
    public abstract class GenericRepository<T>
         : IGenericRepository<T> where T : class
    {
        protected BackEndContext _context;
        protected DbSet<T> _table = null;

        public GenericRepository(BackEndContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }
    

        public virtual async Task<T> GetAsync(long id)
        {
            return await _context.FindAsync<T>(id);
        }

        public virtual T? Get(long id)
        {
            return _context.Find<T>(id);
        }

        public virtual async Task<IEnumerable<T>> AllAsync()
        {
            return await _table.ToListAsync();
        }

        public virtual IQueryable<T> AllQuery()
        {
            return  _table.AsQueryable<T>();
        }

        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> filter)
        {
            return await _table.Where(filter) // .AsQueryable() before where?
                .ToListAsync();
        }

        public virtual T Update(T entity)
        {
            return _context.Update(entity)
                .Entity;
        }

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _table;

            foreach (Expression<Func<T, object>> include in includes)
                query = query.Include(include);


            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return query.ToList();
        }

        public virtual async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            params Expression<Func<T, object>>[] includes)
        {
            IQueryable<T> query = _table;

            foreach (Expression<Func<T, object>> include in includes)
                query = query.Include(include);


            if (filter != null)
                query = query.Where(filter);

            if (orderBy != null)
                query = orderBy(query);

            return await query.ToListAsync();
        }

        public virtual void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public virtual T Add(T entity)
        {
            return _table
                .Add(entity)
                .Entity;
        }


    }
}
