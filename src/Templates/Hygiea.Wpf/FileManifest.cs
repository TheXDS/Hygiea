using System.IO;

namespace TheXDS.Hygiea.Models
{
    /// <summary>
    /// Describes a file.
    /// </summary>
    public class FileManifest
    {
        /// <summary>
        /// Gets the file name.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Gets a set of flags to be applied to the extracted file.
        /// </summary>
        public FileAttributes Attributes { get; set; }

        /// <summary>
        /// Gets a value that indicates the full length of this file.
        /// </summary>
        public long Length { get; set; }

        /// <summary>
        /// Gets a value that indicates the offset where the actual file data
        /// is stored in the parent payload stream.
        /// </summary>
        public long Offset { get; set; }

        /// <summary>
        /// Gets the pre-computed hash for the contents of the file.
        /// </summary>
        public byte[] Hash { get; set; } = null!;
    }
}
