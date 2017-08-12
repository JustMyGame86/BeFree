using BeFree.Service.Common;
using Ninject.Modules;

namespace BeFree.Service
{
    public class DIModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICategoryService>().To<CategoryService>();
            Bind<IPropertyService>().To<PropertyService>();
            Bind<IReviewService>().To<ReviewService>();
        }
    }
}
