using BeFree.Model.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeFree.Service.Common
{
    public interface ICategoryService
    {
        Task<IEnumerable<ICategory>> GetAsync();
        Task<ICategory> GetAsync(Guid id);
        Task<int> AddAsync(ICategory category);
    }
}
