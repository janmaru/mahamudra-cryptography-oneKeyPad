using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Mahamudra.ParallelDots.Dtos
{
    [DataContract]
    public class EntityListDto
    {
        [DataMember(Name = "entities")]
        public List<List<Entity>> Entities { get; set; }
    }
}
 