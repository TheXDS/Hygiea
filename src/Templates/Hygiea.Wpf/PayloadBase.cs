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
        public Guid PayloadId { get; set; }

        /// <summary>
        /// Gets or sets a value that describes this option.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Gets or sets an array of required options if this is option is to
        /// be selected.
        /// </summary>
        public Guid[] Requires { get; set; } = null!;

        /// <summary>
        /// Gets or sets an array of conflicting options that must be
        /// unselected if this option is to be selected.
        /// </summary>
        public Guid[] BlockedBy { get; set; } = null!;

        /// <summary>
        /// Gets or sets a value that indicates if this option is required to
        /// proceed with the install process.
        /// </summary>
        public bool Required { get; set; }

        /// <summary>
        /// Gets the file payload name used to open a stream from which to read
        /// the contents of this option from.
        /// </summary>
        public string PayloadStreamName { get; set; } = null!;

        /// <summary>
        /// Gets the pre-computed payload hash used to verify the actual
        /// payload contents.
        /// </summary>
        public byte[] Hash { get; set; } = null!;

        /// <summary>
        /// Gets a value that indicates if the payload file name refers to an
        /// external file.
        /// </summary>
        public bool External { get; set; }

        /// <summary>
        /// Gets a value that indicates the compression mode to use when
        /// reading the payload stream.
        /// </summary>
        public PayloadCompression CompressionMode { get; set; }
    }
}
