using NSerio.EvidenceTracker.Core.Repositories;
using NSerio.EvidenceTracker.Interfaces;
using Relativity.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSerio.EvidenceTracker.Core.Model;
using NSerio.EvidenceTracker.Core.Context;

namespace NSerio.EvidenceTracker.Managers
{
    public class EvidenceManager : BaseManager, IEvidenceManager
    {
        private IEvidenceRepository repo => new EvidenceRepository();

        public EvidenceManager() : base(Services.Helper)
        {

        }

        internal EvidenceManager(IServiceHelper testsHelper) : base(testsHelper)
        {

        }

        public async Task<IEnumerable<Evidence>> GetEvidencesAsync(int workspaceID)
        {
            await Task.Yield();
            RepositoryContext.SetWorkspace(() => workspaceID);
            return repo.GetEvidences();

        }

        public async Task<Evidence> GetEvidenceAsync(int workspaceID, int evidenceID)
        {
            await Task.Yield();
            RepositoryContext.SetWorkspace(() => workspaceID);
            return repo.GetEvidence(evidenceID);
        }

        public async Task<Evidence> CreateEvidenceAsync(int workspaceID, Evidence evidence)
        {
            await Task.Yield();
            RepositoryContext.SetWorkspace(() => workspaceID);
            return repo.CreateEvidence(evidence);
        }

        public async Task<bool> UpdateEvidence(int workspaceID, Evidence evidence)
        {
            await Task.Yield();
            RepositoryContext.SetWorkspace(() => workspaceID);
            return repo.UpdateEvidence(evidence);
        }
    }
}
