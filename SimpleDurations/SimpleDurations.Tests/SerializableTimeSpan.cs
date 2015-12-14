// <copyright file="SerializableTimeSpan.cs" company="Nate Barbettini">
// Copyright (c) 2015. Licensed under MIT.
// </copyright>

namespace SimpleDurations.Tests
{
    using System;
    using Xunit.Abstractions;

    //public class SerializableTimeSpan : IXunitSerializable
    //{
    //    private TimeSpan? timeSpan;

    //    public SerializableTimeSpan()
    //    {
    //    }

    //    public SerializableTimeSpan(TimeSpan timeSpan)
    //    {
    //        this.timeSpan = timeSpan;
    //    }

    //    public static implicit operator TimeSpan(SerializableTimeSpan obj)
    //        => obj.timeSpan.Value;

    //    public void Deserialize(IXunitSerializationInfo info)
    //    {
    //        this.timeSpan = info.GetValue<TimeSpan>("ts");
    //    }

    //    public void Serialize(IXunitSerializationInfo info)
    //    {
    //        info.AddValue("ts", this.timeSpan.Value, typeof(TimeSpan));
    //    }

    //    public override string ToString()
    //    {
    //        return this.timeSpan == null
    //            ? "null"
    //            : this.timeSpan.Value.ToString();
    //    }
    //}
}
