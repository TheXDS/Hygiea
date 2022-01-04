namespace TheXDS.Hygiea.Models
{
    /// <summary>
    /// Enumerates the available compression methods to read payload files.
    /// </summary>
    public enum PayloadCompression : byte
    {
        /// <summary>
        /// No compression. Read payload stream as-is.
        /// </summary>
        None,

        /// <summary>
        /// Use a <see cref="System.IO.Compression.DeflateStream"/> to read the
        /// contents of the payload stream.
        /// </summary>
        Deflate,

        /// <summary>
        /// Use a <see cref="System.IO.Compression.GZipStream"/> to read the
        /// contents of the payload stream.
        /// </summary>
        GZip,
    }
}
