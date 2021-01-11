using System.Collections;

namespace Mahamudra.Cryptography.OneKeyPad
{
    public class VernamKey : Content
    {
        public VernamKey(BitArray bitArray) : base(bitArray) { } 
        public VernamKey(string textKey) : base(textKey) { }  
        public VernamKey(byte[] bytes) : base(bytes) { } 
    }
}
