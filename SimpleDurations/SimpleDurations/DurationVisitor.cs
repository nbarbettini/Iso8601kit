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

        List<char> digits = new List<char>();
        bool inTimeSegment = false;

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

        public double Weeks { get; private set; } = 0;

        public double Days { get; private set; } = 0;

        public double Hours { get; private set; } = 0;

        public double Minutes { get; private set; } = 0;

        public double Seconds { get; private set; } = 0;

        private void Visit()
        {
            if (this.tokens.Length < 2
                || this.tokens[0] != 'P')
            {
                return;
            }

            foreach (char token in this.tokens.Skip(1))
            {
                if (token == 'Y')
                {
                    return;
                }

                if (char.IsDigit(token) || char.IsPunctuation(token))
                {
                    this.digits.Add(token);
                    continue;
                }

                if (token == 'T')
                {
                    this.inTimeSegment = true;
                    continue;
                }

                if (token == 'W')
                {
                    if (this.inTimeSegment || !this.digits.Any())
                    {
                        return; // invalid
                    }

                    this.Weeks = double.Parse(CharListToString(this.digits));
                    this.digits.Clear();
                }

                if (token == 'D')
                {
                    if (this.inTimeSegment || !this.digits.Any())
                    {
                        return; // invalid
                    }

                    this.Days = double.Parse(CharListToString(this.digits));
                    this.digits.Clear();
                    continue;
                }

                if (token == 'H')
                {
                    if (!this.inTimeSegment || !this.digits.Any())
                    {
                        return; // invalid
                    }

                    this.Hours = double.Parse(CharListToString(this.digits));
                    this.digits.Clear();
                    continue;
                }

                if (token == 'M')
                {
                    if (!this.inTimeSegment || !this.digits.Any())
                    {
                        return; // invalid
                    }

                    this.Minutes = double.Parse(CharListToString(this.digits));
                    this.digits.Clear();
                    continue;
                }

                if (token == 'S')
                {
                    if (!this.inTimeSegment || !this.digits.Any())
                    {
                        return; // invalid
                    }

                    this.Seconds = double.Parse(CharListToString(this.digits));
                    this.digits.Clear();
                    continue;
                }
            }

            this.Valid = !this.digits.Any();
        }

        //private void HandleToken(char expected, char token, ref double target)
        //{
        //    if (token == expected)
        //    {
        //        if (this.inTimeSegment || !this.digits.Any())
        //        {
        //            return; // invalid
        //        }

        //        this.Weeks = double.Parse(CharListToString(this.digits));
        //        this.digits.Clear();
        //    }
        //}

        private static string CharListToString(IList<char> chars)
            => string.Join(string.Empty, chars);
    }
}
