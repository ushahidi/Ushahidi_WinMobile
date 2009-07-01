using System.ComponentModel;
using System.Windows.Forms;
using Ushahidi.Common.Logging;

namespace Ushahidi.Common.MVC
{
    /// <summary>
    /// Abstract View
    /// </summary>
    public class View : Form, IView
    {
        /// <summary>
        /// Initialize View
        /// </summary>
        public virtual void Initialize()
        {
            //implementing view can override and provide initialize code
        }

        /// <summary>
        /// Render View
        /// </summary>
        public virtual void Render()
        {
            //implementing view can override and provide render code
        }

        /// <summary>
        /// Translate View
        /// </summary>
        public virtual void Translate()
        {
            //implementing view can override and provide translation code
        }

        /// <summary>
        /// Validate View
        /// </summary>
        /// <returns>true, if valid</returns>
        public virtual bool Validate()
        {
            //implementing view can override and provide validation code
            return true;
        }

        /// <summary>
        /// The forward event
        /// </summary>
        public event ForwardHandler Forward;

        /// <summary>
        /// Move forward
        /// </summary>
        /// <param name="parameters">parameters</param>
        protected void OnForward<TViewController>(params object[] parameters) where TViewController : IViewController
        {
            OnForward<TViewController>(false, parameters);
        }

        /// <summary>
        /// Move forward
        /// </summary>
        /// <param name="clearStack">clear stack</param>
        /// <param name="parameters">parameters</param>
        protected void OnForward<TViewController>(bool clearStack, params object [] parameters) where TViewController : IViewController
        {
            if (Forward != null)
            {
                Forward(typeof(TViewController), clearStack, parameters);
            }
        }

        /// <summary>
        /// The back event
        /// </summary>
        public event BackHandler Back;

        /// <summary>
        /// Back event handler
        /// </summary>
        protected void OnBack(params object [] parameters)
        {
            Log.Info("View.OnBack");
            if (Back != null)
            {
                Back(parameters);
            }
        }

        /// <summary>
        /// Override on closing to cancel close, and instead pop from navigation stack
        /// </summary>
        protected override void OnClosing(CancelEventArgs e)
        {
            Log.Info("View.OnClosing");
            e.Cancel = true;
            if (Back != null)
            {
                Back();
            }
        }

        /// <summary>
        /// The exit event
        /// </summary>
        public event BackHandler Exit;

        /// <summary>
        /// On Exit event handler
        /// </summary>
        protected void OnExit()
        {
            Log.Info("View.OnExit");
            if (Exit != null)
            {
                Exit();
            }
        }

        /// <summary>
        /// View text
        /// </summary>
        /// <returns>View text</returns>
        public override string ToString()
        {
            return Text;
        }

        /// <summary>
        /// Focus view
        /// </summary>
        /// <returns></returns>
        public new bool Focus()
        {
            return Visible && base.Focus();
        }
    }
}
