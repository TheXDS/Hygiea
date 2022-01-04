using System.IO;

namespace TheXDS.Hygiea.Component.BinaryReaders
{
    /// <summary>
    /// Indicates the kind of the incoming object described in the source
    /// <see cref="BinaryReader"/>.
    /// </summary>
    public enum ObjectType : byte
    {
        /// <summary>
        /// Indicates that the incoming object is <see langword="null"/>.
        /// </summary>
        Null,
        /// <summary>
        /// Indicates that the object must be instanced using its default
        /// constructor. <see langword="struct"/> values (except primitive
        /// values) are always marked with this flag.
        /// </summary>
        Default,
        /// <summary>
        /// Indicates that the object will be instanced using a constructor,
        /// selected by an <see cref="int"/> index, whose arguments follow
        /// this definition. Property values will further follow the
        /// constructor arguments.
        /// </summary>
        Instance
    }
}
