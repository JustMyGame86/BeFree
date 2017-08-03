using BeFree.Repository.Common;
using Ninject.Modules;

namespace BeFree.Repository
{
    public class DIModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICategoryRepository>().To<CategoryRepository>();
            Bind<IRepository>().To<Repository>();
        }
    }
}
