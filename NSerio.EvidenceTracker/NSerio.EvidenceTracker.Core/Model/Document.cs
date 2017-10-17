using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSerio.EvidenceTracker.Core.Model
{
    public class Document : Artifact
    {
        public string ControlNumber { get; set; }
        public Evidence Evidence { get; set; }
    }
}   