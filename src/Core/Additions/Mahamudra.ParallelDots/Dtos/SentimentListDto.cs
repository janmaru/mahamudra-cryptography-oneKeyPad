using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Mahamudra.ParallelDots.Dtos
{

    [DataContract]
    public class SentimentListDto
    {
        [DataMember(Name = "sentiment")]
        public List<Sentiment> Sentiment { get; set; }
    }
}
 