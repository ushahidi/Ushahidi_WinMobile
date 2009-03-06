using System;

namespace Ushahidi.Common.MVC
{
    /// <summary>
    /// Generic event args
    /// </summary>
    /// <typeparam name="T">value type</typeparam>
    public class EventArgs<T> : EventArgs
    {
        /// <summary>
        /// Generic event args
        /// </summary>
        /// <param name="value">event value</param>
        public EventArgs(T value)
        {
            Value = value;
        }

        /// <summary>
        /// Event value
        /// </summary>
        public T Value { get; private set; }
    }

}
