using System.Collections;

namespace Mahamudra.Cryptography.OneKeyPad
{
    public class Text:Content
    {
        public Text(BitArray bitArray) : base(bitArray) { }
        public Text(string textKey) : base(textKey) { }
        public Text(byte[] bytes) : base(bytes) { }
    }
}
