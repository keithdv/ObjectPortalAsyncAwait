using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPortalAsyncAwait
{
    public class ObjectPortal<T> : IObjectPortal<T>
        where T : new()
    {

        // Order of precedence is important
        // That IObjectPortalHandleXYZAsync is checked for before IObjectPortalHandleXYZ


        public async Task<T> CreateAsync()
        {
            var result = new T();
            var handleAsync = result as IObjectPortalHandleCreateAsync;

            if (handleAsync != null)
            {
                await handleAsync.CreateAsync();
            }

            else
            {
                // Allow the switch from Async to Synch
                var handle = result as IObjectPortalHandleCreate;

                if (handle != null)
                {
                    handle.Create();
                }
                else
                {
                    throw new ObjectPortalException();
                }
            }

            return result;
        }

        public async Task<T> CreateAsync<C>(C criteria)
        {
            var result = new T();

            var handleAsync = result as IObjectPortalHandleCreateAsync<C>;

            if (handleAsync != null)
            {
                await handleAsync.CreateAsync(criteria);
            }
            else
            {
                // Allow the switch from Async to Synch

                var handle = result as IObjectPortalHandleCreate<C>;

                if (handle != null)
                {
                    handle.Create(criteria);
                }
                else
                {
                    throw new ObjectPortalException();
                }
            }

            return result;
        }


        public async Task<T> FetchAsync()
        {
            var result = new T();
            var handleAsync = result as IObjectPortalHandleFetchAsync;

            if (handleAsync != null)
            {
                await handleAsync.FetchAsync();
            }

            else
            {
                // Allow the switch from Async to Synch
                var handle = result as IObjectPortalHandleFetch;

                if (handle != null)
                {
                    handle.Fetch();
                }
                else
                {
                    throw new ObjectPortalException();
                }
            }

            return result;
        }

        public async Task<T> FetchAsync<C>(C criteria)
        {
            var result = new T();

            var handleAsync = result as IObjectPortalHandleFetchAsync<C>;

            if (handleAsync != null)
            {
                await handleAsync.FetchAsync(criteria);
            }
            else
            {
                // Allow the switch from Async to Synch

                var handle = result as IObjectPortalHandleFetch<C>;

                if (handle != null)
                {
                    handle.Fetch(criteria);
                }
                else
                {
                    throw new ObjectPortalException();
                }
            }

            return result;
        }



    }


    [Serializable]
    public class ObjectPortalException : Exception
    {
        public ObjectPortalException() { }
        public ObjectPortalException(string message) : base(message) { }
        public ObjectPortalException(string message, Exception inner) : base(message, inner) { }
        protected ObjectPortalException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
