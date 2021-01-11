using System.Collections;

namespace Mahamudra.Cryptography.OneKeyPad
{
    public class Cypher : Content
    {
        public Cypher(BitArray bitArray) : base(bitArray) { }
        public Cypher(string textKey) : base(textKey) { }
        public Cypher(byte[] bytes) : base(bytes) { }
    }
}
