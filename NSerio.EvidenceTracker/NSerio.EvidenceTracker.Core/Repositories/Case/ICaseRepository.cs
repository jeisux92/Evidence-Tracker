using NSerio.EvidenceTracker.Core.Model;
using System.Collections;
using System.Collections.Generic;

namespace NSerio.EvidenceTracker.Core.Repositories
{
    public interface ICaseRepository
    {
        IEnumerable<Case> GetCases();

        Case CreateCase(Case caseO);
    }
}
