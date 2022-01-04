using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace TheXDS.Hygiea.Component.BinaryReaders
{
    /// <summary>
    /// Implements a reader for primitive types.
    /// </summary>
    public class PrimitiveBinaryReader : IBinaryReader
    {
        /// <summary>
        /// Gets a method that can be used to read a primitive type from a
        /// <see cref="BinaryReader"/>.
        /// </summary>
        /// <param name="t">Type to read.</param>
        /// <returns>
        /// A method that can be used to read an object of type
        /// <paramref name="t"/> from a <see cref="BinaryReader"/>.
        /// </returns>
        protected static MethodInfo GetReadMethod(Type t)
        {
            return typeof(BinaryReader).GetMethods(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.Name.StartsWith("Read") && p.Name != "Read")
                .Where(p => p.ReturnType == t)
                .Where(p => !p.GetParameters().Any())
                .FirstOrDefault();
        }

        /// <inheritdoc/>
        public virtual bool CanRead(Type type)
        {
            return type != typeof(string) && GetReadMethod(type) is { };
        }

        /// <inheritdoc/>
        public virtual object? Read(Type type, BinaryReader reader)
        {
            return (GetReadMethod(type) ?? throw new InvalidOperationException()).Invoke(reader, Type.EmptyTypes);
        }
    }
}
