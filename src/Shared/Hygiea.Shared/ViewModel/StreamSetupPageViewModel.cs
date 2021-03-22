using System.IO;
using TheXDS.Hygiea.Models;

namespace TheXDS.Hygiea.ViewModel
{
    public abstract class StreamSetupPageViewModel<T> : SetupPageViewModel<T> where T : notnull, MinimalSetupState, new()
    {
        public Stream PageStream { get; internal set; }
    }
}
