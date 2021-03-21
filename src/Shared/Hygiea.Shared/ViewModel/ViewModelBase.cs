using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TheXDS.Hygiea.ViewModel
{
    /// <summary>
    /// Implementa un ViewModel con la funcionalidad mínima requerida.
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        /// <inheritdoc/>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Cambia el valor de una propiedad, y ejecuta una notificación de 
        /// cambio de valor.
        /// </summary>
        /// <typeparam name="T">Tipo de propiedad a cambiar.</typeparam>
        /// <param name="property">
        /// Referencia al campo de almacenamiento de la propiedad.
        /// </param>
        /// <param name="newValue">Valor a establecer en la propiedad.</param>
        /// <param name="propertyName">
        /// Nombre de la propiedad. El valor de este argumento es generado
        /// automáticamente por el compilador, por lo que puede omitirse con
        /// seguridad.
        /// </param>
        /// <returns>
        /// <see langword="true"/> si el valor de la propiedad ha cambiado,
        /// <see langword="false"/> en caso contrario.
        /// </returns>
        protected bool Change<T>(ref T property, T newValue, [CallerMemberName] string propertyName = null!)
        {
            if (property?.Equals(newValue) ?? newValue == null) return false;
            property = newValue;
            Change(propertyName);
            return true;
        }
        
        /// <summary>
        /// Notifica del cambio de una propiedad.
        /// </summary>
        /// <param name="propertyName">Nombre de la propiedad.</param>
        protected void Change([CallerMemberName] string propertyName = null!)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
