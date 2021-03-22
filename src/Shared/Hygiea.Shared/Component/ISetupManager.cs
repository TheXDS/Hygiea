using System;
using TheXDS.Hygiea.Models;
using TheXDS.Hygiea.ViewModel;

namespace TheXDS.Hygiea.Component
{
    public interface ISetupManager<out T> : ISetupManager where T : notnull, MinimalSetupState, new()
    {
        T Settings { get; }
    }

    public interface ISetupManager
    {
        SimpleCommand BackCommand { get; }

        SimpleCommand CancelCommand { get; }

        SimpleCommand NextCommand { get; }

        void Fail(Exception ex);
    }
}
