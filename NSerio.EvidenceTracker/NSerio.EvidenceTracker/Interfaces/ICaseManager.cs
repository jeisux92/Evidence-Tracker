using NSerio.EvidenceTracker.Core.Model;
using Relativity.Kepler.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NSerio.EvidenceTracker.Interfaces
{
    [WebService("CaseManager")]
    [ServiceAudience(Audience.Private)]
    public interface ICaseManager : IDisposable
    {
        Task<IEnumerable<Case>> GetCasesAsync(int workspaceID);
        Task<Case> CreateCaseAsync(int workspaceID, Case entity);
    }
}
