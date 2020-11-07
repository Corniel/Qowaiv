using System.Linq;

namespace Qowaiv.Text
{
    internal static class TinyEncoding
    {
        public static ulong Encode(this string str, string encoding)
        {
            ulong encoded = 0;
            var size = (ulong)encoding.Length;
            foreach (var ch in str.Reverse())
            {
                encoded *= size;
                encoded += (ulong)encoding.IndexOf(ch);
            }
            return encoded;
        }

        public static string Decode(this ulong encoded, string encoding)
        {
            if (encoded == ulong.MaxValue) { return "?"; }

            var size = (ulong)encoding.Length;
            var buffer = encoded;
            var length = 0;
            var chars = new char[32];
            while(buffer > 0)
            {
                chars[length++] = encoding[(int)(buffer % size)];
                buffer /= size;
            }
            return new string(chars, 0, length);
        }
    }
}
