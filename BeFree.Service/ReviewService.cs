using BeFree.Model.Common;
using BeFree.Repository.Common;
using BeFree.Service.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public Task<IEnumerable<IReview>> GetAsync()
        {
            return Repository.GetAsync();
        }

        public Task<IReview> GetAsync(Guid id)
        {
            return Repository.GetAsync(id);
        }
    }
}
