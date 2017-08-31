using AutoMapper;
using BeFree.Common;
using BeFree.Model.Common;
using BeFree.Service.Common;
using BeFreeAPI.ViewModels;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace BeFreeAPI.Controllers
{
    public class ReviewController : ApiController
    {
        protected IReviewService Service { get; private set; }

        public ReviewController(IReviewService service)
        {
            Service = service;
        }

        [HttpGet]
        public async Task<IHttpActionResult> Index()
        {
            var reviews = await Service.GetAsync(null);

            return Ok(new { results = reviews });
        }

        [Route("api/review/search")]
        [HttpGet]
        public async Task<IHttpActionResult> Search(string searchterm, int page = 1, int pageSize = 10)
        {
            Filter filter = new Filter()
            {
                SearchTerm = searchterm,
                Page = page,
                PageSize = pageSize
            };
            var reviews = await Service.GetAsync(filter);

            return Ok(new { results = reviews });
        }

        [Route("api/review/property")]
        [HttpGet]
        public async Task<IHttpActionResult> ListByProperty(Guid id, int page = 1, string sort = "ratedon_desc")
        {
            var reviews = await Service.GetByPropertyIdAsync(new PropertyFilter() { PropertyId = id, Page = page, OrderBy = sort, OrderAsc = sort.Contains("_asc") });

            return Ok(new { results = reviews });
        }

        [HttpGet]
        public async Task<IHttpActionResult> Get(Guid id)
        {
            ReviewViewModel vm = Mapper.Map<ReviewViewModel>(await Service.GetAsync(id));
            return Ok(vm);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Create(ReviewViewModel review)
        {
            review.Id = Guid.NewGuid();
            await Service.AddAsync(Mapper.Map<IReview>(review));
            return Ok();
        }
    }
}
