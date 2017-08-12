using BeFree.Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeFree.Model.Common;
using BeFree.Repository.Common;

namespace BeFree.Service
{
    public class PropertyService : IPropertyService
    {
        public IPropertyRepository Repository { get; private set; }

        public PropertyService(IPropertyRepository repository)
        {
            Repository = repository;
        }

        public Task<int> AddAsync(IProperty property)
        {
            return Repository.AddAsync(property);
        }

        public Task<IEnumerable<IProperty>> GetAsync()
        {
            return Repository.GetAsync();
        }

        public Task<IProperty> GetAsync(Guid id)
        {
            return Repository.GetAsync(id);
        }
    }
}
