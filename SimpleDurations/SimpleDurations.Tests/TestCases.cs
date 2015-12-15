// <copyright file="TestCases.cs" company="Nate Barbettini">
// Copyright (c) 2015. Licensed under MIT.
// </copyright>

namespace SimpleDuration.Tests
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Contains shared test cases.
    /// </summary>
    public static class TestCases
    {
        /// <summary>
        /// Gets test cases for valid ISO 8601 strings.
        /// </summary>
        /// <returns>Enumerable test cases for an xUnit <see cref="Xunit.TheoryAttribute">Theory</see>.</returns>
        public static IEnumerable<object[]> ValidDurations()
        {
            yield return new object[] { string.Empty, new SerializableTimeSpan(TimeSpan.Zero) };
            yield return new object[] { "P4W", new SerializableTimeSpan(TimeSpan.FromDays(28)) };
            yield return new object[] { "P7D", new SerializableTimeSpan(TimeSpan.FromDays(7)) };
            yield return new object[] { "PT23H", new SerializableTimeSpan(TimeSpan.FromHours(23)) };
            yield return new object[] { "PT5M", new SerializableTimeSpan(TimeSpan.FromMinutes(5)) };
            yield return new object[] { "PT10S", new SerializableTimeSpan(TimeSpan.FromSeconds(10)) };
            yield return new object[] { "P4W1D", new SerializableTimeSpan(TimeSpan.FromDays(29)) };
            yield return new object[] { "PT1H", new SerializableTimeSpan(TimeSpan.FromHours(1)) };
            yield return new object[] { "P8W4D", new SerializableTimeSpan(TimeSpan.FromDays(60)) };
            yield return new object[] { "P1DT1H", new SerializableTimeSpan(TimeSpan.FromDays(1).Add(TimeSpan.FromHours(1))) };
            yield return new object[] { "P1DT1M", new SerializableTimeSpan(TimeSpan.FromDays(1).Add(TimeSpan.FromMinutes(1))) };
            yield return new object[] { "PT1H30M", new SerializableTimeSpan(TimeSpan.FromHours(1.5)) };
            yield return new object[] { "PT1.5S", new SerializableTimeSpan(TimeSpan.FromSeconds(1.5)) };
            yield return new object[] { "P25W5D", new SerializableTimeSpan(TimeSpan.FromDays(180)) };
            yield return new object[] { "P1W4DT12H30M5S", new SerializableTimeSpan(TimeSpan.FromDays(11).Add(TimeSpan.FromHours(12)).Add(TimeSpan.FromMinutes(30)).Add(TimeSpan.FromSeconds(5))) };
        }
    }
}
