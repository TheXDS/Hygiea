using System;
using System.Windows.Input;
using TheXDS.Hygiea.Models;

namespace TheXDS.Hygiea.Component
{
    /// <summary>
    /// Defines a set of members to be implemented by a type that manages the
    /// setup process.
    /// </summary>
    public interface ISetupManager<out T> where T : notnull, SetupState, new()
    {
        /// <summary>
        /// Gets the current setup state for this manager.
        /// </summary>
        T Settings { get; }

        /// <summary>
        /// Gets the command used to navigate back in the setup wizard.
        /// </summary>
        ICommand BackCommand { get; }

        /// <summary>
        /// Gets the command used to cancel the setup process.
        /// </summary>
        ICommand CancelCommand { get; }

        /// <summary>
        /// Gets the command sued to navigate forward in the setup wizard.
        /// </summary>
        ICommand NextCommand { get; }

        /// <summary>
        /// Marks the setup process as failed, providing an
        /// <see cref="Exception"/> that describes the occurred failure.
        /// </summary>
        /// <param name="ex">
        /// <see cref="Exception"/> that caused the setup process to fail.
        /// </param>
        void Fail(Exception ex);
    }
}
