using Mahamudra.ParallelDots.CustomExtensions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Mahamudra.ParallelDots.Dtos
{
    [DataContract]
    public class KeywordText
    {
        [DataMember(Name = "keyword")]
        public string Keyword { get; set; }

        [DataMember(Name = "confidence_score")]
        public string ConfidenceScore { get; set; }
        [DataMember(Name = "relevance_score")]
        public double RelevanceScore { get; set; }

    }

    [DataContract]
    public class KeywordsDto
    {
        [DataMember(Name = "keywords")]
        [JsonProperty("keywords")]
        [JsonConverter(typeof(KeywordsDtoDataConverter))]
        public  List<KeywordText> Keywords { get; set; }
    } 
}


