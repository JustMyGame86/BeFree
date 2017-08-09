using AutoMapper;
using BeFree.Model;
using BeFree.Service.Common;
using BeFreeAPI.ViewModels;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace BeFreeAPI.Controllers
{
    public class CategoryController : ApiController
    {
        protected ICategoryService Service { get; private set; }
        public CategoryController(ICategoryService service)
        {
            Service = service;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Index()
        {
            var categories = await Service.GetAsync();

            return Ok(new { results = categories });
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(Guid id)
        {
            var category = await Service.GetAsync(id);
            CategoryViewModel vm = Mapper.Map<CategoryViewModel>(category);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Create(CategoryViewModel category)
        {
            category.Id = Guid.NewGuid();
            await Service.AddAsync(Mapper.Map<CategoryPOCO>(category));
            return Ok();
        }
    }
}