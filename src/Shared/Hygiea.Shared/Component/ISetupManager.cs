using System;
using TheXDS.Hygiea.Models;
using TheXDS.Hygiea.ViewModel;

namespace TheXDS.Hygiea.Component
{
    public interface ISetupManager
    {
        SetupState Settings { get; }

        SimpleCommand BackCommand { get; }

        SimpleCommand CancelCommand { get; }

        SimpleCommand NextCommand { get; }

        void Fail(Exception ex);
    }
}
