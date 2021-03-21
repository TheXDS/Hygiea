using TheXDS.Hygiea.Component;

namespace TheXDS.Hygiea.ViewModel
{
    public class SetupPageViewModel : ViewModelBase
    {
        public ISetupManager Setup { get; internal set; }

        public virtual void OnNavigated() { }
    }
}
