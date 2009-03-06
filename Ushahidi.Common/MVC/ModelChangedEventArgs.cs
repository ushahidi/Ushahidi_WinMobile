using System;

namespace Ushahidi.Common.MVC
{
    /// <summary>
    /// Model changed event args
    /// </summary>
    /// <typeparam name="T">value type</typeparam>
    public class ModelChangedEventArgs<T> : EventArgs
    {
        /// <summary>
        /// Model changed event args
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="value">value</param>
        public ModelChangedEventArgs(string name, T value)
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
