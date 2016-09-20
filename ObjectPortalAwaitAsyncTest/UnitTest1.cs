using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObjectPortalAsyncAwait;
using System.Threading.Tasks;

namespace ObjectPortalAwaitAsyncTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task BusinessObject_Create()
        {

            var portal = new ObjectPortal<BusinessObject>();

            // Doesn't really matter that BusinesObject.Create is not async
            // Takes no special handling in ObjectPortal
            var result = await portal.CreateAsync();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task BusinessObject_Fetch()
        {
            var portal = new ObjectPortal<BusinessObject>();

            var criteria = new Criteria();

            var result = await portal.FetchAsync(criteria);

            Assert.AreEqual(result.Value, criteria.Value);

        }

        [TestMethod]
        public async Task BusinessObjectAsync_Create()
        {

            var portal = new ObjectPortal<RootObjectAsyncValid>();

            var result = await portal.CreateAsync();

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.BusinessObject);
            Assert.IsNotNull(result.BusinessObjectCriteria);

        }


        [TestMethod]
        public async Task BusinessObjectAsync_Create_Criteria()
        {

            var portal = new ObjectPortal<RootObjectAsyncValid>();

            var criteria = new Criteria();

            var result = await portal.CreateAsync(criteria);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.BusinessObject);
            Assert.IsNotNull(result.BusinessObjectCriteria);

        }

        [TestMethod]
        public async Task BusinessObjectAsync_Fetch()
        {

            var portal = new ObjectPortal<RootObjectAsyncValid>();

            var result = await portal.FetchAsync();

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.BusinessObject);
            Assert.IsNotNull(result.BusinessObjectCriteria);

        }

        [TestMethod]
        public async Task BusinessObjectAsync_Fetch_Criteria()
        {

            var portal = new ObjectPortal<RootObjectAsyncValid>();

            var criteria = new Criteria();

            var result = await portal.FetchAsync(criteria);

            Assert.IsNotNull(result);
            Assert.IsNotNull(result.BusinessObject);
            Assert.IsNotNull(result.BusinessObjectCriteria);


            Assert.AreEqual(result.BusinessObjectCriteria.Value, criteria.Value);
            Assert.AreNotEqual(result.BusinessObject.Value, criteria.Value);
        }

    }
}
