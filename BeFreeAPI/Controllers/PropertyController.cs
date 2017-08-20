using AutoMapper;
using BeFree.Model.Common;
using BeFree.Service.Common;
using BeFreeAPI.ViewModels;
using System;
using System.Collections.Generic;
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
            var properties = await Service.GetAsync(null);

            return Ok(new { results = properties });
        }

        [Route("api/property/last")]
        [HttpGet]
        public async Task<IHttpActionResult> Last(int n)
        {
            var properties = await Service.GetLastAsync(n);

            return Ok(new { results = properties });
        }

        [Route("api/property/rating")]
        [HttpGet]
        public async Task<IHttpActionResult> Rating(int n)
        {
            var ratings = await Service.GetRatingsAsync(n);
            var properties = Mapper.Map<IEnumerable<PropertyRatingViewModel>>(ratings);

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
