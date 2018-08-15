using System;
using System.Linq;
using System.Windows.Input;

namespace Tortuga.Sails
{
    /// <summary>
    /// This represents an ICommand that isn't supported. It is used in abstract base classes where subclasses may optionally overide it.
    /// </summary>
    /// <seealso cref="System.Windows.Input.ICommand" />
    public sealed class NotSupportedCommand : ICommand
    {
        /// <summary>
        /// NotSupportedCommand singleton.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes")]
        public static readonly NotSupportedCommand Value = new NotSupportedCommand();

        private NotSupportedCommand()
        { }

        event EventHandler ICommand.CanExecuteChanged
        {
            add { }
            remove { }
        }

        bool ICommand.CanExecute(object parameter)
        {
            return false;
        }

        void ICommand.Execute(object parameter)
        {
        }
    }
}