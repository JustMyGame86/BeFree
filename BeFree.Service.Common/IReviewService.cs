using BeFree.Common;
using BeFree.Model.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeFree.Service.Common
{
    public interface IReviewService
    {
        Task<int> AddAsync(IReview review);
        Task<IEnumerable<IReview>> GetAsync(IFilter filter);
        Task<IReview> GetAsync(Guid id);
        /// <summary>
        /// Gets reviews for the given property
        /// </summary>
        /// <param name="filter">Filter object used to filter, sort and page the results</param>
        /// <returns>Reviwes</returns>
        Task<IEnumerable<IReview>> GetByPropertyIdAsync(IPropertyFilter filter);
    }
}
