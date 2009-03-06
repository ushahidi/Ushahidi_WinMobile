using System;
using Ushahidi.Common.MVC;
using Ushahidi.View.Views;

namespace Ushahidi.View.Controllers
{
    /// <summary>
    /// The base view controller
    /// </summary>
    /// <typeparam name="TView">view</typeparam>
    /// <typeparam name="TModel">model</typeparam>
    public abstract class BaseViewController<TView, TModel> : ViewController<TView, TModel>
        where TView : IBaseView, new()
        where TModel : IModel, new()
    {
        /// <summary>
        /// The base view controller
        /// </summary>
        protected BaseViewController()
        {
            View.MenuPrimaryAction.Click += OnPrimaryAction;
            View.MenuAbout.Click += OnAbout;
            View.MenuSettings.Click += OnSettings;
            View.MenuIncidentList.Click += OnIncidentList;
            View.MenuIncidentMap.Click += OnIncidentMap;
            View.MenuAddIncident.Click += OnAddIncident;
            View.MenuExit.Click += OnExit;
        }

        /// <summary>
        /// On primary action menu item click
        /// </summary>
        protected virtual void OnPrimaryAction(object sender, EventArgs e)
        {
            //implementing view controller will override and provide primary action code
        }

        /// <summary>
        /// On about menu item click
        /// </summary>
        private void OnAbout(object sender, EventArgs e)
        {
            OnForward(typeof(AboutViewController), true);   
        }

        /// <summary>
        /// On settings menu item click
        /// </summary>
        private void OnSettings(object sender, EventArgs e)
        {
            OnForward(typeof(SettingsViewController), true);
        }

        /// <summary>
        /// On incident list menu item click
        /// </summary>
        private void OnIncidentList(object sender, EventArgs e)
        {
            OnForward(typeof(IncidentListViewController), true);
        }

        /// <summary>
        /// On incident map menu item click
        /// </summary>
        private void OnIncidentMap(object sender, EventArgs e)
        {
            OnForward(typeof(IncidentMapViewController), true);
        }

        /// <summary>
        /// On add incident menu item click
        /// </summary>
        private void OnAddIncident(object sender, EventArgs e)
        {
            OnForward(typeof(AddIncidentViewController), true);
        }

        /// <summary>
        /// On exit menu item click
        /// </summary>
        private void OnExit(object sender, EventArgs e)
        {
            OnExit();
        }
    }
}
