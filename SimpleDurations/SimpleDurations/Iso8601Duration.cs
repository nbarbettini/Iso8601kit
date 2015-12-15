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
            if (result.Valid)
            {
                timeSpan = ConvertResult(result);
            }

            return result.Valid;
        }

        private static TimeSpan ConvertResult(DurationVisitor visitor)
        {
            return TimeSpan.Zero
                .Add(TimeSpan.FromDays(visitor.Weeks * 7))
                .Add(TimeSpan.FromDays(visitor.Days))
                .Add(TimeSpan.FromHours(visitor.Hours))
                .Add(TimeSpan.FromMinutes(visitor.Minutes))
                .Add(TimeSpan.FromSeconds(visitor.Seconds));
        }
    }
}
