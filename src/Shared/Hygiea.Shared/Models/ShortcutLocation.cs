using System;

namespace TheXDS.Hygiea.Models
{
    /// <summary>
    /// Describes the possible shortcut locations.
    /// </summary>
    [Flags]
    public enum ShortcutLocation
    {
        /// <summary>
        /// Not used. Skip creating this shortcut.
        /// </summary>
        None = 0,

        /// <summary>
        /// Create shortcut on the desktop.
        /// </summary>
        Desktop = 1,

        /// <summary>
        /// Create shortcut on the start menu.
        /// </summary>
        StartMenu = 2,

        /// <summary>
        /// Create shortcut in the "New..." special folder. The shortcut will
        /// appear as an option in the "New..." context menu for directories in
        /// File Explorer.
        /// </summary>
        NewItem = 4,
    }
}
