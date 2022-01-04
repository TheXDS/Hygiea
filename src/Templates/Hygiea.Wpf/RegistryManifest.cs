namespace TheXDS.Hygiea.Models
{
    /// <summary>
    /// Describes a registry key.
    /// </summary>
    public class RegistryManifest
    {
        /// <summary>
        /// Gets the name of the key.
        /// </summary>
        public string KeyName { get; set; } = null!;

        /// <summary>
        /// Gets a colleciton of subkeys inside this key.
        /// </summary>
        public RegistryManifest[] SubKeys { get; set; } = null!;

        /// <summary>
        /// Gets a collection of values inside this key.
        /// </summary>
        public RegistryKeyValueManifest[] Values { get; set; } = null!;
    }
}
