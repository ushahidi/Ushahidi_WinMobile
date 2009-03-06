using System.ComponentModel;

namespace Ushahidi.Common.MVC
{
    public abstract class Model : IModel
    {
        /// <summary>
        /// Save model
        /// </summary>
        /// <returns>true, if save successful</returns>
        public virtual bool Save()
        {
            return true;
        }

        /// <summary>
        /// Load model
        /// </summary>
        /// <returns>true, if load successful</returns>
        public virtual bool Load()
        {
            return true;
        }

        /// <summary>
        /// Dispose of resources
        /// </summary>
        public virtual void Dispose() {}

        /// <summary>
        /// Property Changed Event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged
        {
            add { _PropertyChanged += value; }
            remove { _PropertyChanged -= value; }
        }private event PropertyChangedEventHandler _PropertyChanged;

        /// <summary>
        /// On property changed event
        /// </summary>
        /// <param name="propertyName">name of property changed</param>
        protected void OnPropertyChanged(string propertyName)
        {
            if (null != _PropertyChanged)
            {
                _PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
