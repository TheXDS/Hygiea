using System;
using System.IO;

namespace TheXDS.Hygiea.Component.BinaryReaders
{
    /// <summary>
    /// Base class that allows to implement specific type readers.
    /// </summary>
    /// <typeparam name="T">Type to implement a reader for.</typeparam>
    public abstract class SpecificTypeReader<T> : IBinaryReader
    {
        /// <inheritdoc/>
        public bool CanRead(Type type)
        {
            return type == typeof(T);
        }

        /// <inheritdoc/>
        public object? Read(Type type, BinaryReader reader)
        {
            return Read(reader);
        }

        /// <summary>
        /// Reads an object of type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="reader">
        /// <see cref="BinaryReader"/> to read the object from.
        /// </param>
        /// <returns>
        /// An object of tye <typeparamref name="T"/> read from the specified
        /// <see cref="BinaryReader"/>.
        /// </returns>
        protected abstract T Read(BinaryReader reader);
    }
}
