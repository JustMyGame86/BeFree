using BeFree.Model.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeFree.Service.Common
{
    public interface IReviewService
    {
        Task<int> AddAsync(IReview review);
        Task<IEnumerable<IReview>> GetAsync();
        Task<IReview> GetAsync(Guid id);
    }
}
