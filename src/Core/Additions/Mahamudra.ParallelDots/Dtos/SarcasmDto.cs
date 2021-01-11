using System.Runtime.Serialization;

namespace Mahamudra.ParallelDots.Dtos
{
    [DataContract]
    public class SarcasmDto
    {
        [DataMember(Name = "Sarcastic")]
        public double Sarcastic { get; set; }
        [DataMember(Name = "Non-Sarcastic")] 
        public double NonSarcastic { get; set; }
    }
}
 