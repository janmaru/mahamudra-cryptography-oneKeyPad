using System;
using System.Collections;
using System.Text;

namespace Mahamudra.Cryptography.OneKeyPad.CustomExtensions
{
    public static class CryptoExtensions
    {
        public static byte[] ToBytes(this string text)
        {
            return Encoding.Unicode.GetBytes(text);
        }

        public static string ToText(this byte[] values)
        {
            return Encoding.Unicode.GetString(values, 0, values.Length);
        }

        // A byte is defined as an 8-bit unsigned integer.
        public static string Convert(this byte[] bytes)
        {
            return BitConverter.ToString(bytes);
        }

        public static string Convert(this BitArray bitArray)
        {
            return BitConverter.ToString(bitArray.ToBytes());
        }

        public static BitArray ToBitArray(this string text)
        {
            return new BitArray(text.ToBytes());
        }

        public static BitArray ToBitArray(this byte[] bytes)
        {
            return new BitArray(bytes);
        }

        public static byte[] ToBytes(this BitArray bArray)
        {
            byte[] b = new byte[(bArray.Length - 1) / 8 + 1];
            bArray.CopyTo(b, 0);
            return b;
        }

        public static string ToText(this BitArray bArray)
        {
            return bArray.ToBytes().ToString();
        }
    }
}
