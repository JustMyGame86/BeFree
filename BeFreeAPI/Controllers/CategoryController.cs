using AutoMapper;
using BeFree.Service.Common;
using BeFreeAPI.ViewModels;
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
        public async Task<IHttpActionResult> Get(int id)
        {
            var category = await Service.GetAsync(id);
            CategoryViewModel vm = Mapper.Map<CategoryViewModel>(category);
            return Ok(vm);
        }
    }
}
