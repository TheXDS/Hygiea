using System;
using System.IO;

namespace TheXDS.Hygiea.Component.BinaryReaders
{
    public class GuidBinaryReader : SpecificTypeReader<Guid>
    {
        protected override Guid Read(BinaryReader reader)
        {
            return new Guid(reader.ReadBytes(16));
        }
    }
}
