// <copyright file="DurationVisitor.cs" company="Nate Barbettini">
// Copyright (c) 2015. Licensed under MIT.
// </copyright>

namespace SimpleDurations
{
    using System.Collections.Generic;
    using System.Linq;

    internal sealed class DurationVisitor
    {
        private readonly char[] tokens;

        private DurationVisitor(string duration)
        {
            this.tokens = duration.ToArray();
        }

        public static DurationVisitor Parse(string duration)
        {
            var visitor = new DurationVisitor(duration);
            visitor.Visit();

            return visitor;
        }

        public bool Valid { get; private set; } = false;

        private void Visit()
        {
            if (this.tokens.Length < 2)
                //|| this.tokens[0] != 'P')
            {
                return;
            }

            Stack<char> digits = null;

            bool inTimeSegment = false;

            foreach (char token in this.tokens)
            {
                if (!char.IsDigit(token))
                {
                    digits = new Stack<char>();
                }

                if (token == 'T')
                {
                    inTimeSegment = true;
                    continue;
                }
            }

            this.Valid = true;
        }
    }
}
