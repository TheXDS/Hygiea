namespace TheXDS.Hygiea.Models
{
    /// <summary>
    /// Enumerates the possible setup actions.
    /// </summary>
    public enum SetupAction : byte
    {
        /// <summary>
        /// Undefined. Allow the user to select the current state.
        /// </summary>
        Select,

        /// <summary>
        /// Install. The setup process will install the product.
        /// </summary>
        Install,

        /// <summary>
        /// Modify. The setup process will allow the user to modify the
        /// currently installed product.
        /// </summary>
        Modify,

        /// <summary>
        /// Repair. The setup process will analyze the currently installed
        /// product and attempt to fix any corrupted/missing files, registry
        /// entries and dependencies.
        /// </summary>
        Repair,

        /// <summary>
        /// Check. The setup process will analyze the currently installed
        /// product and report any inconsistencies found. No further action
        /// will be taken.
        /// </summary>
        Check,

        /// <summary>
        /// Uninstall. The setup process will remove the entire product from
        /// the computer.
        /// </summary>
        Uninstall,

        /// <summary>
        /// Update. The setup process will analyze the currently installed
        /// product and update all installed files.
        /// </summary>
        Update
    }
}
