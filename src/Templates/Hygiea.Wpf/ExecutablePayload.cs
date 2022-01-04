namespace TheXDS.Hygiea.Models
{
    /// <summary>
    /// Describes a payload that extracts directly to an executable file and
    /// ran afterwards.
    /// </summary>
    /// <remarks>
    /// The executable file extracted from this payload will be located at a
    /// temporary directory.
    /// If the <see cref="PayloadBase.PayloadStreamName"/> is set to 
    /// <see langword="null"/> or <see cref="string.Empty"/>, the
    /// <see cref="CmdLineArgs"/> property will be treated as a direct command
    /// to be executed.
    /// </remarks>
    public class ExecutablePayload : PayloadBase
    {
        /// <summary>
        /// Gets a <see cref="string"/> that contains the command line args to
        /// be passed to the extracted executable when being invoked.
        /// </summary>
        public string CmdLineArgs { get; set; } = null!;

        /// <summary>
        /// Gets an array with all the exit codes (apart from 0x0) to be
        /// ignored (or marked as successful) when executing this payload.
        /// </summary>
        public int[] IgnoreExitCodes { get; set; } = null!;
    }
}
