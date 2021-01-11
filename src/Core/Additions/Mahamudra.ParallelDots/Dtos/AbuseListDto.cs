using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Mahamudra.ParallelDots.Dtos
{
    [DataContract]
    public class AbuseListDto
    {
        [DataMember(Name = "abuse")]
        public List<AbuseDto> Abuse{ get; set; } 
    }
}
