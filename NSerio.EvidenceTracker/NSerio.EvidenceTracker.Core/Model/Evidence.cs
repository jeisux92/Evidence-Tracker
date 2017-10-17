using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSerio.EvidenceTracker.Core.Model
{
    public class Evidence : Artifact
    {
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public DateTime Date { get; set; }
        public Case Case { get; set; }
        public IEnumerable<Document> Documents { get; set; }
    }
}