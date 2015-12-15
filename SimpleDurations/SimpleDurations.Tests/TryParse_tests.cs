// <copyright file="TryParse_tests.cs" company="Nate Barbettini">
// Copyright (c) 2015. Licensed under MIT.
// </copyright>

namespace SimpleDurations.Tests
{
    using System;
    using System.Collections.Generic;
    using Shouldly;
    using Xunit;

    /// <summary>
    /// Unit tests for the <see cref="Iso8601Duration.TryParse(string, out TimeSpan)"/> method.
    /// </summary>
    public class TryParse_tests
    {
        /// <summary>
        /// Gets test cases for valid ISO 8601 strings.
        /// </summary>
        /// <returns>Enumerable test cases for an xUnit <see cref="TheoryAttribute">Theory</see>.</returns>
        public static IEnumerable<object[]> GetValidTestCases()
        {
            yield return new object[] { string.Empty, new SerializableTimeSpan(TimeSpan.Zero) };
            yield return new object[] { "PT300S", new SerializableTimeSpan(TimeSpan.FromSeconds(300)) };
            yield return new object[] { "PT60M", new SerializableTimeSpan(TimeSpan.FromMinutes(60)) };
            yield return new object[] { "PT24H", new SerializableTimeSpan(TimeSpan.FromHours(24)) };
            yield return new object[] { "P7D", new SerializableTimeSpan(TimeSpan.FromDays(7)) };
            yield return new object[] { "P4W", new SerializableTimeSpan(TimeSpan.FromDays(28)) };
            yield return new object[] { "P4WT", new SerializableTimeSpan(TimeSpan.FromDays(28)) };
            yield return new object[] { "PT1H", new SerializableTimeSpan(TimeSpan.FromHours(1)) };
            yield return new object[] { "P60D", new SerializableTimeSpan(TimeSpan.FromDays(60)) };
            yield return new object[] { "P1DT1H", new SerializableTimeSpan(TimeSpan.FromDays(1).Add(TimeSpan.FromHours(1))) };
            yield return new object[] { "P1DT1M", new SerializableTimeSpan(TimeSpan.FromDays(1).Add(TimeSpan.FromMinutes(1))) };
            yield return new object[] { "PT1.5H", new SerializableTimeSpan(TimeSpan.FromHours(1.5)) };
        }

        /// <summary>
        /// Tests for valid ISO 8601 duration strings.
        /// </summary>
        /// <param name="iso8601">The ISO 8601 duration string.</param>
        /// <param name="expected">The expected <see cref="TimeSpan"/>.</param>
        [Theory]
        [MemberData(nameof(GetValidTestCases))]
        public void Valid_duration(string iso8601, SerializableTimeSpan expected)
        {
            TimeSpan result;

            Iso8601Duration.TryParse(iso8601, out result);

            result.ShouldBe(expected);
        }

        /// <summary>
        /// Regression tests for unsupported ISO 8601 designators.
        /// </summary>
        /// <remarks>
        /// The year (Y) and month (M) designators are currently unsupported.
        /// These are problematic because of things like leap years, DST, etc.
        /// More information is needed in order to convert to a <see cref="TimeSpan"/>;
        /// for that, a more powerful library such as NodaTime would be appropriate.
        /// </remarks>
        /// <param name="unsupported">An ISO 8601 duration string containing unsupported designators.</param>
        [Theory]
        [InlineData("P1Y")]
        [InlineData("P1M")]
        [InlineData("P1MT1M")]
        public void Unsupported_duration(string unsupported)
        {
            TimeSpan dummy;
            Iso8601Duration.TryParse(unsupported, out dummy).ShouldBe(false);
        }

        /// <summary>
        /// Tests for invalid ISO 8601 duration strings.
        /// </summary>
        /// <param name="invalid">An ISO 8601 duration containing invalid syntax.</param>
        [Theory]
        [InlineData("foobar")]
        [InlineData("PfoobarT")]
        [InlineData("3W")]
        [InlineData("P3")]
        [InlineData("P3W2")]
        [InlineData("PW")]
        [InlineData("P3WTM")]
        [InlineData("P3fooD")]
        [InlineData("PT1xM")]
        public void Invalid_duration(string invalid)
        {
            TimeSpan dummy;
            Iso8601Duration.TryParse(invalid, out dummy).ShouldBe(false);
        }
    }
}
