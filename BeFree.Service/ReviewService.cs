﻿using BeFree.Model.Common;
using BeFree.Repository.Common;
using BeFree.Service.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BeFree.Common;

namespace BeFree.Service
{
    public class ReviewService : IReviewService
    {
        protected IReviewRepository Repository { get; private set; }

        public ReviewService(IReviewRepository repository)
        {
            Repository = repository;
        }
        public Task<int> AddAsync(IReview review)
        {
            return Repository.AddAsync(review);
        }

        public Task<IEnumerable<IReview>> GetAsync(IFilter filter)
        {
            return Repository.GetAsync(filter);
        }

        public Task<IReview> GetAsync(Guid id)
        {
            return Repository.GetAsync(id);
        }

        public Task<IEnumerable<IReview>> GetByPropertyIdAsync(IPropertyFilter filter)
        {
            return Repository.GetByPropertyIdAsync(filter);
        }
    }
}
