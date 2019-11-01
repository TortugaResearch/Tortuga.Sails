using System;
using System.Windows.Input;

namespace Tortuga.Sails
{
    /// <summary>
    /// Creates a delegate-based ICommand for which a command parameter is not needed. 
    /// </summary>
    public class DelegateCommand : ICommand
    {
        readonly Func<bool> m_CanExecute;

        readonly Action m_Command;

        /// <summary>
        /// Creates a Delegate command
        /// </summary>
        /// <param name="command"></param>
        /// <param name="canExecute"></param>
        public DelegateCommand(Action command, Func<bool> canExecute = null)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command), $"{nameof(command)} is null.");

            m_Command = command;
            if (canExecute != null)
                m_CanExecute = canExecute;
        }

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        /// <remarks> This event only exists if a CanExecute delegate is provided. Otherwise add/remove are no-ops.</remarks>
        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (m_CanExecute != null)
                    m_CanExecuteChanged += value;
            }
            remove
            {
                if (m_CanExecute != null)
                    m_CanExecuteChanged -= value;
            }
        }

        private event EventHandler m_CanExecuteChanged;
        /// <summary>
        /// Wraps the specified delegate in a DelegateCommand.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command">The Command delegate.</param>
        /// <param name="canExecute">An optional CanExecute delegate.</param>
        /// <returns></returns>
        /// <remarks>This is just a convenience method for the DelegateCommand constructor for type inference.</remarks>
        public static DelegateCommand<T> Create<T>(Action<T> command, Func<T, bool> canExecute = null)
        {
            return new DelegateCommand<T>(command, canExecute);
        }

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <returns>
        /// true if this command can be executed; otherwise, false.
        /// </returns>
        public bool CanExecute()
        {
            if (m_CanExecute == null)
                return true;
            else
                return m_CanExecute();
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        public void Execute()
        {
            m_Command();
        }

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        /// <returns>
        /// true if this command can be executed; otherwise, false.
        /// </returns>
		bool ICommand.CanExecute(object parameter)
        {
            return CanExecute();
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
		void ICommand.Execute(object parameter)
        {
            Execute();
        }

        /// <summary>
        /// Raises a CanExecuteChanged event.
        /// </summary>
        public void OnCanExecuteChanged()
        {
            m_CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }


    }
}
