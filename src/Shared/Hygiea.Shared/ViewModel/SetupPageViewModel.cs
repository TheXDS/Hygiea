using System;
using System.ComponentModel;
using TheXDS.Hygiea.Component;
using TheXDS.Hygiea.Models;

namespace TheXDS.Hygiea.ViewModel
{
    public interface ISetupPageViewModel : INotifyPropertyChanged
    {
        ISetupManager Setup { get; }
        void OnNavigated();
    }

    internal interface ISetSetupPageViewModel : ISetupPageViewModel
    {
        void SetSetup(ISetupManager manager);
    }

    public interface ISetupPageViewModel<T> : ISetupPageViewModel where T : notnull, MinimalSetupState, new()
    {
        new ISetupManager<T> Setup { get; }
    }

    internal interface ISetSetupPageViewModel<T> : ISetSetupPageViewModel where T : notnull, MinimalSetupState, new()
    {
        new void SetSetup(ISetupManager<T> manager);
    }

    public class SetupPageViewModel : ViewModelBase, ISetSetupPageViewModel
    {
        public ISetupManager Setup { get; private protected set; }

        public virtual void OnNavigated() { }

        void ISetSetupPageViewModel.SetSetup(ISetupManager manager)
        {
            Setup = manager;
        }
    }

    public class SetupPageViewModel<T> : SetupPageViewModel, ISetSetupPageViewModel<T> where T : notnull, MinimalSetupState, new()
    {
        public new ISetupManager<T> Setup => (ISetupManager<T>)base.Setup;

        void ISetSetupPageViewModel.SetSetup(ISetupManager manager)
        {
            ((ISetSetupPageViewModel<T>)this).SetSetup(manager is ISetupManager<T> m ? m : throw new InvalidCastException());
        }

        void ISetSetupPageViewModel<T>.SetSetup(ISetupManager<T> manager)
        {
            base.Setup = manager;
        }
    }
}