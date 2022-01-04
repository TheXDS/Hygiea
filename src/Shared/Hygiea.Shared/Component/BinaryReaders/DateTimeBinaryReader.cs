using System;
using System.IO;

namespace TheXDS.Hygiea.Component.BinaryReaders
{
    /// <summary>
    /// Implements a reader for objects of type <see cref="DateTime"/>.
    /// </summary>
    public class DateTimeBinaryReader : SpecificTypeReader<DateTime>
    {
        /// <inheritdoc/>
        protected override DateTime Read(BinaryReader reader)
        {
            return DateTime.FromBinary(reader.ReadInt64());
        }
    }
}
