﻿using System;

namespace Ushahidi.Common.MVC
{
    /// <summary>
    /// Navigation Controller Interface
    /// </summary>
    public interface INavigationController : IDisposable
    {
        /// <summary>
        /// Run the application thread
        /// </summary>
        void Run();

        /// <summary>
        /// Push a new type onto the stack passing it the provided arguments
        /// </summary>
        /// <param name="type">view controller type</param>
        void Push(Type type);

        /// <summary>
        /// Push a new type onto the stack passing it the provided arguments
        /// </summary>
        /// <param name="type">view controller type</param>
        /// <param name="clearStack">should clear stack?</param>
        /// <param name="parameters">parameters to pass to next view controller</param>
        void Push(Type type, bool clearStack, params object [] parameters);

        /// <summary>
        /// Pop top view from stack
        /// </summary>
        /// <param name="parameters">parameters to return to previous view controller</param>
        void Pop(params object [] parameters);

        /// <summary>
        /// The stack depth
        /// </summary>
        int Depth { get; }
    }
}
