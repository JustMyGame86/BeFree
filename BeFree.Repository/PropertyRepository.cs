﻿using AutoMapper;
using BeFree.Common;
using BeFree.DAL.Model;
using BeFree.Model;
using BeFree.Model.Common;
using BeFree.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BeFree.Repository
{
    class PropertyRepository : IPropertyRepository
    {
        protected IRepository Repository { get; private set; }

        public PropertyRepository(IRepository repository)
        {
            Repository = repository;
        }

        public Task<int> AddAsync(IProperty property)
        {
            return Repository.AddAsync<Property>(Mapper.Map<Property>(property));
        }

        public virtual async Task<IEnumerable<IProperty>> GetAsync(IFilter filter)
        {
            if (filter == null)
            {
                return Mapper.Map<IEnumerable<PropertyPOCO>>(await Repository.GetWhere<Property>().Take(99).ToListAsync());
            }
            var filtered = Repository.GetWhere<Property>().Skip(filter.Skip).Take(filter.Page);
            return Mapper.Map<IEnumerable<PropertyPOCO>>(await filtered.ToListAsync());
        }

        public virtual async Task<IProperty> GetAsync(Guid id)
        {
            return Mapper.Map<PropertyPOCO>(await Repository.GetByIDAsync<Property>(id));
        }

        public virtual async Task<IEnumerable<IProperty>> GetLastAsync(int n)
        {
            var properties = Repository.GetWhere<Property>();
            var reviews = Repository.GetWhere<Review>();

            var last = (from p in properties
                        join r in reviews on p.id equals r.propertyid
                        orderby r.ratedon descending
                        select p).Take(n);

            return Mapper.Map<IEnumerable<PropertyPOCO>>(await last.ToListAsync());
        }
        /// <summary>
        /// Returns top n properties ordered by AverageRatiig
        /// </summary>
        /// <param name="n">Number of properties to return</param>
        /// <returns></returns>
        public virtual async Task<IEnumerable<IPropertyRating>> GetRatingsAsync(int n)
        {
            var ratings = from p in Repository.GetWhere<Property>()
                          join r in Repository.GetWhere<Review>() on p.id equals r.propertyid
                          group new { p, r } by p.id into grupa
                          select new
                          {
                              Id = grupa.FirstOrDefault().p.id,
                              Name = grupa.FirstOrDefault().p.name,
                              Address = grupa.FirstOrDefault().p.address,
                              Category = grupa.FirstOrDefault().p.Category,
                              AverageRating = grupa.Average(a => a.r.rating),
                              HighestRating = grupa.Max(a => a.r.rating),
                              LowestRating = grupa.Min(a => a.r.rating),
                              NumberOfReviews = grupa.Count()
                          };

            return Mapper.Map<IEnumerable<IPropertyRating>>(await ratings
                .OrderByDescending(o => o.AverageRating)
                .Take(n)
                .ToListAsync());
        }
    }
}
