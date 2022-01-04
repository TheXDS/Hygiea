using System;
using System.IO;

namespace TheXDS.Hygiea.Component.BinaryReaders
{
    /// <summary>
    /// Implements a reader for enumeration values.
    /// </summary>
    public class EnumBinaryReader : PrimitiveBinaryReader
    {
        /// <inheritdoc/>
        public override bool CanRead(Type type)
        {
            return type.IsEnum;
        }

        /// <inheritdoc/>
        public override object Read(Type type, BinaryReader reader)
        {
            return Enum.ToObject(type, base.Read(type.GetEnumUnderlyingType(), reader));
        }
    }
}
