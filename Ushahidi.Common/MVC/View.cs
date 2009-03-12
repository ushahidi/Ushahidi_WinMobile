using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Ushahidi.Common.MVC
{
    /// <summary>
    /// Abstract view
    /// </summary>
    public abstract class View : Form, IView
    {
        /// <summary>
        /// Render view
        /// </summary>
        public virtual void Render()
        {
            //implementing view can override and provide render code
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
            OnForward(type, false);
        }

        /// <summary>
        /// Move forward
        /// </summary>
        /// <param name="type">view controller type</param>
        /// <param name="clearStack">clear stack</param>
        protected void OnForward(Type type, bool clearStack)
        {
            if (Forward != null)
            {
                Forward(type, clearStack);
            }
        }

        /// <summary>
        /// The back event
        /// </summary>
        public event BackHandler Back;

        /// <summary>
        /// Back event handler
        /// </summary>
        protected void OnBack()
        {
            if (Back != null)
            {
                Back();
            }
        }

        /// <summary>
        /// Override on closing to cancel close, and instead pop from navigation stack
        /// </summary>
        protected override void OnClosing(CancelEventArgs e)
        {
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
    }
}
