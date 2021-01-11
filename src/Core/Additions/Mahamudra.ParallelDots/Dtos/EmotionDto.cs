using System.Runtime.Serialization;

namespace Mahamudra.ParallelDots.Dtos
{
    public class Emotion
    {
        public double Bored { get; set; }
        public double Sad { get; set; }
        public double Angry { get; set; }
        public double Fear { get; set; }
        public double Happy { get; set; }
        public double Excited { get; set; }
    }

    [DataContract]
    public class EmotionDto
    {
        [DataMember(Name= "emotion")]
        public Emotion Emotion { get; set; }
    }
}


 