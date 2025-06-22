using System.Runtime.CompilerServices;
using Tortuga.Anchor.Modeling;
using Tortuga.Anchor.Modeling.Internals;

namespace Tortuga.Sails
{
    /// <summary>
    /// Base class for view models.
    /// </summary>
    public class ViewModelBase : ModelBase
    {
        /// <summary>
        /// Occurs when a Command throws an exception.
        /// </summary>
        public static event EventHandler<UnhandledViewModelExceptionEventArgs>? UnhandledCommandError;

        /// <summary>
        /// Returns an ICommand wrapped around the provided asynchronous action.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command">The command.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>DelegateCommand&lt;T&gt;.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// command
        /// or
        /// propertyName
        /// </exception>
        /// <exception cref="System.ArgumentException">propertyName</exception>
        /// <remarks>For this overload, you may need to explicitly provide the type parameter</remarks>

        protected DelegateCommand<T> GetCommand<T>(Func<T, Task> command, [CallerMemberName] string propertyName = "")
        {
            return GetCommandBase(async (T obj) => await command(obj), propertyName);
        }

        /// <summary>
        /// Returns an ICommand wrapped around the provided asynchronous action.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>DelegateCommand.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// command
        /// or
        /// propertyName
        /// </exception>
        /// <exception cref="System.ArgumentException">propertyName</exception>
        protected DelegateCommand GetCommand(Func<Task> command, [CallerMemberName] string propertyName = "")
        {
            return GetCommandBase(async () => await command(), propertyName);
        }

        /// <summary>
        /// Returns an ICommand wrapped around the provided action.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command">The command.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>DelegateCommand&lt;T&gt;.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// command
        /// or
        /// propertyName
        /// </exception>
        /// <exception cref="System.ArgumentException">propertyName</exception>
        protected DelegateCommand<T> GetCommand<T>(Action<T> command, [CallerMemberName] string propertyName = "")
        {
            return GetCommandBase(command, propertyName);
        }

        /// <summary>
        /// Returns an ICommand wrapped around the provided action.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>DelegateCommand&lt;System.Object&gt;.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// command
        /// or
        /// propertyName
        /// </exception>
        /// <exception cref="System.ArgumentException">propertyName</exception>
        protected DelegateCommand<object> GetCommand(Action<object> command, [CallerMemberName] string propertyName = "")
        {
            return GetCommandBase(command, propertyName);
        }

        /// <summary>
        /// Returns an ICommand wrapped around the provided action.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>DelegateCommand.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// command
        /// or
        /// propertyName
        /// </exception>
        /// <exception cref="System.ArgumentException">propertyName</exception>
        protected DelegateCommand GetCommand(Action command, [CallerMemberName] string propertyName = "")
        {
            return GetCommandBase(command, propertyName);
        }

