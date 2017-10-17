using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSerio.EvidenceTracker.Core.Model
{
    public class Case : Artifact
    {
        public IEnumerable<Evidence> Evidences { get; set; }
    }
}