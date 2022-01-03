using AdamStore.Infrastructure.EF;
using Application._Abstracts;
using Application.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdamStore.Infrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbFactory _dbFactory;
        private DbSet<T> _dbSet;

        public Repository(DbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public Repository(AdamStoreDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public AdamStoreDbContext DbContext { get; }
        protected DbSet<T> DbSet
        {
            get => _dbSet ?? (_dbSet = _dbFactory.DbContext.Set<T>());
        }

        public void Add(T entity)
        {
            if (typeof(IAuditEntity).IsAssignableFrom(typeof(T)))
            {
                ((IAuditEntity)entity).CreatedDate = DateTime.UtcNow;
            }
            DbSet.Add(entity);
        }

        public void AddMulti(List<T> entity)
        {
            DbSet.AddRange(entity);
        }

        public bool CheckContains(Expression<Func<T, bool>> expression)
        {
            return DbSet.Any(expression);
        }

        public int Count(Expression<Func<T, bool>> where)
        {
            return DbSet.Count(where);
        }

        public void Delete(T entity)
        {
            if (typeof(IDeleteEntity).IsAssignableFrom(typeof(T)))
            {
                ((IDeleteEntity)entity).IsDeleted = true;
                DbSet.Update(entity);
            }
            else
                DbSet.Remove(entity);
        }

        public void DeleteMulti(Expression<Func<T, bool>> expression, IEnumerable<T> listT)
        {
            var listToRemove = DbSet.Where(expression).AsQueryable();
            DbSet.RemoveRange(listToRemove);
        }

        public IQueryable<T> GetMultiPaging(Expression<Func<T, bool>> expression, out int total, int index = 0, int size = 50, string[] includes = null)
        {
            int skipCount = index * size;
            IQueryable<T> _resetSet;

            //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
            if (includes != null && includes.Any())
            {
                var query = DbSet.Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                _resetSet = expression != null ? query.Where<T>(expression).AsQueryable() : query.AsQueryable();
            }
            else
            {
                _resetSet = expression != null ? DbSet.Where<T>(expression).AsQueryable() : DbSet.AsQueryable();
            }

            _resetSet = skipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
            total = DbSet.Count();
            return _resetSet.AsQueryable();
        }

        public Task<T> GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null)
        {
            var query = DbSet.Include(includes.First());
            foreach (var include in includes.Skip(1))
                query = query.Include(include);

            return DbSet.Where(expression).AsQueryable<T>().FirstOrDefaultAsync();
        }

        public T GetSingleById(int id)
        {
            return DbSet.Find(id);
        }

        public IQueryable<T> List(Expression<Func<T, bool>> expression)
        {
            return DbSet.Where(expression);
        }

        public void Update(T entity)
        {
            if (typeof(IAuditEntity).IsAssignableFrom(typeof(T)))
            {
                ((IAuditEntity)entity).UpdatedDate = DateTime.UtcNow;
            }
            DbSet.Update(entity);
        }

        public void UpdateMultiByIds(IEnumerable<T> listT)
        {
            DbSet.UpdateRange(listT);
        }
    }
}