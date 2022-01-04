namespace TheXDS.Hygiea.Models
{
    /// <summary>
    /// Describes a shortcut.
    /// </summary>
    public class ShortcutManifest
    {
        /// <summary>
        /// Gets the display name of this shortcut.
        /// </summary>
        public string ShortcutName { get; set; } = null!;
        /// <summary>
        /// Gets the intended target for the shortcut.
        /// </summary>
        public string ProgramExecutable { get; set; } = null!;

        /// <summary>
        /// Gets the arguments to be set on the shortcut properties.
        /// </summary>
        public string ProgramArguments { get; set; } = null!;

        /// <summary>
        /// Gets the intended startup directory to be used when invoking the
        /// shortcut.
        /// </summary>
        public string StartupDirectory { get; set; } = null!;

        /// <summary>
        /// Gets a value that describes the location of the icon for the
        /// shortcut.
        /// </summary>
        public string Icon { get; set; } = null!;

        /// <summary>
        /// Gets a set of flags that describe the locations where this shortcut
        /// should be created.
        /// </summary>
        public ShortcutLocation Location { get; set; }
    }
}
