using System;
using System.ComponentModel;

namespace Ushahidi.Common.MVC
{
    /// <summary>
    /// Model interface
    /// </summary>
    public interface IModel : IDisposable, INotifyPropertyChanged
    {
        /// <summary>
        /// Save model
        /// </summary>
        /// <returns>true, if save successful</returns>
        bool Save();

        /// <summary>
        /// Load model
        /// </summary>
        /// <returns>true, if load successful</returns>
        bool Load();
    }
}
