using System.IO;

namespace TheXDS.Hygiea.ViewModel
{
    public abstract class StreamSetupPageViewModel : SetupPageViewModel
    {
        public Stream PageStream { get; internal set; }
    }
}
