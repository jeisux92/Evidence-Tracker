using NSerio.EvidenceTracker.Core.Model;
using System.Collections;
using System.Collections.Generic;

namespace NSerio.EvidenceTracker.Core.Repositories
{
    public interface IDocumentRepository
    {
        IEnumerable<Document> GetDocuments();

        bool UpdateDocument(Document document);
    }
}