using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Tortuga.Sails.Tests
{
    /// <summary>
	/// Base class for event assertions
	/// </summary>
	/// <typeparam name="TEventArgs"></typeparam>
	public abstract class EventAssert<TEventArgs> where TEventArgs : EventArgs
    {
        readonly object m_Source;

        /// <summary>
        /// This us used for tracking the expected source of an event.
        /// </summary>
        /// <param name="source"></param>
        protected EventAssert(object source)
        {
            if (source == null)
                throw new ArgumentNullException("source");

            m_Source = source;
        }

        /// <summary>
        /// The number of events that have not yet been consumed.
        /// </summary>
        public int Count
        {
            get { return Queue.Count; }
        }

        private Queue<EventPair<TEventArgs>> Queue { get; } = new Queue<EventPair<TEventArgs>>();

        /// <summary>
        /// Asserts that an event is in the queue.
        /// </summary>
        /// <returns>The first event in the queue</returns>
        /// <remarks>This will verify that the sender parameter is correct. This will remove the event from the queue.</remarks>
        public EventPair<TEventArgs> Expect()
        {
            return Expect("");
        }

        /// <summary>
        /// Asserts that an event is in the queue.
        /// </summary>
        /// <returns>The first event in the queue</returns>
        /// <remarks>This will verify that the sender parameter is correct. This will remove the event from the queue.</remarks>
        public EventPair<TEventArgs> Expect(string message)
        {
            if (Count == 0)
            {
                string errorMessage = String.Format(CultureInfo.CurrentUICulture, "No events of type {0} remain in the queue.", typeof(TEventArgs).Name);

                if (!string.IsNullOrWhiteSpace(message))
                    throw new AssertFailedException(message + Environment.NewLine + errorMessage);
                else
                    throw new AssertFailedException(errorMessage);
            }

            var nextEvent = Queue.Dequeue();
            Assert.AreSame(m_Source, nextEvent.Sender, "The sender was not the the object that raised the event");

            return nextEvent;
        }

        /// <summary>
        /// Asserts that the number of pending events equals a given amount without actually consuming those events.
        /// </summary>
        /// <param name="expectedValue"></param>
        public void ExpectCountEquals(int expectedValue)
        {
            ExpectCountEquals(expectedValue, "");
        }

        /// <summary>
        /// Asserts that the number of pending events equals a given amount without actually consuming those events.
        /// </summary>
        /// <param name="expectedValue"></param>
        /// <param name="message"></param>
        public void ExpectCountEquals(int expectedValue, string message)
        {
            if (Count != expectedValue)
            {
                string errorMessage = string.Format(CultureInfo.CurrentUICulture, "Expected {0} events but found {1}", expectedValue, Count);

                if (!string.IsNullOrWhiteSpace(message))
                    throw new AssertFailedException(message + Environment.NewLine + errorMessage);
                else
                    throw new AssertFailedException(errorMessage);
            }
        }

        /// <summary>
        /// Asserts that the event queue is empty.
        /// </summary>
        public void ExpectNothing()
        {
            ExpectCountEquals(0, "");
        }

        /// <summary>
        /// Asserts that the event queue is empty.
        /// </summary>
        public void ExpectNothing(string message)
        {
            ExpectCountEquals(0, message);
        }

        /// <summary>
        /// Attach this to the event in the subclass constructor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void SourceEventFired(object sender, TEventArgs e)
        {
            Queue.Enqueue(new EventPair<TEventArgs>(sender, e));
        }
    }
}