        /// <summary>
        /// Returns an ICommand wrapped around the provided action.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command">The command.</param>
        /// <param name="canExecute">The can execute.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>DelegateCommand&lt;T&gt;.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// command
        /// or
        /// propertyName
        /// </exception>
        /// <exception cref="System.ArgumentException">propertyName</exception>
        protected DelegateCommand<T> GetCommand<T>(Action<T> command, Func<T, bool> canExecute, [CallerMemberName] string propertyName = "")
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command), $"{nameof(command)} is null.");
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName), $"{nameof(propertyName)} is null");
            if (string.IsNullOrEmpty(propertyName))
                throw new ArgumentException($"{nameof(propertyName)} is empty", nameof(propertyName));

            if (!Properties.IsDefined(propertyName))
            {
                void safeCommand(T p)
                {
                    try
                    {
                        command(p);
                    }
                    catch (Exception ex)
                    {
                        var args = new UnhandledViewModelExceptionEventArgs(ex);
                        UnhandledCommandError?.Invoke(this, args);
                        if (!args.Handled)
                            throw;
                    }
                }

                Properties.Set(new DelegateCommand<T>(p => safeCommand(p), p => canExecute(p)), PropertySetModes.SetAsOriginal, propertyName);
            }

            return Get<DelegateCommand<T>>(propertyName);
        }

        /// <summary>
        /// Returns an ICommand wrapped around the provided action.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="canExecute">The can execute.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>DelegateCommand&lt;System.Object&gt;.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// command
        /// or
        /// propertyName
        /// </exception>
        /// <exception cref="System.ArgumentException">propertyName</exception>
        protected DelegateCommand<object> GetCommand(Action<object> command, Func<object, bool> canExecute, [CallerMemberName] string propertyName = "")
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command), $"{nameof(command)} is null.");
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName), $"{nameof(propertyName)} is null");
            if (string.IsNullOrEmpty(propertyName))
                throw new ArgumentException($"{nameof(propertyName)} is empty", nameof(propertyName));

            if (!Properties.IsDefined(propertyName))
            {
                void safeCommand(object p)
                {
                    try
                    {
                        command(p);
                    }
                    catch (Exception ex)
                    {
                        var args = new UnhandledViewModelExceptionEventArgs(ex);
                        UnhandledCommandError?.Invoke(this, args);
                        if (!args.Handled)
                            throw;
                    }
                }

                Properties.Set(new DelegateCommand<object>(safeCommand, canExecute), PropertySetModes.SetAsOriginal, propertyName);
            }

            return Get<DelegateCommand<object>>(propertyName);
        }

        /// <summary>
        /// Returns an ICommand wrapped around the provided action.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="canExecute">The can execute.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>DelegateCommand.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// command
        /// or
        /// propertyName
        /// </exception>
        /// <exception cref="System.ArgumentException">propertyName</exception>
        protected DelegateCommand GetCommand(Action command, Func<bool> canExecute, [CallerMemberName] string propertyName = "")
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command), $"{nameof(command)} is null.");
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName), $"{nameof(propertyName)} is null");
            if (string.IsNullOrEmpty(propertyName))
                throw new ArgumentException($"{nameof(propertyName)} is empty", nameof(propertyName));

            if (!Properties.IsDefined(propertyName))
            {
                void safeCommand()
                {
                    try
                    {
                        command();
                    }
                    catch (Exception ex)
                    {
                        var args = new UnhandledViewModelExceptionEventArgs(ex);
                        UnhandledCommandError?.Invoke(this, args);
                        if (!args.Handled)
                            throw;
                    }
                }

                Properties.Set(new DelegateCommand(safeCommand, canExecute), PropertySetModes.SetAsOriginal, propertyName);
            }

            return Get<DelegateCommand>(propertyName);
        }

        DelegateCommand GetCommandBase(Action command, string propertyName)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command), $"{nameof(command)} is null.");
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName), $"{nameof(propertyName)} is null");
            if (string.IsNullOrEmpty(propertyName))
                throw new ArgumentException($"{nameof(propertyName)} is empty", nameof(propertyName));

            if (!Properties.IsDefined(propertyName))
            {
                void safeCommand()
                {
                    try
                    {
                        command();
                    }
                    catch (Exception ex)
                    {
                        var args = new UnhandledViewModelExceptionEventArgs(ex);
                        UnhandledCommandError?.Invoke(this, args);
                        if (!args.Handled)
                            throw;
                    }
                }

                Properties.Set(new DelegateCommand(safeCommand), PropertySetModes.SetAsOriginal, propertyName);
            }

            return Get<DelegateCommand>(propertyName);
        }

        DelegateCommand<object> GetCommandBase(Action<object> command, string propertyName)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command), $"{nameof(command)} is null.");
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName), $"{nameof(propertyName)} is null");
            if (string.IsNullOrEmpty(propertyName))
                throw new ArgumentException($"{nameof(propertyName)} is empty", nameof(propertyName));

            if (!Properties.IsDefined(propertyName))
            {
                void safeCommand(object p)
                {
                    try
                    {
                        command(p);
                    }
                    catch (Exception ex)
                    {
                        var args = new UnhandledViewModelExceptionEventArgs(ex);
                        UnhandledCommandError?.Invoke(this, args);
                        if (!args.Handled)
                            throw;
                    }
                }

                Properties.Set(new DelegateCommand<object>(safeCommand), PropertySetModes.SetAsOriginal, propertyName);
            }

            return Get<DelegateCommand<object>>(propertyName);
        }

        DelegateCommand<T> GetCommandBase<T>(Action<T> command, string propertyName)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command), $"{nameof(command)} is null.");
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName), $"{nameof(propertyName)} is null");
            if (string.IsNullOrEmpty(propertyName))
                throw new ArgumentException($"{nameof(propertyName)} is empty", nameof(propertyName));

            if (!Properties.IsDefined(propertyName))
            {
                void safeCommand(T p)
                {
                    try
                    {
                        command(p);
                    }
                    catch (Exception ex)
                    {
                        var args = new UnhandledViewModelExceptionEventArgs(ex);
                        UnhandledCommandError?.Invoke(this, args);
                        if (!args.Handled)
                            throw;
                    }
                }

                Properties.Set(new DelegateCommand<T>(p => safeCommand(p)), PropertySetModes.SetAsOriginal, propertyName);
            }

            return Get<DelegateCommand<T>>(propertyName);
        }
    }
}
