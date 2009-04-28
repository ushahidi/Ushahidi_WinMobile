using System;
using System.ComponentModel;
using Ushahidi.Common.Controls;

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
        /// Save error caption
        /// </summary>
        public virtual string SaveErrorCaption
        {
            get { return "Error"; }
        }

        /// <summary>
        /// Save error message
        /// </summary>
        public virtual string SaveErrorMessage
        {
            get { return string.Format("There was a problem saving {0} information", Name); }
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
        /// <param name="parameters">parameters</param>
        public virtual void Load(params object [] parameters)
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
        /// Initialize the view
        /// </summary>
        public void Initialize()
        {
            View.Initialize();
        }

        /// <summary>
        /// Render the view
        /// </summary>
        public void Render()
        {
            View.Render();
        }

        /// <summary>
        /// Translate the view
        /// </summary>
        public void Translate()
        {
            View.Translate();
        }

        /// <summary>
        /// Show view
        /// </summary>
        public void Show()
        {
            Keyboard.KeyboardVisible = false;
            View.Show();
            View.Focus();
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
        /// <param name="parameters">parameters</param>
        protected void OnForward(Type type, params object[] parameters)
        {
            if (Forward != null)
            {
                Forward(type, false, parameters);
            }
        }

        /// <summary>
        /// Move forward
        /// </summary>
        /// <param name="type">view controller type</param>
        /// <param name="clearStack">should clear stack?</param>
        /// <param name="parameters">parameters</param>
        protected void OnForward(Type type, bool clearStack, params object [] parameters)
        {
            if (Forward != null)
            {
                Forward(type, clearStack, parameters);
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
