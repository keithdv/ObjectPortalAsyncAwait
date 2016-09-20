using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPortalAsyncAwait
{
    public class RootObjectAsyncInValid : IObjectPortalHandleFetch<Criteria>, IObjectPortalHandleCreate
    {

        private BusinessObject _bo;

        public BusinessObject Child
        {
            get { return _bo; }
            set { _bo = value; }
        }


        // Injected Dependency

        private IObjectPortal<BusinessObject> _boPortal;

        public IObjectPortal<BusinessObject> ChildPortal
        {
            get { return _boPortal; }
            set { _boPortal = value; }
        }

        // Hinder a nested Async within a non-async
        // Since IObjectPortal only has Async methods this isn't possible without
        // them manually managing the Task by doing a .Result or something
        // At least they'll realize "Hey, I need to do something with Async here"
        // Don't hide it under the covers

        public void Create()
        {
            //Child = ChildPortal.CreateAsync();
        }

        // We can call this function in a synchronous manner at the end of the Async calls
        public void Fetch(Criteria criteria)
        {
            //Child = ChildPortal.FetchAsync(criteria);
        }
    }
}
