using System;
using System.ComponentModel;

namespace Ushahidi.Common.MVC
{
    /// <summary>
    /// View Controller
    /// </summary>
    /// <typeparam name="TView">view</typeparam>
    /// <typeparam name="TModel">model</typeparam>
    public abstract class ViewController<TView, TModel> : IViewController 
        where TView : IView, new()
        where TModel : IModel, new()
    {
        /// <summary>
        /// View name
        /// </summary>
        public string Name
        {
            get { return View.ToString(); }
        }

        /// <summary>
        /// The view
        /// </summary>
        protected TView View
        {
            get
            {
                if (Equals(_View, default(TView)))
                {
                    _View = new TView();
                    _View.Back += OnBack;
                    _View.Forward += OnForward;
                    _View.Exit += OnExit;
                }
                return _View;
            }
        }private TView _View;

        /// <summary>
        /// The model
        /// </summary>
        protected TModel Model
        {
            get
            {
                if (Equals(_Model, default(TModel)))
                {
                    _Model = new TModel();
                    _Model.PropertyChanged += OnModelChanged;
                }
                return _Model;
            }
            set
            {
                if (!Equals(_Model, default(TModel)))
                {
                    //remove old property changed handler
                    _Model.PropertyChanged -= OnModelChanged;
                }
                _Model = value;
            }
        }private TModel _Model;

        /// <summary>
        /// Load view with model data
        /// </summary>
        public virtual void Load()
        {
            //implementing view controller can provide their own load logic
        }

        /// <summary>
        /// Save model data from view
        /// </summary>
        /// <returns>true, if successful</returns>
        public virtual bool Save()
        {
            //implementing view controller can provide their own save logic
            return true;
        }

        /// <summary>
        /// Render the view
        /// </summary>
        public void Render()
        {
            View.Render();
        }

        /// <summary>
        /// Show view
        /// </summary>
        public void Show()
        {
            View.Show();
        }

        /// <summary>
        /// Hide view
        /// </summary>
        public void Hide()
        {
            View.Hide();
        }

        /// <summary>
        /// Dispose of view
        /// </summary>
        public virtual void Dispose()
        {
            if (!Equals(View, default(TView)))
            {
                View.Dispose();    
            }
            if (!Equals(Model, default(TModel)))
            {
                Model.Dispose();
            }
        }

        /// <summary>
        /// On model changed event
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="e">PropertyChangedEventArgs</param>
        public virtual void OnModelChanged(object sender, PropertyChangedEventArgs e)
        {
            //implementing view controller will override and provide on model changed code
        }
       
        /// <summary>
        /// The back event
        /// </summary>
        public event BackHandler Back;

        /// <summary>
        /// Return to previous form
        /// </summary>
        protected void OnBack()
        {
            if (Back != null)
            {
                Back();
            }
        }

        /// <summary>
        /// The forward event
        /// </summary>
        public event ForwardHandler Forward;

        /// <summary>
        /// Move forward
        /// </summary>
        /// <param name="type">view controller type</param>
        protected void OnForward(Type type)
        {
            if (Forward != null)
            {
                Forward(type, false);
            }
        }

        /// <summary>
        /// Move forward
        /// </summary>
        /// <param name="type">view controller type</param>
        /// <param name="clearStack">should clear stack?</param>
        protected void OnForward(Type type, bool clearStack)
        {
            if (Forward != null)
            {
                Forward(type, clearStack);
            }
        }

        /// <summary>
        /// The exit event
        /// </summary>
        public event BackHandler Exit;

        /// <summary>
        /// Exit application
        /// </summary>
        protected void OnExit()
        {
            if (Exit != null)
            {
               Exit();
            }
        }
    }
}
