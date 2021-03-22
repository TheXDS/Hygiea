using System;
using System.IO;

namespace TheXDS.Hygiea.Component.BinaryReaders
{
    public class StringBinaryReader : SpecificTypeReader<string?>
    {
        protected override string? Read(BinaryReader reader)
        {
            return (ObjectType)reader.ReadByte() switch
            {
                ObjectType.Null => null,
                ObjectType.Default => string.Empty,
                ObjectType.Instance => reader.ReadString(),
                _ => throw new NotImplementedException(),
            };
        }
    }
}
