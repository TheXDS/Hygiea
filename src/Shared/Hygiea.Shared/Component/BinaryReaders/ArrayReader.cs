using System;
using System.IO;

namespace TheXDS.Hygiea.Component.BinaryReaders
{
    /// <summary>
    /// Implements an array reader.
    /// </summary>
    public class ArrayReader : IBinaryReader
    {
        /// <inheritdoc/>
        public bool CanRead(Type type)
        {
            return type.IsArray;
        }

        /// <inheritdoc/>
        public object? Read(Type type, BinaryReader reader)
        {
            var length = reader.ReadInt32();
            if (length == -1) return null!;
            var et = type.GetElementType();
            var r = ObjectReader.GetReader(et);
            var array = Array.CreateInstance(et, length);
            for (var j = 0; j < length; j++)
            {
                var o = r.Read(et, reader);
                array.SetValue(o, j);
            }
            return array;
        }
    }
}
