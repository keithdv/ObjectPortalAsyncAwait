using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectPortalAsyncAwait
{
    // Non-async interfaces exist to allow the last node/child
    // to be non-async
    public interface IObjectPortalHandleCreate
    {
        void Create();
    }

    public interface IObjectPortalHandleCreate<T>
    {
        void Create(T criteria);
    }

    public interface IObjectPortalHandleCreateAsync
    {
        Task CreateAsync();
    }

    public interface IObjectPortalHandleCreateAsync<T>
    {
        Task CreateAsync(T criteria);
    }

    public interface IObjectPortalHandleFetch
    {
        void Fetch();
    }

    public interface IObjectPortalHandleFetch<T>
    {
        void Fetch(T criteria);
    }

    public interface IObjectPortalHandleFetchAsync
    {
        Task FetchAsync();
    }

    public interface IObjectPortalHandleFetchAsync<T>
    {
        Task FetchAsync(T criteria);
    }

}
