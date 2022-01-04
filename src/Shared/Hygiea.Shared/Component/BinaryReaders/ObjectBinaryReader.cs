using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TheXDS.Hygiea.Component.BinaryReaders
{
    /// <summary>
    /// Implements a reader for objects that can be described by their
    /// constructors and properties.
    /// </summary>
    public class ObjectBinaryReader : IBinaryReader
    {
        private static readonly List<Type> _exclusions = new List<Type>()
        {
            typeof(object),
            typeof(string),
            typeof(decimal),
        };

        /// <inheritdoc/>
        public bool CanRead(Type type)
        {
            return !_exclusions.Contains(type) && !type.IsPrimitive && !type.IsAbstract;
        }

        /// <inheritdoc/>
        public object? Read(Type type, BinaryReader reader)
        {
            return (ObjectType)reader.ReadByte() switch
            {
                ObjectType.Null => null,
                ObjectType.Default => Activator.CreateInstance(type),
                ObjectType.Instance => CreateInstance(type, reader),
                _ => throw new NotImplementedException(),
            };
        }

        private object CreateInstance(Type type, BinaryReader reader)
        {
            var ctor = type.GetConstructors()[reader.ReadByte()].GetParameters().Select(p => p.ParameterType);
            var args = new List<object?>();
            foreach (var j in ctor)
            {
                args.Add(ObjectReader.Read(j, reader));
            }
            var o = Activator.CreateInstance(type, args.ToArray());
            foreach (var prop in type.GetProperties().Where(p => p.CanWrite))
            {
                prop.SetValue(o, ObjectReader.Read(prop.PropertyType, reader));
            }
            return o;
        }

        /// <summary>
        /// Adds a new exclusion to the types any object reader can parse.
        /// </summary>
        /// <param name="type">Type to be excluded.</param>
        public static void ExcludeType(Type type)
        {
            _exclusions.Add(type);
        }

        /// <summary>
        /// Adds a new exclusion to the types any object reader can parse.
        /// </summary>
        /// <typeparam name="T">Type to be excluded.</typeparam>
        public static void ExcludeType<T>() => ExcludeType(typeof(T));
    }
}
