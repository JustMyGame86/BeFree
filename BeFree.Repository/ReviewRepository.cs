using BeFree.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeFree.Model.Common;
using AutoMapper;
using BeFree.DAL.Model;
using System.Data.Entity;

namespace BeFree.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        protected IRepository Repository { get; private set; }

        public ReviewRepository(IRepository repository)
        {
            this.Repository = repository;
        }
        public virtual async Task<int> AddAsync(IReview review)
        {
            return await Repository.AddAsync(Mapper.Map<Review>(review));
        }

        public virtual async Task<IEnumerable<IReview>> GetAsync()
        {
            return Mapper.Map<IEnumerable<IReview>>(await Repository.GetWhere<Review>().ToListAsync());
        }

        public virtual async Task<IReview> GetAsync(Guid id)
        {
            return Mapper.Map<IReview>(await Repository.GetByIDAsync<Review>(id));
        }
    }
}
