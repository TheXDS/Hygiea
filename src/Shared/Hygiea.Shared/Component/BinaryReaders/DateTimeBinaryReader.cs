using System;
using System.IO;

namespace TheXDS.Hygiea.Component.BinaryReaders
{
    public class DateTimeBinaryReader : SpecificTypeReader<DateTime>
    {
        protected override DateTime Read(BinaryReader reader)
        {
            return DateTime.FromBinary(reader.ReadInt64());
        }
    }
}
