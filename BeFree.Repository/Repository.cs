using BeFree.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BeFree.Repository
{
    public class Repository : IRepository
    {

        protected DAL.Model.BeFreeEntities DbContext { get; private set; }

        public Repository()
        {
            DbContext = new DAL.Model.BeFreeEntities();
        }

        public virtual async Task<int> AddAsync<T>(T entity) where T : class
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Added;
            }
            else
            {
                DbContext.Set<T>().Add(entity);
            }
            try
            {
                return await DbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
                throw;
            }
            
        }

        public virtual async Task<int> DeleteAsync<T>(T entity) where T : class
        {
            DbEntityEntry dbEntityEntry = DbContext.Entry(entity);
            if (dbEntityEntry.State != EntityState.Deleted)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                DbContext.Set<T>().Attach(entity);
                DbContext.Set<T>().Remove(entity);
            }
            return await DbContext.SaveChangesAsync();
        }

        public virtual async Task<int> DeleteAsync<T>(Guid id) where T : class
        {
            var entity = await GetByIDAsync<T>(id);
            if (entity == null)
            {
                throw new KeyNotFoundException("Entity with specified id not found.");
            }
            return await DeleteAsync<T>(entity);
        }

        public virtual Task<List<T>> GetAsync<T>() where T : class
        {
            return DbContext.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetByIDAsync<T>(Guid id) where T : class
        {
            return await DbContext.Set<T>().FindAsync(id);
        }

        public virtual IQueryable<T> GetWhere<T>() where T : class
        {
            return DbContext.Set<T>();
        }

        public Task<int> UpdateAsync<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
