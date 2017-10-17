using NSerio.EvidenceTracker.Core.Model;
using System.Collections.Generic;

namespace NSerio.EvidenceTracker.Core.Repositories
{
    public interface IEvidenceRepository
    {
        IEnumerable<Evidence> GetEvidences();
        Evidence GetEvidence(int evidenceID);
        Evidence CreateEvidence(Evidence evidence);
        bool UpdateEvidence(Evidence evidence);
    }
}