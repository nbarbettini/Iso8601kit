// <copyright file="Iso8601Duration.cs" company="Nate Barbettini">
// Copyright (c) 2015. Licensed under MIT.
// </copyright>

namespace SimpleDurations
{
    using System;

    /// <summary>
    /// Contains methods useful for interacting with ISO 8601 durations.
    /// </summary>
    public static class Iso8601Duration
    {
        /// <summary>
        /// Converts the ISO 8601 string representation of a duration to its equivalent
        /// .NET <see cref="TimeSpan"/> representation.
        /// A return value indicates whether the conversion succeeded or failed.
        /// </summary>
        /// <param name="duration">The ISO 8601 duration, excluding year (Y) and month (M) designators.</param>
        /// <param name="timeSpan">
        /// When the method returns, this parameter is set to the resulting <see cref="TimeSpan"/>
        /// if the conversion was successful, or <c>default(TimeSpan)</c> if the conversion was unsuccessful.</param>
        /// <returns><see langword="true"/> if the conversion succeeded; <see langword="false"/> otherwise.</returns>
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
