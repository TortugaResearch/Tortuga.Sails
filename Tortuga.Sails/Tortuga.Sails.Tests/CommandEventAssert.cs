using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Input;

namespace Tortuga.Sails.Tests
{
    /// <summary>
    /// Assertions for ICommand
    /// </summary>
    public class CommandEventAssert : EventAssert<EventArgs>
    {
        readonly ICommand m_Source;

        /// <summary>
        /// Creates a new ICommand assertion
        /// </summary>
        /// <param name="source"></param>
        public CommandEventAssert(ICommand source)
            : base(source)
        {
            if (source == null)
                throw new ArgumentNullException("source", "source is null.");

            m_Source = source;
            m_Source.CanExecuteChanged += SourceEventFired;
        }

        /// <summary>
        /// Asserts that an event is in the queue and that it has the indicated properties.
        /// </summary>
        /// <param name="expectedResult">Expected result from calling CanExecute(commandParameter)</param>
        /// <returns>This will remove the event from the queue.</returns>
        public EventPair<EventArgs> Expect(bool expectedResult)
        {
            return Expect(expectedResult, null);
        }

        /// <summary>
        /// Asserts that an event is in the queue and that it has the indicated properties.
        /// </summary>
        /// <param name="expectedResult">Expected result from calling CanExecute(commandParameter)</param>
        /// <param name="commandParameter">Parameter to pass to CanExecute</param>
        /// <returns>This will remove the event from the queue.</returns>
        public EventPair<EventArgs> Expect(bool expectedResult, object commandParameter)
        {
            var nextEvent = Expect();
            Assert.AreEqual(expectedResult, m_Source.CanExecute(commandParameter));
            return nextEvent;
        }
    }
}
