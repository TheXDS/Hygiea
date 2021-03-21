using System;
using System.IO;

namespace TheXDS.Hygiea.Component.BinaryReaders
{
    /// <summary>
    /// Define una serie de miembros a implementar por un tipo que permita
    /// obtener objetos desde un <see cref="BinaryReader"/>.
    /// </summary>
    public interface IBinaryReader
    {
        /// <summary>
        /// Comprueba que este <see cref="IBinaryReader"/> pueda leer objetos
        /// del tipo especificado.
        /// </summary>
        /// <param name="type">Tipo a comprobar.</param>
        /// <returns>
        /// <see langword="true"/> si este <see cref="IBinaryReader"/> puede
        /// leer objetos del tipo especificado, <see langword="false"/> en caso
        /// contrario.
        /// </returns>
        bool CanRead(Type type);

        /// <summary>
        /// Lee un objeto desde el <see cref="BinaryReader"/> especificado.
        /// </summary>
        /// <param name="type">Tipo de objeto a leer.</param>
        /// <param name="reader">
        /// <see cref="BinaryReader"/> desde el cual leer la información para
        /// construir el objeto.
        /// </param>
        /// <returns>
        /// El objeto que se ha leído desde el <see cref="BinaryReader"/>
        /// especificado.
        /// </returns>
        object? Read(Type type, BinaryReader reader);
    }
}
