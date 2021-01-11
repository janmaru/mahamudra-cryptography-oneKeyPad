using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Mahamudra.ParallelDots.Dtos
{
    [DataContract]
    public class PhraseExtractorListDto
    {
        [DataMember(Name = "phrases")]
        public List<List<KeywordText>> Phrases { get; set; }
    }
}
