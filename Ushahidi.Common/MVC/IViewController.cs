using System;

namespace Ushahidi.Common.MVC
{
    /// <summary>
    /// The back handler
    /// </summary>
    public delegate void BackHandler(params object[] parameters);

    /// <summary>
    /// The forward handler
    /// </summary>
    /// <param name="type">view controller type</param>
    /// <param name="clearStack">clear stack</param>
    /// <param name="parameters">parameters</param>
    public delegate void ForwardHandler(Type type, bool clearStack, params object [] parameters);

    /// <summary>
    /// View Controller Interface
    /// </summary>
    public interface IViewController: IDisposable
    {
        /// <summary>
        /// View Name
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Load View
        /// </summary>
        /// <param name="parameters">parameters used to load view</param>
        void Load(params object [] parameters);

        /// <summary>
        /// Save View
        /// </summary>
        /// <returns>true, if successful</returns>
        bool Save();

        /// <summary>
        /// Initialize View
        /// </summary>
        void Initialize();

        /// <summary>
        /// Render View
        /// </summary>
        void Render();

        /// <summary>
        /// Translate View
        /// </summary>
        void Translate();

        /// <summary>
        /// Validate View
        /// </summary>
        /// <returns></returns>
        bool Validate();

        /// <summary>
        /// Show View
        /// </summary>
        void Show();

        /// <summary>
        /// Hide View
        /// </summary>
        void Hide();

        /// <summary>
        /// Back Event
        /// </summary>
        event BackHandler Back;

        /// <summary>
        /// Forward Event
        /// </summary>
        event ForwardHandler Forward;

        /// <summary>
        /// Exit Event
        /// </summary>
        event BackHandler Exit;
    }
}
