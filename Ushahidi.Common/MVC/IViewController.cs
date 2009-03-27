using System;
using System.ComponentModel;

namespace Ushahidi.Common.MVC
{
    /// <summary>
    /// The back handler
    /// </summary>
    public delegate void BackHandler();

    /// <summary>
    /// The forward handler
    /// </summary>
    /// <param name="type">view controller type</param>
    /// <param name="clearStack">clear stack</param>
    public delegate void ForwardHandler(Type type, bool clearStack);

    /// <summary>
    /// View Controller Interface
    /// </summary>
    public interface IViewController: IDisposable
    {
        /// <summary>
        /// View name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Save error caption
        /// </summary>
        string SaveErrorCaption { get; }

        /// <summary>
        /// Save error message
        /// </summary>
        string SaveErrorMessage { get; }

        /// <summary>
        /// Load view with model data
        /// </summary>
        void Load();

        /// <summary>
        /// Save model from view data
        /// </summary>
        /// <returns>true, if successful</returns>
        bool Save();

        /// <summary>
        /// Render the view
        /// </summary>
        void Render();

        /// <summary>
        /// Show the view
        /// </summary>
        void Show();

        /// <summary>
        /// Hide the view
        /// </summary>
        void Hide();

        /// <summary>
        /// The back event
        /// </summary>
        event BackHandler Back;

        /// <summary>
        /// The forward event
        /// </summary>
        event ForwardHandler Forward;

        /// <summary>
        /// The exit event
        /// </summary>
        event BackHandler Exit;

        /// <summary>
        /// On model changed event
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">PropertyChangedEventArgs</param>
        void OnModelChanged(object sender, PropertyChangedEventArgs e);
    }
}
