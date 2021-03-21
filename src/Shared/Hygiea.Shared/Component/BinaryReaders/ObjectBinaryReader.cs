using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TheXDS.Hygiea.Component.BinaryReaders
{
    /// <summary>
    /// Implementa un lector para clases simples que pueden ser descritas e
    /// instanciadas a partir de sus propiedades o por medio de un constructor.
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
                var t = prop.PropertyType;
                prop.SetValue(o, ObjectReader.Read(t, reader));
            }
            return o;
        }

        public ObjectBinaryReader ExcludeType(Type type)
        {
            _exclusions.Add(type);
            return this;
        }

        public ObjectBinaryReader ExcludeType<T>() => ExcludeType(typeof(T));
    }
}
