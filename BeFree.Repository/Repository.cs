using BeFree.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public Task<int> AddAsync<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync<T>(Guid id) where T : class
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> GetAsync<T>() where T : class
        {
            return DbContext.Set<T>().ToListAsync();
        }

        public Task<T> GetByIDAsync<T>(Guid id) where T : class
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetWhere<T>() where T : class
        {
            return DbContext.Set<T>();
        }

        public Task<int> UpdateAsync<T>(T entity) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
