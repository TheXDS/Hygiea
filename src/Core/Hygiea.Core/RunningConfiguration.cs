using System.Collections.Generic;
using TheXDS.Hygiea.Component;
using TheXDS.Hygiea.ViewModel;

namespace TheXDS.Hygiea.Models
{
    public struct RunningConfiguration
    {
        public ICloseable Host { get; }
        public MinimalSetupState SetupState { get; }
        public IEnumerable<SetupPageViewModel> Pages { get; }
    }
}
