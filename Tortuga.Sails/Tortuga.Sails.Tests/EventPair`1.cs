using System;

namespace Tortuga.Sails.Tests
{
    /// <summary>
    /// This is an event paired with its sender.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class EventPair<T> where T : EventArgs
    {
        /// <summary>
        /// Creates a new EventPair
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventArgs"></param>
        public EventPair(object sender, T eventArgs)
        {
            if (eventArgs == null)
                throw new ArgumentNullException("eventArgs", "eventArgs is null.");

            EventArgs = eventArgs;
            Sender = sender;
        }

        /// <summary>
        /// The EventArgs associated with this event.
        /// </summary>
        public T EventArgs { get; }

        /// <summary>
        /// The sender associated with this event. This may be null.
        /// </summary>
        public object Sender { get; }
    }
}
