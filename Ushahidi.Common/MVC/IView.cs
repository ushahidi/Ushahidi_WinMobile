﻿using System;

namespace Ushahidi.Common.MVC
{
    /// <summary>
    /// View interface
    /// </summary>
    public interface IView : IDisposable
    {
        /// <summary>
        /// Visibility
        /// </summary>
        bool Visible { get; set; }

        /// <summary>
        /// Initialize view
        /// </summary>
        void Initialize();

        /// Show view
        /// </summary>
        void Show();

        /// <summary>
        /// Validate View
        /// </summary>
        bool Validate();

        /// <summary>
        /// Hide view
        /// </summary>
        void Hide();

        /// <summary>
        /// Render view
        /// </summary>
        void Render();

        /// <summary>
        /// Translate view
        /// </summary>
        void Translate();

        /// <summary>
        /// Loaded View
        /// </summary>
        void Loaded();

        /// <summary>
        /// Close view
        /// </summary>
        void Close();
        
        /// <summary>
        /// The forward event
        /// </summary>
        event ForwardHandler Forward;
        
        /// <summary>
        /// The back event
        /// </summary>
        event BackHandler Back;

        /// <summary>
        /// The exit event
        /// </summary>
        event BackHandler Exit;

        /// <summary>
        /// Focus View
        /// </summary>
        /// <returns>true, is focus set</returns>
        bool Focus();
    }
}
