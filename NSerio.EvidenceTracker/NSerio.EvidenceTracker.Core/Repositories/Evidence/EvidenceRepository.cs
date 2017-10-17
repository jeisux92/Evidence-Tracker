using System;
using System.Collections.Generic;
using NSerio.EvidenceTracker.Core.Model;
using NSerio.EvidenceTracker.Core.Context;
using Relativity.API;
using System.Data.SqlClient;
using NSerio.EvidenceTracker.Core.Properties;
using System.Linq;
using System.Data;

namespace NSerio.EvidenceTracker.Core.Repositories
{
    public class EvidenceRepository : IEvidenceRepository
    {
        private IHelper _helper => RepositoryContext.CurrentHelper;
        private int _workspaceID => RepositoryContext.CurrentWorkspace;

        public Evidence CreateEvidence(Evidence evidence)
        {
            var context = _helper.GetDBContext(_workspaceID);

            context.BeginTransaction();

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@User", RepositoryContext.CurrentAuthentication.UserInfo.ArtifactID));
            parameters.Add(new SqlParameter("@Type", Constants.EVIDENCE_OBJECT_GUID));
            parameters.Add(new SqlParameter("@Name", evidence.Name));
            parameters.Add(new SqlParameter("@Latitude", evidence.Latitude));
            parameters.Add(new SqlParameter("@Longitude", evidence.Longitude));
            parameters.Add(new SqlParameter("@Date", evidence.Date));
            parameters.Add(new SqlParameter("@Case", evidence.Case.ArtifactID));

            evidence.ArtifactID = context.ExecuteSqlStatementAsScalar<int>(Scripts.CreateEvidence, parameters);

            context.CommitTransaction();

            return evidence;
        }

        public Evidence GetEvidence(int evidenceID)
        {
            return GetEvidences().First(evidence => evidence.ArtifactID == evidenceID);
        }

        public IEnumerable<Evidence> GetEvidences()
        {
            string script = Scripts.GetEvidence;

            var casesResult = _helper.GetDBContext(_workspaceID).ExecuteSqlStatementAsDataTable(script);
            var cases = casesResult.AsEnumerable().Select(row => new Evidence
            {
                ArtifactID = (int)row["ArtifactID"],
                Name = row["Name"].ToString(),
                Latitude = row["Latitude"].ToString(),
                Longitude = row["Longitude"].ToString(),
                Date = (DateTime)row["Date"]
            });

            return cases;
        }

        public bool UpdateEvidence(Evidence evidence)
        {
            var context = _helper.GetDBContext(_workspaceID);

            context.BeginTransaction();

            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@ID", evidence.ArtifactID));
            parameters.Add(new SqlParameter("@Latitude", evidence.Latitude));
            parameters.Add(new SqlParameter("@Longitude", evidence.Longitude));
            parameters.Add(new SqlParameter("@Date", evidence.Date));

            evidence.ArtifactID = context.ExecuteSqlStatementAsScalar<int>(Scripts.UpdateEvidence, parameters);

            context.CommitTransaction();

            return true;
        }
    }
}
