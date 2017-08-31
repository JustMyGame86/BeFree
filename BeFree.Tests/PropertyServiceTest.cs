using BeFree.Common;
using BeFree.Model;
using BeFree.Repository;
using BeFree.Service;
using BeFree.Service.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace BeFree.Tests
{
    [TestClass]
    public class PropertyServiceTest
    {
        protected IPropertyService Service { get; private set; }
        public PropertyServiceTest()
        {
            Service = new PropertyService(new PropertyRepository(new Repository.Repository()));
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<ModelProfile>();
                cfg.CreateMissingTypeMaps = true;
            });
        }
        [TestMethod]
        public async Task GetAsyncTest()
        {
            var properties = await Service.GetAsync(null);

            Assert.IsTrue(properties.Count() <= 99);

            Filter filter = new Filter()
            {
                PageSize = 0,
                Page = 0
            };

            properties = await Service.GetAsync(filter);

            Assert.IsTrue(properties.Count() == 0);
        }
    }
}
