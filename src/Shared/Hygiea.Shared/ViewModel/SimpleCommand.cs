using System;
using System.Windows.Input;

namespace TheXDS.Hygiea.ViewModel
{
    /// <summary>
    /// Implementa un comando simple.
    /// </summary>
    public class SimpleCommand : ViewModelBase, ICommand
    {
        private string _label;
        private bool _canExecute = true;
        private readonly Action _action;

        /// <inheritdoc/>
        public event EventHandler? CanExecuteChanged;

        /// <inheritdoc/>
        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }

        /// <inheritdoc/>
        public void Execute(object parameter)
        {
            _action();
        }

        /// <summary>
        /// Obtiene o establece una etiqueta a asociar con este comando.
        /// </summary>
        public string Label
        {
            get => _label;
            set => Change(ref _label, value);
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase
        /// <see cref="SimpleCommand"/>.
        /// </summary>
        /// <param name="label">Etiqueta a asociar con este comando.</param>
        /// <param name="action">Acción a ejecutar.</param>
        public SimpleCommand(string label, Action action)
        {
            _label = label;
            _action = action;
        }

        /// <summary>
        /// Configura este comando para permitir o denegar la ejecución.
        /// </summary>
        /// <param name="value">
        /// Valor que indica si este comando puede ejecutarse.
        /// </param>
        public void SetCanExecute(bool value)
        {
            _canExecute = value;
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
