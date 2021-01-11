using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Mahamudra.ParallelDots.Dtos
{
    [DataContract]
    public class Entity
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "category")]
        public string Category { get; set; }
        [DataMember(Name = "confidence_score")]
        public double ConfidenceScore { get; set; }
    }

    [DataContract]
    public class EntityDto
    {
        [DataMember(Name = "entities")]
        public List<Entity> Entities { get; set; }
    }
}
