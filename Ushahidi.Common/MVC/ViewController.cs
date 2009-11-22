using System;
using Ushahidi.Common.Controls;

namespace Ushahidi.Common.MVC
{
    /// <summary>
    /// View Controller
    /// </summary>
    /// <typeparam name="TView">view</typeparam>
    public abstract class ViewController<TView> : IViewController 
        where TView : IView, new()
    {
        /// <summary>
        /// View Name
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
        /// Load View
        /// </summary>
        /// <param name="parameters">parameters used to load view</param>
        public virtual void Load(params object [] parameters)
        {
            //implementing view controller can provide their own load logic
        }

        /// <summary>
        /// Save View
        /// </summary>
        /// <returns>true, if successful</returns>
        public virtual bool Save()
        {
            //implementing view controller can provide their own save logic
            return true;
        }

        /// <summary>
        /// Initialize View
        /// </summary>
        public void Initialize()
        {
            View.Initialize();
        }

        /// <summary>
        /// Render View
        /// </summary>
        public void Render()
        {
            View.Render();
        }

        /// <summary>
        /// Translate View
        /// </summary>
        public void Translate()
        {
            View.Translate();
        }

        /// <summary>
        /// Validate View
        /// </summary>
        /// <returns></returns>
        public bool Validate()
        {
            return View.Validate();
        }

        /// <summary>
        /// Show View
        /// </summary>
        public void Show()
        {
            Keyboard.Visible = false;
            View.Show();
            View.Focus();
            View.Loaded();
        }

        /// <summary>
        /// Hide view
        /// </summary>
        public void Hide()
        {
            Keyboard.Visible = false;
            View.Hide();
        }

        protected void OnLoaded(object sender, EventArgs e)
        {
            View.Loaded();
        }

        /// <summary>
        /// Dispose View
        /// </summary>
        public virtual void Dispose()
        {
            if (!Equals(View, default(TView)))
            {
                View.Dispose();    
            }
        }

        /// <summary>
        /// The back event
        /// </summary>
        public event BackHandler Back;

        /// <summary>
        /// Return to previous form
        /// </summary>
        /// <param name="parameters">parameters to return to previous view controller</param>
        protected void OnBack(params object [] parameters)
        {
            WaitCursor.Hide();
            if (Back != null)
            {
                Back(parameters);
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
        /// <param name="parameters">parameters to pass to next view controller</param>
        protected void OnForward(Type type, params object[] parameters)
        {
            WaitCursor.Hide();
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
        /// <param name="parameters">parameters to pass to next view controller</param>
        protected void OnForward(Type type, bool clearStack, params object [] parameters)
        {
            WaitCursor.Hide();
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
        protected void OnExit(params object [] parameters)
        {
            WaitCursor.Hide();
            if (Exit != null)
            {
                Exit(parameters);
            }
        }

    }
}
