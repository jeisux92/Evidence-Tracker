using NSerio.EvidenceTracker.Core.Model;
using Relativity.Kepler.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NSerio.EvidenceTracker.Interfaces
{
    [WebService("DocumentManager")]
    [ServiceAudience(Audience.Private)]
    public interface IDocumentManager : IDisposable
    {
        Task<IEnumerable<Document>> GetDocumentsAsync(int workspaceID);

        Task<bool> UpdateDocumentAsync(int workspaceID, Document document);
    }
}