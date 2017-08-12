using BeFree.Model.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BeFree.Service.Common
{
    public interface IPropertyService
    {
        Task<int> AddAsync(IProperty property);
        Task<IEnumerable<IProperty>> GetAsync();
        Task<IProperty> GetAsync(Guid id);
    }
}
