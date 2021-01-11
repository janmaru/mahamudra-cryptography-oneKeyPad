using System.Collections;

namespace Mahamudra.Cryptography.OneKeyPad.Interfaces
{
    public interface IOneKeyPad
    {
        BitArray Cypher();
        BitArray DeCypher(BitArray cypher);
        BitArray Export();
        void Import(BitArray key);
    }
}