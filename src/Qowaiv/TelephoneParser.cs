using Qowaiv.Text;

namespace Qowaiv
{
    internal static class TelephoneParser
    {
        public static string Parse(string str)
            => new State(str)
            .International()
            .Digits()
            .Parsed();


        private static State International(this State state)
        {
            var matches = false;
            if(state.Slice.StartsWith("+"))
            {
                state.Result.Add('+');
                state.Slice = state.Slice.Next();
               matches = true;
            }
            else if(state.Slice.StartsWith("00"))
            {
                state.Result.Add('+');
                state.Slice = state.Slice.Next(2);
                matches = true;
            }
            
            if(matches)
            {
                while(char.IsDigit(state.Slice.Char))
                {
                    state.Result.Add(state.Slice.Char);
                    state.Slice = state.Slice.Next();
                }
            }
            return state;
        }

        private static State Digits(this State state)
        {
            var slice = state.Slice;

            while (!slice.IsLast())
            {
                if (slice.IsDigit())
                {
                    state.Add(slice);
                }
                else if(!slice.IsSpace())
                {
                    return state.Invalid();
                }

                slice = slice.Next();
            }
            return state;
        }

        private ref struct State
        {
            public Slice Slice;
            public readonly CharBuffer Result;

            public State(string str)
            {
                Slice = str.Slice();
                Result = new CharBuffer(str.Length);
            }

            public void Add(Slice slice)
            {
                Result.Add(slice.Char);
            }

            public State Invalid()
            {
                return this;
            }

            public string Parsed() => Result.Length == 0 ? null : Result.ToString();
        }

        private static bool IsDigit(this Slice slice)
            => slice.Char >= '0' && slice.Char <= '9';
        private static bool IsSpace(this Slice slice)
            => "  -".IndexOf(slice.Char) != -1;


    }
}
