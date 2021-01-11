using System.Runtime.Serialization;

namespace Mahamudra.ParallelDots.Dtos
{
    [DataContract]
    public class AbuseDto
    {
        [DataMember(Name = "abusive")]
        public double Abusive { get; set; }
        [DataMember(Name = "hate_speech")]
        public double HateSpeech { get; set; }
        [DataMember(Name = "neither")]
        public double Neither { get; set; } 
    }
}
