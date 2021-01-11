using System.Runtime.Serialization;

namespace Mahamudra.ParallelDots.Dtos
{
    [DataContract]
    public class Sentiment 
    {
        [DataMember(Name = "negative")]
        public double Negative { get; set; }
        [DataMember(Name = "neutral")]
        public double Neutral { get; set; }
        [DataMember(Name = "positive")]
        public double Positive { get; set; }
    }

    [DataContract]
    public class SentimentDto
    {
        [DataMember(Name = "sentiment")]
        public Sentiment Sentiment { get; set; }
    }
}
 