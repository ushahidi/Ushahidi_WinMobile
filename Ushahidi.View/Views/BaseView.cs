using System;
using System.ComponentModel;
using System.Windows.Forms;
using Ushahidi.Common.MVC;

namespace Ushahidi.View.Views
{
    public partial class BaseView
    {
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
        /// The back event
        /// </summary>
        public event BackHandler Back;

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
        /// Render view
        /// </summary>
        public virtual void Render()
        {
            //implementing view will override and provide render code
        }

        /// <summary>
        /// Primary action menu item
        /// </summary>
        public MenuItem MenuPrimaryAction { get { return menuItemAction; } }

        /// <summary>
        /// Exit menu item
        /// </summary>
        public MenuItem MenuExit { get { return menuItemExit; } }

        /// <summary>
        /// Settings menu item
        /// </summary>
        public MenuItem MenuSettings { get { return menuItemSettings; } }

        /// <summary>
        /// About menu item
        /// </summary>
        public MenuItem MenuAbout { get { return menuItemAbout; } }

        /// <summary>
        /// Add incident menu item
        /// </summary>
        public MenuItem MenuAddIncident { get { return menuItemAddIncident; } }

        /// <summary>
        /// Incident list menu item
        /// </summary>
        public MenuItem MenuIncidentList { get { return menuItemIncidentList; } }

        /// <summary>
        /// Incident map menu item
        /// </summary>
        public MenuItem MenuIncidentMap { get { return menuItemIncidentMap; } }
    }
}
