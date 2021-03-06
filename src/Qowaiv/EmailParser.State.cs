﻿using Qowaiv.Text;

namespace Qowaiv
{
    internal static partial class EmailParser
    {
        /// <summary>Internal state.</summary>
        private ref struct State
        {
            public State(string str)
            {
                Input = str.Buffer().Trim();
                Buffer = CharBuffer.Empty(EmailAddress.MaxLength);
                Result = CharBuffer.Empty(EmailAddress.MaxLength);

                DisplayNameRemoved = false;
            }

            public readonly CharBuffer Input;
            public readonly CharBuffer Buffer;
            public readonly CharBuffer Result;

            public bool DisplayNameRemoved;

            public bool Done => Input.IsEmpty() || TooLong();

            public bool IsLocal => Result.IsEmpty();

            private bool TooLong()
            {
                // if the local part is more then 64 characters.
                if (IsLocal && Buffer.Length > LocalMaxLength)
                {
                    return true;
                }
                // The result will be too long. 
                if (Result.Length + Buffer.Length > EmailAddress.MaxLength)
                {
                    return true;
                }

                return !IsLocal 
                    && Buffer.Length > DomainPartMaxLength
                    && Buffer.Length - (Buffer.LastIndexOf(Dot) + 1) > DomainPartMaxLength;
            }

            public override string ToString() => $"Buffer: {Input}, Result:{Result}";

            public State Invalid()
            {
                Input.Clear();
                return this;
            }

            public string Parsed() => Done ? null : Result.ToString();
        }
    }
}
