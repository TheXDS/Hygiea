using System.Collections.Generic;
using TheXDS.Hygiea.Component;
using TheXDS.Hygiea.ViewModel;

namespace TheXDS.Hygiea.Models
{
    public class SetupManifest
    {
        public string ProductName { get; set; }
        public string Version { get; set; }
        public string Company { get; set; }
        public long PayloadSize { get; set; }
        public SetupAction AvailableActions { get; set; }
        public string DefaultInstallPath { get; set; }
        public string DefaultMenuPath { get; set; }
        public OptionPayload[] Options { get; set; }
    }

    public struct RunningConfiguration
    {
        public ICloseable Host { get; }
        public MinimalSetupState SetupState { get; }
        public IEnumerable<SetupPageViewModel> Pages { get; }
    }
}
