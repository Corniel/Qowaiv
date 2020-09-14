using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Qowaiv.Text
{
    [DebuggerDisplay("{DebuggerDisplay}")]
    internal readonly struct Slice 
    {
        private readonly string m_Value;
        private readonly int m_Position;

        public Slice(string str, int pos)
        {
            m_Value = str;
            m_Position = pos;
        }

        public int Length => m_Value.Length - m_Position;

        public char Char => m_Value[m_Position];

        public bool IsLast() => m_Position == m_Value.Length - 1;

        public Slice Next(int skip = 1) => new Slice(m_Value, m_Position + skip);

        public bool StartsWith(string str)
        {
            if (str.Length > Length)
            {
                return false;
            }
            for (var i = m_Position; i < str.Length; i++)
            {
                if (m_Value[i] != str[i])
                {
                    return false;
                }
            }
            return true;
        }

        public override string ToString() => m_Value.Substring(m_Position);

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string DebuggerDisplay
            => m_Position == 0
            ? m_Value
            : $"[{m_Value.Substring(0, m_Position)}] {ToString()}";

        public IEnumerable<Slice> All()
        {
            for (var i = m_Position + 1; i < m_Value.Length; i++)
            {
                yield return new Slice(m_Value, i);
            }
        }
    }

    internal static class SliceExtensions
    {
        public static Slice Slice(this string str) => new Slice(str, 0);
        public static IEnumerable<Slice> Slices(this string str)
            => str is null
            ? Enumerable.Empty<Slice>()
            : new Slice(str, 0).All();
    }
}
