using BeFree.Model.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeFree.Service.Common
{
    public interface ICategoryService
    {
        Task<IEnumerable<ICategory>> GetAsync();
        Task<ICategory> GetAsync(int id);
    }
}
