using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPortalAsyncAwait
{
    public class RootObjectAsyncValid : IObjectPortalHandleCreateAsync, IObjectPortalHandleCreateAsync<Criteria>, IObjectPortalHandleFetchAsync, IObjectPortalHandleFetchAsync<Criteria>
    {

        private BusinessObject _bo;

        public BusinessObject BusinessObject
        {
            get { return _bo; }
            private set { _bo = value; }
        }

        private BusinessObject _boAsync;

        public BusinessObject BusinessObjectCriteria
        {
            get { return _boAsync; }
            private set { _boAsync = value; }
        }


        // Injected Dependency

        private IObjectPortal<BusinessObject> _boPortal = new ObjectPortal<BusinessObject>();

        private IObjectPortal<BusinessObject> BusinessObjectPortal
        {
            get { return _boPortal; }
            set { _boPortal = value; }
        }


        // If you need ANY IObjectPortal calls
        // then be forced to go async
        // For all we know these calls will go to a different physical layer (leaving out the concept of ChildFetch)

        public async Task CreateAsync()
        {
            BusinessObject = await BusinessObjectPortal.CreateAsync();
            BusinessObjectCriteria = await BusinessObjectPortal.CreateAsync();
        }

        public async Task CreateAsync(Criteria criteria)
        {
            BusinessObject = await BusinessObjectPortal.CreateAsync();
            BusinessObjectCriteria = await BusinessObjectPortal.CreateAsync(criteria);
        }

        public async Task FetchAsync()
        {
            BusinessObject = await BusinessObjectPortal.FetchAsync();
            BusinessObjectCriteria = await BusinessObjectPortal.FetchAsync();
        }

        public async Task FetchAsync(Criteria criteria)
        {
            BusinessObject = await BusinessObjectPortal.FetchAsync();
            BusinessObjectCriteria = await BusinessObjectPortal.FetchAsync(criteria);

        }
    }
}
