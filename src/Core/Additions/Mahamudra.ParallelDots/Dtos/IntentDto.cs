using Mahamudra.ParallelDots.CustomExtensions;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Mahamudra.ParallelDots.Dtos
{
    [DataContract]
    public class Tag
    {
        [DataMember(Name = "complaint")]
        public double Complaint { get; set; }

        [DataMember(Name = "suggestion")]
        public double Suggestion { get; set; }

        [DataMember(Name = "appreciation")]
        public double Appreciation { get; set; }
    }

    [DataContract]
    public class Feedback
    {
        [DataMember(Name = "score")]
        public double Score { get; set; }

        [DataMember(Name = "tag")]
        public Tag Tag { get; set; }
    } 

    [DataContract]
    public class IntentListDto
    {
        [DataMember(Name = "intent")]
        public List<IntentDto> Intent { get; set; }
    }


    [DataContract]
    public class Intent
    {
        [DataMember(Name = "news")]
        public double News { get; set; }
        [DataMember(Name = "query")]
        public double Query { get; set; }
        [DataMember(Name = "spam")]
        public double Spam { get; set; }
        [DataMember(Name = "marketing")]
        public double Marketing { get; set; }

        [DataMember(Name = "feedback")]
        [JsonProperty("feedback")]
        [JsonConverter(typeof(FeedbackDataConverter))]
        public Feedback Feedback { get; set; }
    }

    [DataContract]
    public class IntentDto
    {
        [DataMember(Name = "intent")]
        public Intent Intent { get; set; }
    }

}
