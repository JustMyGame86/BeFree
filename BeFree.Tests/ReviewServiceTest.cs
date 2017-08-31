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
    /// <summary>
    /// Summary description for ReviewServiceTest
    /// </summary>
    [TestClass]
    public class ReviewServiceTest
    {
        protected IReviewService Service { get; private set; }
        public ReviewServiceTest()
        {
            Service = new ReviewService(new ReviewRepository(new Repository.Repository()));
            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<ModelProfile>();
                cfg.CreateMissingTypeMaps = true;
            });
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public async Task GetAsyncReviewTest()
        {
            var reviews = await Service.GetAsync(null);

            Assert.IsTrue(reviews.Count() <= 99);

            Filter filter = new Filter()
            {
                PageSize = 0,
                Page = 0
            };

            reviews = await Service.GetAsync(filter);

            Assert.IsTrue(reviews.Count() == 0);
        }
    }
}
