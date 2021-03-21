using System;
using System.IO;

namespace TheXDS.Hygiea.Component.BinaryReaders
{
    public class EnumBinaryReader : PrimitiveBinaryReader
    {
        public override bool CanRead(Type type)
        {
            return type.IsEnum;
        }

        public override object Read(Type type, BinaryReader reader)
        {
            return Enum.ToObject(type, base.Read(type.GetEnumUnderlyingType(), reader));
        }
    }
}
