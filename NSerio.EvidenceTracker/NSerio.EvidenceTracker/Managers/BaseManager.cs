using NSerio.EvidenceTracker.Core.Context;
using Relativity.API;
using System;

namespace NSerio.EvidenceTracker.Managers
{
    public abstract class BaseManager : IDisposable
    {
        public BaseManager(IServiceHelper helper)
        {
            RepositoryContext.SetHelper(() => helper);
            RepositoryContext.SetAuthenticationFnc(() => helper.GetAuthenticationManager());
        }
        public void Dispose()
        {
        }
    }
}