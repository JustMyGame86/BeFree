using BeFree.Common;
using BeFree.Model.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeFree.Service.Common
{
    public interface IPropertyService
    {
        Task<int> AddAsync(IProperty property);
        Task<IEnumerable<IProperty>> GetAsync(IFilter filter);
        Task<IProperty> GetAsync(Guid id);
        Task<IEnumerable<IProperty>> GetLastAsync(int n);
        /// <summary>
        /// Returns top n properties ordered by AverageRating
        /// </summary>
        /// <param name="n">Number of properties to return</param>
        /// <returns></returns>
        Task<IEnumerable<IPropertyRating>> GetRatingsAsync(int n);
        /// <summary>
        /// Returns rating info of a property
        /// </summary>
        /// <param name="propertyId">Property identifier of a wanted property</param>
        /// <returns>rating info</returns>
        Task<IPropertyRating> GetRatingAsync(Guid propertyId);
    }
}
