using System.Linq;
using NSerio.EvidenceTracker.Core.Model;
using Relativity.API;
using NSerio.EvidenceTracker.Core.Context;
using System.Collections.Generic;
using NSerio.EvidenceTracker.Core.Properties;
using System.Data;
using System;

namespace NSerio.EvidenceTracker.Core.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private IHelper _helper => RepositoryContext.CurrentHelper;
        private int _workspaceID => RepositoryContext.CurrentWorkspace;

        public IEnumerable<Document> GetDocuments()
        {
            string script = Scripts.GetDocuments;

            var documentsResult = _helper.GetDBContext(_workspaceID).ExecuteSqlStatementAsDataTable(script);
            var documents = documentsResult.AsEnumerable().Select(row => new Document { ArtifactID = (int)row["ArtifactID"], ControlNumber = row["ControlNumber"].ToString() });

            return documents;
        }

        public bool UpdateDocument(Document document)
        {
            string script = string.Format(Scripts.UpdateDocument, document.Evidence.ArtifactID, document.ArtifactID);
            var documentsResult = _helper.GetDBContext(_workspaceID).ExecuteNonQuerySQLStatement(script);
            return true;
        }
    }
}
