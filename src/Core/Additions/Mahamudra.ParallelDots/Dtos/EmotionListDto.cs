using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Mahamudra.ParallelDots.Dtos
{
    [DataContract]
    public class EmotionListDto
    {
        [DataMember(Name = "emotion")]
        public List<Emotion> Emotion { get; set; }
    }
}


 