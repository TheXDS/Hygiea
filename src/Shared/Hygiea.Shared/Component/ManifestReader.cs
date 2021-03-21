using TheXDS.Hygiea.Component.BinaryReaders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TheXDS.Hygiea.Component
{
    /// <summary>
    /// Contiene métodos para leer objetos binarios desde un
    /// <see cref="Stream"/> de manifiesto.
    /// </summary>
    public static class ManifestReader
    {
        private static readonly List<IBinaryReader> _readers = new List<IBinaryReader>();

        /// <summary>
        /// Inicializa la clase <see cref="ManifestReader"/>
        /// </summary>
        static ManifestReader()
        {
            _readers.AddRange(AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(p => p.GetTypes())
                .Where(p => typeof(IBinaryReader).IsAssignableFrom(p))
                .Where(p => p.GetConstructor(Type.EmptyTypes) is { })
                .Select(Activator.CreateInstance).Cast<IBinaryReader>());
        }

        /// <summary>
        /// Lee un objeto desde un <see cref="Stream"/> de forma binaria.
        /// </summary>
        /// <typeparam name="T">Tipo de objeto a obtener.</typeparam>
        /// <param name="source">
        /// <see cref="Stream"/> desde el cual leer el objeto.
        /// </param>
        /// <returns>Una nueva instancia del objeto leído.</returns>
        public static T ReadBinaryObject<T>(Stream source) where T : notnull, new()
        {
            using var br = new BinaryReader(source);
            return (T)GetReader(typeof(T)).Read(typeof(T), br);            
        }

        /// <summary>
        /// Obtiene una referencia al <see cref="IBinaryReader"/> que puede
        /// utilizarse para leer un objeto del tipo especificado.
        /// </summary>
        /// <param name="type">Tipo de objeto a leer.</param>
        /// <returns>
        /// El <see cref="IBinaryReader"/> que puede utilizarse para leer un
        /// objeto del tipo especificado.
        /// </returns>
        public static IBinaryReader GetReader(Type type)
        {
            return _readers.First(p => p.CanRead(type));
        }
    }
}
