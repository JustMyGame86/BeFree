using AutoMapper;
using BeFree.Common;
using BeFree.DAL.Model;
using BeFree.Model.Common;
using BeFree.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
            {
                filter = new Filter()
                {
                    PageSize = 10,
                    Page = 1,
                    OrderBy = "ratedon"
                };
            }

            if (string.IsNullOrWhiteSpace(filter.OrderBy))
            {
                filter.OrderBy = "ratedon";
            }

            var filtered = Repository.GetWhere<Review>();

            if (!String.IsNullOrWhiteSpace(filter.SearchTerm))
                filtered = filtered.Where(w => w.Property.name.Contains(filter.SearchTerm) || w.Property.address.Contains(filter.SearchTerm));

            filtered = filtered.OrderByDyn(filter.OrderBy, filter.OrderAsc)
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
            if (filter == null)
            {
                filter = new PropertyFilter()
                {
                    Page = 1,
                    PageSize = 10,
                    OrderBy = "id"
                };
            }
            if (String.IsNullOrWhiteSpace(filter.OrderBy))
            {
                filter.OrderBy = "id";
            }
            var reviews = Repository.GetWhere<Review>()
                            .Where(r => r.propertyid == filter.PropertyId);

            if (!String.IsNullOrWhiteSpace(filter.SearchTerm))
                reviews = reviews.Where(w => w.Property.name.Contains(filter.SearchTerm) || w.Property.address.Contains(filter.SearchTerm));

            reviews = reviews.OrderByDyn(filter.OrderBy, filter.OrderAsc)
                            .ThenByDyn("id", true)
                            .Skip(filter.Skip)
                            .Take(filter.PageSize);

            return Mapper.Map<IEnumerable<IReview>>(await reviews.ToListAsync());
        }
    }
}
