using AutoMapper;
using BeFree.Common;
using BeFree.DAL.Model;
using BeFree.Model.Common;
using BeFree.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

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

        /// <summary>
        /// Gets reviews for the given property
        /// </summary>
        /// <param name="filter">Filter object used to filter, sort and page the results</param>
        /// <returns>Reviwes</returns>
        public virtual async Task<IEnumerable<IReview>> GetByPropertyIdAsync(IPropertyFilter filter)
        {
            var reviews = from r in Repository.GetWhere<Review>()
                          where r.propertyid == filter.PropertyId
                          select r;

            reviews = reviews.OrderByDyn("ratedon", filter.Sort.Contains("_desc"))
                .ThenByDyn("id", true)
                .Skip(filter.Skip)
                .Take(filter.PageSize);

            return Mapper.Map<IEnumerable<IReview>>(await reviews.ToListAsync());
        }
    }
}
