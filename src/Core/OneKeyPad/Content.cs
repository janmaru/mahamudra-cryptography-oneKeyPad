using Mahamudra.Cryptography.OneKeyPad.CustomExtensions;
using System.Collections;

namespace Mahamudra.Cryptography.OneKeyPad
{
    public abstract class Content
    {
        private readonly BitArray _bitArray;

        public Content(BitArray bitArray)
        {
            _bitArray = bitArray;
        }

        public Content(string textKey)
        {
            _bitArray = textKey.ToBitArray();
        }

        public Content(byte[] bytes)
        {
            _bitArray = bytes.ToBitArray();
        }

        public BitArray GetKeyBitArray()
        {
            return _bitArray;
        }

        public byte[] GetKeyByteArray()
        {
            return _bitArray.ToBytes();
        }

        public string GetKeyString()
        {
            return _bitArray.ToString();
        }
    }
}
