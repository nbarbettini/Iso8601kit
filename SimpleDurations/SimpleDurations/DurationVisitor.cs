// <copyright file="DurationVisitor.cs" company="Nate Barbettini">
// Copyright (c) 2015. Licensed under MIT.
// </copyright>

namespace SimpleDurations
{
    using System.Collections.Generic;
    using System.Linq;

    internal sealed partial class DurationVisitor
    {
        private readonly char[] tokens;

        private List<char> segmentDigits = new List<char>();
        private bool inTimeSection = false;
        private bool isValid = true;
        private double weeks = 0;
        private double days = 0;
        private double hours = 0;
        private double minutes = 0;
        private double seconds = 0;

        private DurationVisitor(string duration)
        {
            this.tokens = duration.ToArray();
        }

        private void Visit()
        {
            if (this.tokens.Length < 2 || this.tokens[0] != 'P')
            {
                this.isValid = false;
                return;
            }

            foreach (char token in this.tokens.Skip(1))
            {
                if (!this.isValid)
                {
                    return;
                }

                if (token == 'Y')
                {
                    this.isValid = false;
                    continue;
                }

                if (token == 'T')
                {
                    this.inTimeSection = true;
                    continue;
                }

                if (token == 'W')
                {
                    this.isValid = this.HandleDateToken(ref this.weeks);
                    continue;
                }

                if (token == 'D')
                {
                    this.isValid = this.HandleDateToken(ref this.days);
                    continue;
                }

                if (token == 'H')
                {
                    this.isValid = this.HandleTimeToken(ref this.hours);
                    continue;
                }

                if (token == 'M')
                {
                    this.isValid = this.HandleTimeToken(ref this.minutes);
                    continue;
                }

                if (token == 'S')
                {
                    this.isValid = this.HandleTimeToken(ref this.seconds);
                    continue;
                }

                this.segmentDigits.Add(token);
            }

            this.isValid &= !this.segmentDigits.Any();
        }

        private bool HandleDateToken(ref double target)
            => this.HandleToken(false, ref target);

        private bool HandleTimeToken(ref double target)
            => this.HandleToken(true, ref target);

        private bool HandleToken(bool timeToken, ref double target)
        {
            if (this.inTimeSection != timeToken || !this.segmentDigits.Any())
            {
                return false;
            }

            double result;
            if (!double.TryParse(CharListToString(this.segmentDigits), out result))
            {
                return false;
            }

            target = result;
            this.segmentDigits.Clear();

            return true;
        }

        private static string CharListToString(IList<char> chars)
            => string.Join(string.Empty, chars);
    }
}
