using System;

namespace TheXDS.Hygiea.Models
{
    /// <summary>
    /// Base class for all payload types.
    /// </summary>
    public abstract class PayloadBase
    {
        /// <summary>
        /// Gets or sets the ID used to idetify this option.
        /// </summary>
        public Guid PayloadId { get; }

        /// <summary>
        /// Gets or sets a value that describes this option.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets or sets an array of required options if this is option is to
        /// be selected.
        /// </summary>
        public Guid[] Requires { get; }

        /// <summary>
        /// Gets or sets an array of conflicting options that must be
        /// unselected if this option is to be selected.
        /// </summary>
        public Guid[] BlockedBy { get; }

        /// <summary>
        /// Gets or sets a value that indicates if this option is required to
        /// proceed with the install process.
        /// </summary>
        public bool Required { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PayloadBase"/> class.
        /// </summary>
        /// <param name="payloadId">ID used to identify this payload.</param>
        /// <param name="name">Display name of the payload.</param>
        /// <param name="requires">
        /// Collection of required payloads to be included if this payload is
        /// selected for installation.
        /// </param>
        /// <param name="blockedBy">
        /// Collection of payloads that block the selection of this payload.
        /// </param>
        /// <param name="required">
        /// Value that indicates if this payload is required for installation.
        /// </param>
        protected PayloadBase(Guid payloadId, string name, Guid[] requires, Guid[] blockedBy, bool required)
        {
            Name = name;
            Requires = requires;
            BlockedBy = blockedBy;
            Required = required;
            PayloadId = payloadId;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PayloadBase"/> class.
        /// </summary>
        /// <param name="payloadId">ID used to identify this payload.</param>
        /// <param name="name">Display name of the payload.</param>
        /// <param name="required">
        /// Value that indicates if this payload is required for installation.
        /// </param>
        protected PayloadBase(Guid payloadId, string name, bool required) : this(payloadId, name, Array.Empty<Guid>(), Array.Empty<Guid>(), required) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="PayloadBase"/> class.
        /// </summary>
        /// <param name="payloadId">ID used to identify this payload.</param>
        /// <param name="name">Display name of the payload.</param>
        protected PayloadBase(Guid payloadId, string name) : this(payloadId, name, false) { }
    }

    /// <summary>
    /// Contains a blob of information about a single payload for an
    /// installable product.
    /// </summary>
    public class OptionPayload : PayloadBase
    {
        /// <summary>
        /// Gets or sets a value that indicates the uncompressed payload size
        /// of this option, in bytes.
        /// </summary>
        public long PayloadSize { get; set; }

        /// <summary>
        /// Gets or sets the install path to be used when installing this 
        /// option.
        /// </summary>
        /// <value>
        /// A <see cref="string"/> to be combined with the root setup manifest
        /// path, and if such is not defined, this value must contain a full
        /// install path. Can be set to <see langword="null"/> to install to
        /// the setup manifest root path. If the path after expanding all
        /// environment variables resolves to a full path, this value is used
        /// instead of combining it with the root manifest path for this
        /// option.
        /// </value>        
        public string? InstallPath { get; set; }

        /// <summary>
        /// Gets or sets an array of paths to be added to the %PATH%
        /// environment variable.
        /// </summary>
        /// <remarks>
        /// Each element will have the same path resolution logic as
        /// <see cref="InstallPath"/>, but realative to it instead.
        /// </remarks>
        public string?[] PathVarDirs { get; set; } = null!;

        /// <summary>
        /// Gets or sets an array of defined shorcuts to be created when
        /// installing this option.
        /// </summary>
        public ProgramShortcut[] Shortcuts { get; set; }
        //public RuntimeDependency[] Dependencies { get; set; }
    }
}
