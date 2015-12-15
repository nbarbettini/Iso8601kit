// <copyright file="SerializableTimeSpan.cs" company="Nate Barbettini">
// Copyright (c) 2015. Licensed under MIT.
// </copyright>

namespace SimpleDurations.Tests
{
    using System;
    using Xunit.Abstractions;

    [Serializable]
    public class SerializableTimeSpan : IXunitSerializable
    {
        private TimeSpan? timeSpan;

        public SerializableTimeSpan()
        {
        }

        public SerializableTimeSpan(TimeSpan timeSpan)
        {
            this.timeSpan = timeSpan;
        }

        public static implicit operator TimeSpan(SerializableTimeSpan obj)
            => obj.timeSpan.Value;

        public void Deserialize(IXunitSerializationInfo info)
        {
            this.timeSpan = TimeSpan.FromTicks(info.GetValue<long>("ticks"));
        }

        public void Serialize(IXunitSerializationInfo info)
        {
            info.AddValue("ticks", this.timeSpan.Value.Ticks);
        }

        public override string ToString()
        {
            return this.timeSpan == null
                ? "null"
                : this.timeSpan.Value.ToString();
        }
    }
}
