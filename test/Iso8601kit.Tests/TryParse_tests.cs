// <copyright file="TryParse_tests.cs" company="Nate Barbettini">
// Copyright (c) 2015. Licensed under MIT.
// </copyright>

using System;
using System.Collections.Generic;
using Shouldly;
using Xunit;

namespace Iso8601kit.Tests
{
    /// <summary>
    /// Unit tests for the <see cref="Iso8601Duration.TryParse(string, out TimeSpan)"/> method.
    /// </summary>
    public class TryParse_tests
    {
        /// <summary>
        /// Additional valid test cases not included in <see cref="TestCases.ValidDurations"/>.
        /// </summary>
        /// <returns>Enumerable test cases for an xUnit <see cref="Xunit.TheoryAttribute">Theory</see>.</returns>
        public static IEnumerable<object[]> AdditionalValidDurations()
        {
            yield return new object[] { "PT300S", new SerializableTimeSpan(TimeSpan.FromSeconds(300)) };
            yield return new object[] { "PT60M", new SerializableTimeSpan(TimeSpan.FromMinutes(60)) };
            yield return new object[] { "P60D", new SerializableTimeSpan(TimeSpan.FromDays(60)) };
            yield return new object[] { "P61D", new SerializableTimeSpan(TimeSpan.FromDays(61)) };
            yield return new object[] { "P4WT", new SerializableTimeSpan(TimeSpan.FromDays(28)) };
            yield return new object[] { "PT1.5H", new SerializableTimeSpan(TimeSpan.FromHours(1.5)) };
            yield return new object[] { "P180D", new SerializableTimeSpan(TimeSpan.FromDays(180)) };
        }

        /// <summary>
        /// Tests for valid ISO 8601 duration strings.
        /// </summary>
        /// <param name="iso8601">The ISO 8601 duration string.</param>
        /// <param name="expected">The expected <see cref="TimeSpan"/>.</param>
        [Theory]
        [MemberData(nameof(TestCases.ValidDurations), MemberType = typeof(TestCases))]
        [MemberData(nameof(AdditionalValidDurations))]
        public void Valid_duration(string iso8601, SerializableTimeSpan expected)
        {
            TimeSpan result;

            Iso8601Duration.TryParse(iso8601, out result).ShouldBe(true);

            result.ShouldBe(expected);
        }

        /// <summary>
        /// Regression tests for unsupported ISO 8601 designators.
        /// </summary>
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
