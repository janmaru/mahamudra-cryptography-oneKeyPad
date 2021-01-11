using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Mahamudra.ParallelDots.Dtos
{
    [DataContract]
    public class SimiliarityDto
    {
        [DataMember(Name = "similarity_score")]
        public double SimilarityScore { get; set; }
    }
}
 