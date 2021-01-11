using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Mahamudra.ParallelDots.Dtos
{
    [DataContract]
    public class Taxonomy
    {
        [DataMember(Name = "confidence_score")]
        public double ConfidenceScore { get; set; }
        [DataMember(Name = "tag")]
        public string Tag { get; set; }
        [DataMember(Name = "category")]
        public string Category { get; set; }
    }
    [DataContract]
    public class TaxonomyDto
    {
        [DataMember(Name = "taxonomy")]
        public List<Taxonomy> Taxonomy { get; set; }
    }
}
