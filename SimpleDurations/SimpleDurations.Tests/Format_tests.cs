// <copyright file="Format_tests.cs" company="Nate Barbettini">
// Copyright (c) 2015. Licensed under MIT.
// </copyright>

namespace SimpleDurations.Tests
{
    using Shouldly;
    using Xunit;

    /// <summary>
    /// Unit tests for the <see cref="Iso8601Duration.Format(System.TimeSpan)"/> method.
    /// </summary>
    public class Format_tests
    {
        /// <summary>
        /// Asserts that the ISO 8601-formatted output is as expected
        /// for a given input <see cref="System.TimeSpan"/>.
        /// </summary>
        /// <param name="expected">The expected output string.</param>
        /// <param name="timeSpan">The time span.</param>
        [Theory]
        [MemberData(nameof(TestCases.ValidDurations), MemberType = typeof(TestCases))]
        public void Formatting(string expected, SerializableTimeSpan timeSpan)
        {
            Iso8601Duration.Format(timeSpan).ShouldBe(expected);
        }
    }
}
