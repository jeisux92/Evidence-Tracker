using System;
using System.Collections.Generic;
using NSerio.EvidenceTracker.Core.Context;
using NSerio.EvidenceTracker.Core.Model;
using Relativity.API;
using NSerio.EvidenceTracker.Core.Properties;
using System.Data;
using System.Data.SqlClient;

namespace NSerio.EvidenceTracker.Core.Repositories
{
    public class CaseRepository : ICaseRepository
    {
        private IHelper _helper => RepositoryContext.CurrentHelper;
        private int _workspaceID => RepositoryContext.CurrentWorkspace;

        public Case CreateCase(Case caseO)
        {
            var context = _helper.GetDBContext(_workspaceID);

            context.BeginTransaction();

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@User", RepositoryContext.CurrentAuthentication.UserInfo.ArtifactID));
            parameters.Add(new SqlParameter("@Type", Constants.CASE_OBJECT_GUID));
            parameters.Add(new SqlParameter("@CaseName", caseO.Name));

            caseO.ArtifactID = context.ExecuteSqlStatementAsScalar<int>(Scripts.CreateCase, parameters);

            context.CommitTransaction();

            return caseO;
        }

        public IEnumerable<Case> GetCases()
        {
            string script = Scripts.GetCases;

            var casesResult = _helper.GetDBContext(_workspaceID).ExecuteSqlStatementAsDataTable(script);
            var cases = casesResult.AsEnumerable().Select(row => new Case { ArtifactID = (int)row["ArtifactID"], Name = row["Name"].ToString() });

            return cases;
        }
    }
}