﻿using System;
using System.IO;

namespace TheXDS.Hygiea.Component.BinaryReaders
{
    /// <summary>
    /// Implements a reader for objects of type <see cref="string"/>.
    /// </summary>
    public class StringBinaryReader : SpecificTypeReader<string?>
    {
        /// <inheritdoc/>
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
