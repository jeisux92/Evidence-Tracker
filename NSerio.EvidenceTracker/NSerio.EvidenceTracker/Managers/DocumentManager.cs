using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NSerio.EvidenceTracker.Core.Model;
using NSerio.EvidenceTracker.Interfaces;
using Relativity.API;
using NSerio.EvidenceTracker.Core.Repositories;
using NSerio.EvidenceTracker.Core.Context;

namespace NSerio.EvidenceTracker.Managers
{
    public class DocumentManager : BaseManager, IDocumentManager
    {
        private IDocumentRepository repo => new DocumentRepository();

        public DocumentManager() : base(Services.Helper)
        {

        }

        internal DocumentManager(IServiceHelper testsHelper) : base(testsHelper)
        {

        }

        public async Task<IEnumerable<Document>> GetDocumentsAsync(int workspaceID)
        {
            await Task.Yield();
            RepositoryContext.SetWorkspace(() => workspaceID);
            return repo.GetDocuments();
        }

        public async Task<bool> UpdateDocumentAsync(int workspaceID, Document document)
        {
            await Task.Yield();
            RepositoryContext.SetWorkspace(() => workspaceID);
            return repo.UpdateDocument(document);
        }
    }
}