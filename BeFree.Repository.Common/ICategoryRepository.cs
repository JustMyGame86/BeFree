using BeFree.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFree.Repository.Common
{
    public interface ICategoryRepository
    {
        Task<int> AddAsync(ICategory category);
        Task<IEnumerable<ICategory>> GetAsync();
        Task<ICategory> GetAsync(Guid id);
    }
}
