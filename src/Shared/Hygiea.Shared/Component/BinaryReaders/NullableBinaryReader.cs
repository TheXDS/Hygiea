using System;
using System.IO;

namespace TheXDS.Hygiea.Component.BinaryReaders
{
    /// <summary>
    /// Implements a reader for nullable structs.
    /// </summary>
    public class NullableBinaryReader : PrimitiveBinaryReader
    {
        /// <inheritdoc/>
        public override bool CanRead(Type type)
        {
            return Nullable.GetUnderlyingType(type) is { };
        }

        /// <inheritdoc/>
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
