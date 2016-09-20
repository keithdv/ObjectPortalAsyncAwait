using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPortalAsyncAwait
{
    public interface IObjectPortal<T>
    {
        // Purposfully only provide AsyncMethods
        // Require an Async method to use ObjectPortal
        // so that there's no possiblity of going from Sync to Async to Sync....


        Task<T> FetchAsync();
        Task<T> FetchAsync<C>(C criteria);
        Task<T> CreateAsync();
        Task<T> CreateAsync<C>(C criteria);

    }
}
