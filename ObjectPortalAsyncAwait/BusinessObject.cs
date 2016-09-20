using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPortalAsyncAwait
{

    // Object that doesn't require any dependencies only what's passed into .Create()
    // to be created

    public class BusinessObject : IObjectPortalHandleCreate, IObjectPortalHandleCreate<Criteria>, IObjectPortalHandleFetch, IObjectPortalHandleFetch<Criteria>
    {

        private Guid _value;

        public Guid Value
        {
            get { return _value; }
            set { _value = value; }
        }

        // We can do this in a synchronous manner at the end of the Async calls
        // Ok if there are no further ObjectPortal or other async operations

        public void Create()
        {
            Value = Guid.NewGuid();    
        }

        public void Create(Criteria c)
        {
            Value = c.Value;
        }

        public void Fetch()
        {
            Value = Guid.NewGuid();
        }

        // We can call this function in a synchronous manner at the end of the Async calls
        public void Fetch(Criteria criteria)
        {
            // Ok if there are no further Async operations
            Value = criteria.Value;
        }

    }
}
