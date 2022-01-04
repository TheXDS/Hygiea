namespace TheXDS.Hygiea.Models
{
    /// <summary>
    /// Contains a blob of information about a single payload for an
    /// installable product.
    /// </summary>
    public class FilePayload : PayloadBase
    {
        /// <summary>
        /// Gets a value that indicates the uncompressed, fully extracted
        /// payload size of this option, in bytes.
        /// </summary>
        public long PayloadSize { get; set; }

        /// <summary>
        /// Gets or sets an array of paths to be added to the %PATH%
        /// environment variable.
        /// </summary>
        public string[] PathVarDirs { get; set; } = null!;

        /// <summary>
        /// Gets the root directory that describes the contents of this
        /// payload.
        /// </summary>
        /// <remarks>
        /// The <see cref="DirectoryManifest.Name"/> property of this object
        /// contains a <see cref="string"/> to be combined with the root setup
        /// manifest path, and if such is not defined, this value must contain
        /// a full install path. Can be set to <see langword="null"/> or
        /// <see cref="string.Empty"/> to install to the setup manifest root
        /// path. If the path in this value after expanding all environment
        /// variables resolves to a full path, this value is used instead of
        /// combining it with the root manifest path for this option.
        /// </remarks>
        public DirectoryManifest[] RootDirectory { get; set; } = null!;

        /// <summary>
        /// Gets a collection of registry entries to add when installing this
        /// option.
        /// </summary>
        public RegistryManifest[] RegistryEntries { get; set; } = null!;

        /// <summary>
        /// Gets a collection of shortcuts to be created when installing this option.
        /// </summary>
        public ShortcutManifest[] Shortcuts { get; set; } = null!;
    }
}
