using System;
using System.IO;

namespace TheXDS.Hygiea.Component.BinaryReaders
{
    /// <summary>
    /// Defines a set of members to be implemented by a type that allows to
    /// read objects from a <see cref="BinaryReader"/>.
    /// </summary>
    public interface IBinaryReader
    {
        /// <summary>
        /// Checks if this <see cref="IBinaryReader"/> can read objects of the
        /// specified type.
        /// </summary>
        /// <param name="type">Type to check.</param>
        /// <returns>
        /// <see langword="true"/> if this <see cref="IBinaryReader"/> can read
        /// objects of the specified type, <see langword="false"/> otherwise.
        /// </returns>
        bool CanRead(Type type);

        /// <summary>
        /// Reads an object from the specified <see cref="BinaryReader"/>.
        /// </summary>
        /// <param name="type">Type of object to read.</param>
        /// <param name="reader">
        /// <see cref="BinaryReader"/> from which to read the object.
        /// </param>
        /// <returns>
        /// The object read from the specified <see cref="BinaryReader"/>.
        /// </returns>
        object? Read(Type type, BinaryReader reader);
    }
}
