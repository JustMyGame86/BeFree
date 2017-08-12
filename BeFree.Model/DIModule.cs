using BeFree.Model.Common;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFree.Model
{
    public class DIModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICategory>().To<CategoryPOCO>();
            Bind<IProperty>().To<PropertyPOCO>();
            Bind<IReview>().To<ReviewPOCO>();
        }
    }
}
