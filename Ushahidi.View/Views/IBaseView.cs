using System.Windows.Forms;
using Ushahidi.Common.MVC;

namespace Ushahidi.View.Views
{
    /// <summary>
    /// The base view interface
    /// </summary>
    public interface IBaseView : IView
    {
        /// <summary>
        /// Primary action menu item
        /// </summary>
        MenuItem MenuPrimaryAction { get; }

        /// <summary>
        /// Exit menu item
        /// </summary>
        MenuItem MenuExit { get; }

        /// <summary>
        /// Settings menu item
        /// </summary>
        MenuItem MenuSettings { get; }

        /// <summary>
        /// About menu item
        /// </summary>
        MenuItem MenuAbout { get; }

        /// <summary>
        /// Add incident menu item
        /// </summary>
        MenuItem MenuAddIncident { get; }

        /// <summary>
        /// Incident list menu item
        /// </summary>
        MenuItem MenuIncidentList { get; }

        /// <summary>
        /// Incident map menu item
        /// </summary>
        MenuItem MenuIncidentMap { get; }

    }
}
