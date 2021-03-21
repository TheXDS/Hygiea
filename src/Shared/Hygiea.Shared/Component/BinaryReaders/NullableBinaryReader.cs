using System;
using System.IO;

namespace TheXDS.Hygiea.Component.BinaryReaders
{
    public class NullableBinaryReader : PrimitiveBinaryReader
    {
        public override bool CanRead(Type type)
        {
            return Nullable.GetUnderlyingType(type) is { };
        }

        public override object? Read(Type type, BinaryReader reader)
        {
            return (ObjectType)reader.ReadByte() switch
            {
                ObjectType.Null => null,
                ObjectType.Default => Activator.CreateInstance(type, Activator.CreateInstance(Nullable.GetUnderlyingType(type))),
                ObjectType.Instance => Activator.CreateInstance(type, ObjectReader.Read(Nullable.GetUnderlyingType(type), reader)),
                _ => throw new NotImplementedException()
            };
        }
    }
}
