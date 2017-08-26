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
using BeFree.Common;
using System.Diagnostics;

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

        public virtual async Task<IEnumerable<IReview>> GetAsync(IFilter filter)
        {
            if (filter == null)
                return Mapper.Map<IEnumerable<IReview>>(await Repository.GetWhere<Review>().Take(10).ToListAsync());

            var filtered = Repository.GetWhere<Review>()
                .Skip(filter.Skip)
                .Take(filter.PageSize);
            return Mapper.Map<IEnumerable<IReview>>(await filtered.ToListAsync());
        }

        public virtual async Task<IReview> GetAsync(Guid id)
        {
            return Mapper.Map<IReview>(await Repository.GetByIDAsync<Review>(id));
        }

        public virtual async Task<IEnumerable<IReview>> GetByPropertyIdAsync(IPropertyFilter filter)
        {
            //var reviews = Repository.GetWhere<Review>()
            //    .Where(w => w.propertyid == filter.PropertyId);

            //Trace.WriteLine(reviews.ToList().Count);
            
            return Mapper.Map<IEnumerable<IReview>>(await Repository.GetWhere<Review>()
                .Where(w => w.propertyid == filter.PropertyId)
                .OrderByDescending(o => o.ratedon)
                .ThenByDescending(o => o.id)
                .Skip(filter.Skip)
                .Take(filter.PageSize)
                .ToListAsync());
        }
    }
}
