using AutoMapper;
using BeFree.Model;
using BeFree.Model.Common;
using BeFree.Service.Common;
using BeFreeAPI.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace BeFreeAPI.Controllers
{
    public class CategoryController : ApiController
    {
        protected ICategoryService Service { get; set; }
        public CategoryController(ICategoryService service)
        {
            Service = service;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Index()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<CategoryViewModel, ICategory>().ReverseMap();
                cfg.CreateMap<CategoryViewModel, CategoryPOCO>().ReverseMap();
            });
            //var categories = Mapper.Map<IEnumerable<CategoryViewModel>>(await Service.GetAsync());
            var categories = await Service.GetAsync();

            return Ok(new { results = categories });
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(int id)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ICategory, CategoryViewModel>().ReverseMap();
                cfg.CreateMap<CategoryPOCO, CategoryViewModel>().ReverseMap();
            });
            Mapper.Configuration.AssertConfigurationIsValid();
            var category = await Service.GetAsync(id);
            CategoryViewModel vm = Mapper.Map<CategoryViewModel>(category);
            return Ok(vm);
        }
    }
}
