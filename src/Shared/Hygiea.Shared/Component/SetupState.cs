using TheXDS.Hygiea.ViewModel;

namespace TheXDS.Hygiea.Models
{
    /// <summary>
    /// Describes the current statue of the setup program.
    /// </summary>
    public class SetupState : ViewModelBase
    {
        private SetupAction _action;

        /// <summary>
        /// Gets a reference to the manifest for which the setup process will
        /// be executed.
        /// </summary>
        public SetupManifest SetupManifest { get; }

        /// <summary>
        /// Gets or sets the currently executing action.
        /// </summary>
        public SetupAction Action
        {
            get => _action;
            set => Change(ref _action, value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SetupState"/> class.
        /// </summary>
        /// <param name="setupManifest"></param>
        public SetupState(SetupManifest setupManifest)
        {
            SetupManifest = setupManifest;
        }
    }
}
