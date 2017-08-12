using AutoMapper;
using BeFree.Model.Common;
using BeFree.Service.Common;
using BeFreeAPI.ViewModels;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace BeFreeAPI.Controllers
{
    public class PropertyController : ApiController
    {
        protected IPropertyService Service { get; private set; }

        public PropertyController(IPropertyService service)
        {
            Service = service;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Index()
        {
            var properties = await Service.GetAsync();

            return Ok(new { results = properties });
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(Guid id)
        {
            PropertyViewModel vm = Mapper.Map<PropertyViewModel>(await Service.GetAsync(id));
            return Ok(vm);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Create(PropertyViewModel property)
        {
            property.Id = Guid.NewGuid();
            await Service.AddAsync(Mapper.Map<IProperty>(property));
            return Ok();
        }
    }
}
