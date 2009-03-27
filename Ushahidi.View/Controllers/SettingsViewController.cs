using Ushahidi.View.Models;
using Ushahidi.View.Views;

namespace Ushahidi.View.Controllers
{
    /// <summary>
    /// Settings View Controller
    /// </summary>
    public class SettingsViewController : BaseViewController<SettingsView, SettingsModel>
    {
        /// <summary>
        /// Save error caption
        /// </summary>
        public override string SaveErrorCaption
        {
            get { return "Missing Fields"; }
        }

        /// <summary>
        /// Save error message
        /// </summary>
        public override string SaveErrorMessage
        {
            get { return "Please verify all required fields are entered"; }
        }

        public override void Load()
        {
            View.ServerAddress = Model.ServerAddress;
            View.DefaultLocale = Model.DefaultLocale;
            View.ShowKeyboard = Model.ShowKeyboard;
        }

        public override bool Save()
        {
            if (View.ShouldSave)
            {
                Model.ServerAddress = View.ServerAddress;
                Model.DefaultLocale = View.DefaultLocale;
                Model.ShowKeyboard = View.ShowKeyboard;
                return Model.Save();
            }
            return true;
        }
    }
}
