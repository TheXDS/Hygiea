namespace TheXDS.Hygiea.Models
{
    /// <summary>
    /// Describes a directory.
    /// </summary>
    public class DirectoryManifest
    {
        /// <summary>
        /// Gets the directory name.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Gets a collection of subdirectories contained inside this directory.
        /// </summary>
        public DirectoryManifest[] SubDirectories { get; set; } = null!;

        /// <summary>
        /// Gets a collection of files stored in this directory.
        /// </summary>
        public FileManifest[] Files { get; set; } = null!;
    }
}
