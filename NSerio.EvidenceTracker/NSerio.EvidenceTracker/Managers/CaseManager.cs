using NSerio.EvidenceTracker.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSerio.EvidenceTracker.Core.Model;
using NSerio.EvidenceTracker.Core.Repositories;
using Relativity.API;
using NSerio.EvidenceTracker.Core.Context;

namespace NSerio.EvidenceTracker.Managers
{
    public class CaseManager : BaseManager, ICaseManager
    {
        private ICaseRepository repo => new CaseRepository();

        public CaseManager() : base(Services.Helper)
        {

        }

        internal CaseManager(IServiceHelper testsHelper) : base(testsHelper)
        {

        }

        public async Task<Case> CreateCaseAsync(int workspaceID, Case entity)
        {
            await Task.Yield();
            RepositoryContext.SetWorkspace(() => workspaceID);
            return repo.CreateCase(entity);

        }

        public async Task<IEnumerable<Case>> GetCasesAsync(int workspaceID)
        {
            await Task.Yield();
            RepositoryContext.SetWorkspace(() => workspaceID);
            return repo.GetCases();
        }
    }
}
