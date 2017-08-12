using AutoMapper;
using BeFree.DAL.Model;
using BeFree.Model;
using BeFree.Model.Common;
using BeFree.Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Linq;

namespace BeFree.Repository
{
    class PropertyRepository : IPropertyRepository
    {
        protected IRepository Repository { get; private set; }

        public PropertyRepository(IRepository repository)
        {
            Repository = repository;
        }

        public Task<int> AddAsync(IProperty property)
        {
            return Repository.AddAsync<Property>(Mapper.Map<Property>(property));
        }

        public virtual async Task<IEnumerable<IProperty>> GetAsync()
        {
            return Mapper.Map<IEnumerable<PropertyPOCO>>(await Repository.GetWhere<Property>().ToListAsync());
        }

        public virtual async Task<IProperty> GetAsync(Guid id)
        {
            return Mapper.Map<PropertyPOCO>(await Repository.GetByIDAsync<Property>(id));
        }
    }
}
