// <copyright file="Iso8601Duration.cs" company="Nate Barbettini">
// Copyright (c) 2015. Licensed under MIT.
// </copyright>

namespace SimpleDurations
{
    using System;

    public static class Iso8601Duration
    {
        public static bool TryParse(string duration, out TimeSpan timeSpan)
        {
            timeSpan = default(TimeSpan);

            var result = DurationVisitor.Parse(duration);

            return result.Valid;
        }
    }
}
