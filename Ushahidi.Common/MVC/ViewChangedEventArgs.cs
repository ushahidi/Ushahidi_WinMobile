using System;

namespace Ushahidi.Common.MVC
{
    /// <summary>
    /// View changed event args
    /// </summary>
    /// <typeparam name="T">value type</typeparam>
    public class ViewChangedEventArgs<T> : EventArgs
    {
        /// <summary>
        /// View changed event args
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="value">value</param>
        public ViewChangedEventArgs(string name, T value)
        {
            Name = name;
            Value = value;
        }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Value
        /// </summary>
        public T Value { get; private set; }
    }
}
