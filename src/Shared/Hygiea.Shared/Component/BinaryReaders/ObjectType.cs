using System.IO;

namespace TheXDS.Hygiea.Component.BinaryReaders
{
    /// <summary>
    /// Indica el tipo de objeto que se describe a continuación en el 
    /// <see cref="BinaryReader"/> de origen.
    /// </summary>
    public enum ObjectType : byte
    {
        /// <summary>
        /// Indica que la entrada no hace referencia ningún objeto, o sea, 
        /// <see langword="null"/>.
        /// </summary>
        Null,
        /// <summary>
        /// Indica que la entrada hace referencia a un objeto predeterminado
        /// para el tipo. Generalmente los tipos <see langword="struct"/> se
        /// alamcenan de esta forma.
        /// </summary>
        Default,
        /// <summary>
        /// Indica que la entrada hace referencia a una instancia de objeto con
        /// un conjunto de parámetros de constructor y valores para las
        /// propiedades que pueden ser escritas.
        /// </summary>
        Instance
    }
}
