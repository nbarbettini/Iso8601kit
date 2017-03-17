// <copyright file="SerializableTimeSpan.cs" company="Nate Barbettini">
// Copyright (c) 2015. Licensed under MIT.
// </copyright>

namespace Iso8601kit.Tests
{
    using System;
    using Xunit.Abstractions;

    /// <summary>
    /// Represents a <see cref="TimeSpan"/> that xUnit can serialize.
    /// </summary>
    public class SerializableTimeSpan : IXunitSerializable
    {
        private TimeSpan? timeSpan;

        /// <summary>
        /// Initializes a new instance of the <see cref="SerializableTimeSpan"/> class.
        /// </summary>
        public SerializableTimeSpan()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SerializableTimeSpan"/> class with
        /// the specified <see cref="TimeSpan"/> value.
        /// </summary>
        /// <param name="timeSpan">The time span.</param>
        public SerializableTimeSpan(TimeSpan timeSpan)
        {
            this.timeSpan = timeSpan;
        }

        /// <summary>
        /// Implicit cast to <see cref="TimeSpan"/>.
        /// </summary>
        /// <param name="instance">The <see cref="SerializableTimeSpan"/> to cast.</param>
        public static implicit operator TimeSpan(SerializableTimeSpan instance)
            => instance.timeSpan.Value;

        /// <inheritdoc/>
        public void Deserialize(IXunitSerializationInfo info)
        {
            this.timeSpan = TimeSpan.FromTicks(info.GetValue<long>("ticks"));
        }

        /// <inheritdoc/>
        public void Serialize(IXunitSerializationInfo info)
        {
            info.AddValue("ticks", this.timeSpan.Value.Ticks);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return this.timeSpan == null
                ? "null"
                : this.timeSpan.Value.ToString();
        }
    }
}
