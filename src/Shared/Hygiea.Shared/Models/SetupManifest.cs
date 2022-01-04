using System;
using System.Collections.Generic;
using System.Linq;

namespace TheXDS.Hygiea.Models
{
    /// <summary>
    /// Contains the root blob of information about an installable product.
    /// </summary>
    public class SetupManifest
    {
        /// <summary>
        /// Gets the product name.
        /// </summary>
        public string ProductName { get; set; } = null!;

        /// <summary>
        /// Gets the version of the product.
        /// </summary>
        public string Version { get; set; } = null!;

        /// <summary>
        /// Gets the company name.
        /// </summary>
        public string? Company { get; set; }

        public string? ReadmePath { get; set; }

        public string UninstallerPath { get; set; } = null!;
        
        public string? UrlInfoAbout { get; set; }

        public string? UrlUpdateInfo { get; set; }

        public int VersionMajor => int.TryParse(Version?.Split('.')[0] ?? "1", out var v) ? v : 1;
        public int VersionMinor => int.TryParse($"{Version}.0".Split('.')[1], out var v) ? v : 0;


        /// <summary>
        /// Gets or sets a directory from which all packages can derive their
        /// subfolder structure.
        /// </summary>
        /// <value>
        /// A <see cref="string"/> with the path root for the installable
        /// product subcomponents to derive a full path from. Can also be set
        /// to <see langword="null"/>, in which case all components must define
        /// a full install path.
        /// </value>
        public string? InstallPathRoot { get; set; }

        /// <summary>
        /// Enumerates all contained payloads.
        /// </summary>
        public IEnumerable<PayloadBase> Payloads
        {
            get
            {
                return GetType().GetProperties()
                    .Where(p => p.CanRead && typeof(Array).IsAssignableFrom(p.PropertyType))
                    .Select(p => (Array)p.GetValue(this))
                    .SelectMany(p => p.Cast<PayloadBase>());
            }
        }

        /// <summary>
        /// Gets or sets an array with all available options to be installed
        /// for the product.
        /// </summary>
        public FilePayload[] FilePayloads { get; set; } = null!;

        /// <summary>
        /// Gets an array of executable payloads included in this manifest.
        /// </summary>
        public ExecutablePayload[] ExecutablePayloads { get; set; } = null!;
    }
}
