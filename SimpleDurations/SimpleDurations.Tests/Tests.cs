// <copyright file="Tests.cs" company="Nate Barbettini">
// Copyright (c) 2015. Licensed under MIT.
// </copyright>

namespace SimpleDurations.Tests
{
    using System;
    using System.Collections.Generic;
    using Shouldly;
    using Xunit;

    public class Tests
    {
        //public static IEnumerable<object[]> GetValidTestCases()
        //{
        //    //yield return new object[] { "PT300S", new SerializableTimeSpan(TimeSpan.FromSeconds(300)) };
        //    //yield return new object[] { "PT60M", new SerializableTimeSpan(TimeSpan.FromMinutes(60)) };
        //    //yield return new object[] { "PT24H", new SerializableTimeSpan(TimeSpan.FromHours(24)) };
        //    //yield return new object[] { "P7D", new SerializableTimeSpan(TimeSpan.FromDays(7)) };
        //    //yield return new object[] { "P4W", new SerializableTimeSpan(TimeSpan.FromDays(21)) };
        //    //yield return new object[] { "PT1H", new SerializableTimeSpan(TimeSpan.FromHours(1)) };
        //    //yield return new object[] { "P60D", new SerializableTimeSpan(TimeSpan.FromDays(60)) };
        //    //yield return new object[] { "P1DT1H", new SerializableTimeSpan(TimeSpan.FromDays(1).Add(TimeSpan.FromMinutes(1))) };
        //}

        //[Theory]
        //[MemberData(nameof(GetValidTestCases))]
        //public void TryParse_valid_duration(string duration, SerializableTimeSpan expected)
        //{
        //    TimeSpan result;

        //    Iso8601Duration.TryParse(duration, out result);

        //    result.ShouldBe(expected);
        //}

        [Theory]
        [InlineData("")]
        [InlineData("3W")]
        [InlineData("P3")]
        public void TryParse_invalid_duration(string invalid)
        {
            TimeSpan dummy;
            Iso8601Duration.TryParse(invalid, out dummy).ShouldBe(false);
        }

        [Theory]
        [InlineData("P1Y")]
        [InlineData("P1M")]
        public void TryParse_unsupported_duration(string unsupported)
        {
            TimeSpan dummy;
            Iso8601Duration.TryParse(unsupported, out dummy).ShouldBe(false);
        }
    }
}
