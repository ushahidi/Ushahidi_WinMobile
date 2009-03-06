using System;

namespace Ushahidi.Common.MVC
{
    /// <summary>
    /// View interface
    /// </summary>
    public interface IView : IDisposable
    {
        /// Show view
        /// </summary>
        void Show();

        /// <summary>
        /// Hide view
        /// </summary>
        void Hide();

        /// <summary>
        /// Render view
        /// </summary>
        void Render();

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
    }
}
