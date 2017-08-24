using BeFree.Common;
using BeFree.Model.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeFree.Repository.Common
{
    public interface IPropertyRepository
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
    }
}
