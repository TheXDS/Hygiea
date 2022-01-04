using System;
using System.IO;

namespace TheXDS.Hygiea.Component.BinaryReaders
{
    /// <summary>
    /// Implements a reader for objects of type <see cref="Guid"/>.
    /// </summary>
    public class GuidBinaryReader : SpecificTypeReader<Guid>
    {
        /// <inheritdoc/>
        protected override Guid Read(BinaryReader reader)
        {
            return new Guid(reader.ReadBytes(16));
        }
    }
}
