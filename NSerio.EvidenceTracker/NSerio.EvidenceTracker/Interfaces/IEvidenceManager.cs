using NSerio.EvidenceTracker.Core.Model;
using Relativity.Kepler.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NSerio.EvidenceTracker.Interfaces
{
    [WebService("EvidenceManager")]
    [ServiceAudience(Audience.Private)]
    public interface IEvidenceManager : IDisposable
    {
        Task<IEnumerable<Evidence>> GetEvidencesAsync(int workspaceID);
        Task<Evidence> GetEvidenceAsync(int workspaceID, int evidenceID);
        Task<Evidence> CreateEvidenceAsync(int workspaceID, Evidence evidence);
        Task<bool> UpdateEvidence(int workspaceID, Evidence evidence);
    }
}
