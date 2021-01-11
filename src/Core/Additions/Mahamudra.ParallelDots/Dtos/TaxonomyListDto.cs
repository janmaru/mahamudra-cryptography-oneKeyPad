using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Mahamudra.ParallelDots.Dtos
{
    [DataContract]
    public class TaxonomyListDto
    {
        [DataMember(Name = "taxonomy")]
        public List<List<Taxonomy>> Taxonomy { get; set; }
    }
}
