﻿using System;
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
        /// Returns an ICommand wrapped around the provided action.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        protected DelegateCommand<T> GetCommand<T>(Action<T> command, [CallerMemberName] string propertyName = null)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command), $"{nameof(command)} is null.");
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName), $"{nameof(propertyName)} is null");
            if (string.IsNullOrEmpty(propertyName))
                throw new ArgumentException($"{nameof(propertyName)} is empty", nameof(propertyName));


            if (!Properties.IsDefined(propertyName))
                Properties.Set(new DelegateCommand<T>(p => command(p)), PropertySetModes.SetAsOriginal, propertyName);

            return Get<DelegateCommand<T>>(propertyName);
        }

        /// <summary>
        /// Returns an ICommand wrapped around the provided action.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        protected DelegateCommand<object> GetCommand(Action<object> command, [CallerMemberName] string propertyName = null)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command), $"{nameof(command)} is null.");
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName), $"{nameof(propertyName)} is null");
            if (string.IsNullOrEmpty(propertyName))
                throw new ArgumentException($"{nameof(propertyName)} is empty", nameof(propertyName));

            if (!Properties.IsDefined(propertyName))
                Properties.Set(new DelegateCommand<object>(command), PropertySetModes.SetAsOriginal, propertyName);

            return Get<DelegateCommand<object>>(propertyName);
        }

        /// <summary>
        /// Returns an ICommand wrapped around the provided action.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        protected DelegateCommand GetCommand(Action command, [CallerMemberName] string propertyName = null)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command), $"{nameof(command)} is null.");
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName), $"{nameof(propertyName)} is null");
            if (string.IsNullOrEmpty(propertyName))
                throw new ArgumentException($"{nameof(propertyName)} is empty", nameof(propertyName));

            if (!Properties.IsDefined(propertyName))
                Properties.Set(new DelegateCommand(command), PropertySetModes.SetAsOriginal, propertyName);

            return Get<DelegateCommand>(propertyName);
        }


        /// <summary>
        /// Returns an ICommand wrapped around the provided action.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="command"></param>
        /// <param name="canExecute"></param>
        /// <returns></returns>
        protected DelegateCommand<T> GetCommand<T>(Action<T> command, Func<T, bool> canExecute, [CallerMemberName] string propertyName = null)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command), $"{nameof(command)} is null.");
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName), $"{nameof(propertyName)} is null");
            if (string.IsNullOrEmpty(propertyName))
                throw new ArgumentException($"{nameof(propertyName)} is empty", nameof(propertyName));

            if (!Properties.IsDefined(propertyName))
                Properties.Set(new DelegateCommand<T>(p => command(p), p => canExecute(p)), PropertySetModes.SetAsOriginal, propertyName);

            return Get<DelegateCommand<T>>(propertyName);
        }

        /// <summary>
        /// Returns an ICommand wrapped around the provided action.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="command"></param>
        /// <param name="canExecute"></param>
        /// <returns></returns>
        protected DelegateCommand<object> GetCommand(Action<object> command, Func<object, bool> canExecute, [CallerMemberName] string propertyName = null)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command), $"{nameof(command)} is null.");
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName), $"{nameof(propertyName)} is null");
            if (string.IsNullOrEmpty(propertyName))
                throw new ArgumentException($"{nameof(propertyName)} is empty", nameof(propertyName));

            if (!Properties.IsDefined(propertyName))
                Properties.Set(new DelegateCommand<object>(command, canExecute), PropertySetModes.SetAsOriginal, propertyName);

            return Get<DelegateCommand<object>>(propertyName);
        }

        /// <summary>
        /// Returns an ICommand wrapped around the provided action.
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="command"></param>
        /// <param name="canExecute"></param>
        /// <returns></returns>
        protected DelegateCommand GetCommand(Action command, Func<bool> canExecute, [CallerMemberName] string propertyName = null)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command), $"{nameof(command)} is null.");
            if (propertyName == null)
                throw new ArgumentNullException(nameof(propertyName), $"{nameof(propertyName)} is null");
            if (string.IsNullOrEmpty(propertyName))
                throw new ArgumentException($"{nameof(propertyName)} is empty", nameof(propertyName));

            if (!Properties.IsDefined(propertyName))
                Properties.Set(new DelegateCommand(command, canExecute), PropertySetModes.SetAsOriginal, propertyName);

            return Get<DelegateCommand>(propertyName);
        }

    }
}