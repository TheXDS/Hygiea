using System;
using System.Collections.Generic;
using TheXDS.Hygiea.ViewModel;

namespace TheXDS.Hygiea.Models
{
    public class MinimalSetupState : ViewModelBase
    {
        public SetupManifest SetupManifest { get; }

        private SetupAction _action;

        public SetupAction Action
        {
            get => _action;
            set => Change(ref _action, value);
        }

        public List<OptionPayload> Options { get; } = new List<OptionPayload>();
    }

    [Flags]
    public enum SetupAction : byte
    {
        Install = 1,
        Modify = 2,
        Check = 4,
        Repair = 8,
        Uninstall = 16,
        Update = 32
    }
}
